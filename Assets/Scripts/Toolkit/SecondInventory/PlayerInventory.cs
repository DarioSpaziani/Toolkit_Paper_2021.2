using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public sealed class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private VisualElement m_Root;
    private VisualElement m_InventoryGrid;
    private static Label m_ItemDetailHeader;
    private static Label m_ItemDetailBody;
    private static Label m_ItemDetailPrice;
    private bool m_IsInventoryReady;
    public static ItemDefinition.Dimensions SlotDimension { get; private set; }
    public List<StoredItem> StoredItems = new List<StoredItem>();
    public ItemDefinition.Dimensions InventoryDimensions;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    private void Start() => LoadInventory();
    
    private async void LoadInventory()
    {
        await UniTask.WaitUntil(() => m_IsInventoryReady);
        foreach (StoredItem loadedItem in StoredItems)
        {
            ItemVisual inventoryItemVisual = new ItemVisual(loadedItem.details);
                
            AddItemToInventoryGrid(inventoryItemVisual);
            bool inventoryHasSpace = await GetPositionForItem(inventoryItemVisual);
            if (!inventoryHasSpace)
            {
                Debug.Log("No space - Cannot pick up the item");
                RemoveItemFromInventoryGrid(inventoryItemVisual);
                continue;
            }
            ConfigureInventoryItem(loadedItem, inventoryItemVisual);
        }
    }
    
    private void AddItemToInventoryGrid(VisualElement item) => m_InventoryGrid.Add(item);
    private void RemoveItemFromInventoryGrid(VisualElement item) => m_InventoryGrid.Remove(item);
    private static void ConfigureInventoryItem(StoredItem item, ItemVisual visual)
    {
        item.rootVisual = visual;
        visual.style.visibility = Visibility.Visible;
    }

    private async void Configure()
    {
        m_Root = GetComponentInChildren<UIDocument>().rootVisualElement;
        m_InventoryGrid = m_Root.Q<VisualElement>("Grid");
        
        VisualElement itemDetails = m_Root.Q<VisualElement>("ItemDetails");
        
        m_ItemDetailHeader = itemDetails.Q<Label>("Header");
        m_ItemDetailBody = itemDetails.Q<Label>("Body");
        m_ItemDetailPrice = itemDetails.Q<Label>("SellPrice");
        
        await UniTask.WaitForEndOfFrame();
        
        ConfigureSlotDimensions();
        
        m_IsInventoryReady = true;
    }

    private void ConfigureSlotDimensions()
    {
        VisualElement firstSlot = m_InventoryGrid.Children().First();

        SlotDimension = new ItemDefinition.Dimensions()
        {
            Width = Mathf.RoundToInt(firstSlot.worldBound.width),
            Height = Mathf.RoundToInt(firstSlot.worldBound.height)
        };
    }

    private async Task<bool> GetPositionForItem(VisualElement newItem)
    {
        for (int y = 0; y < InventoryDimensions.Height; y++)
        {
            for (int x = 0; x < InventoryDimensions.Width; x++)
            {
                SetItemPosition(newItem, new Vector2(SlotDimension.Width * x, SlotDimension.Height * y));

                await UniTask.WaitForEndOfFrame();

                StoredItem overlappingItem = StoredItems.FirstOrDefault(s =>
                    s.rootVisual != null && 
                    s.rootVisual.layout.Overlaps(newItem.layout));
                
                if (overlappingItem == null)
                {
                    return true;
                }
            }

        }
        return false;
    }

    private static void SetItemPosition(VisualElement element, Vector2 vector)
    {
        element.style.left = vector.x;
        element.style.top = vector.y;
    }
}
