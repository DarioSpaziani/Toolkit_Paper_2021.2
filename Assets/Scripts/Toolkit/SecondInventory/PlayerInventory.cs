using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Toolkit.SecondInventory
{
    [Serializable]
    public class StoredItem
    {
        public ItemDefinition details;
        public ItemVisual rootVisual;
    }

    
    public sealed class PlayerInventory : MonoBehaviour
    {
        public static PlayerInventory instance;
        private bool _isInventoryReady;
        
        public List<StoredItem> storedItems = new List<StoredItem>();

        private VisualElement _root;
        private VisualElement _inventoryGrid;
        public ItemDefinition.Dimensions inventoryDimensions;
        public static ItemDefinition.Dimensions SlotDimension { get; private set; }
        private static Label _itemDetailHeader;
        private static Label _itemDetailBody;
        private static Label _itemDetailPrice;
        
        private VisualElement _telegraph;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                Configure();
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }
    
        private void Start() => LoadInventory();
        
        private async void Configure()
        {
            _root = GetComponentInChildren<UIDocument>().rootVisualElement;
            _inventoryGrid = _root.Q<VisualElement>("Grid");
            VisualElement itemDetails = _root.Q<VisualElement>("ItemDetails");
            _itemDetailHeader = itemDetails.Q<Label>("Header");
            _itemDetailBody = itemDetails.Q<Label>("Body");
            _itemDetailPrice = itemDetails.Q<Label>("SellPrice");

            ConfigureInventoryTelegraph();

            await UniTask.WaitForEndOfFrame();

            ConfigureSlotDimensions();
            
            _isInventoryReady = true;
        }
        
        private void ConfigureInventoryTelegraph()
        {

            _telegraph = new VisualElement
            {
                name = "Telegraph"
            };
            
            _telegraph.AddToClassList("slot-icon-highlighted");
            
            AddItemToInventoryGrid(_telegraph);
        }
        
        private void ConfigureSlotDimensions()
        {
            VisualElement firstSlot = _inventoryGrid.Children().First();

            SlotDimension = new ItemDefinition.Dimensions
            {
                width = Mathf.RoundToInt(firstSlot.worldBound.width),
                height = Mathf.RoundToInt(firstSlot.worldBound.height)
            };
        }
        
        private void AddItemToInventoryGrid(VisualElement item) => _inventoryGrid.Add(item);
        private void RemoveItemFromInventoryGrid(VisualElement item) => _inventoryGrid.Remove(item);

    
        private async void LoadInventory()
        {
            await UniTask.WaitUntil(() => _isInventoryReady);
            
            foreach (StoredItem loadedItem in storedItems)
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
    
        private static void ConfigureInventoryItem(StoredItem item, ItemVisual visual)
        {
            item.rootVisual = visual;
            visual.style.visibility = Visibility.Visible;
        }

        public static void UpdateItemDetails(ItemDefinition item)
        {
            _itemDetailHeader.text = item.itemName;
            _itemDetailBody.text = item.description;
            _itemDetailPrice.text = item.sellPrice.ToString();
        }
        
        private static void SetItemPosition(VisualElement element, Vector2 vector)
        {
            element.style.left = vector.x;
            element.style.top = vector.y;
        }

        private async Task<bool> GetPositionForItem(VisualElement newItem)
        {
            for (int y = 0; y < inventoryDimensions.height; y++)
            {
                for (int x = 0; x < inventoryDimensions.width; x++)
                {
                    SetItemPosition(newItem, new Vector2(SlotDimension.width * x, SlotDimension.height * y));

                    await UniTask.WaitForEndOfFrame();

                    StoredItem overlappingItem = storedItems.FirstOrDefault(s => s.rootVisual != null && s.rootVisual.layout.Overlaps(newItem.layout));
                    
                    if (overlappingItem == null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        public (bool canPlace, Vector2 position) ShowPlacementTarget(ItemVisual draggedItem)
        {
            if (!_inventoryGrid.layout.Contains(new Vector2(draggedItem.localBound.xMax, draggedItem.localBound.yMax)))
            {
                _telegraph.style.visibility = Visibility.Hidden;
                return (canPlace: false, position: Vector2.zero);
            }

            VisualElement targetSlot = _inventoryGrid.Children().Where(x => x.layout.Overlaps(draggedItem.layout) && x != draggedItem).OrderBy(x => Vector2.Distance(x.worldBound.position, draggedItem.worldBound.position)).First();

            _telegraph.style.width = draggedItem.style.width;
            _telegraph.style.height = draggedItem.style.height;

            SetItemPosition(_telegraph, new Vector2(targetSlot.layout.position.x, targetSlot.layout.position.y));

            _telegraph.style.visibility = Visibility.Visible;

            var overlappingItems = storedItems.Where(x => x.rootVisual != null && x.rootVisual.layout.Overlaps(_telegraph.layout)).ToArray();

            if (overlappingItems.Length > 1)
            {
                _telegraph.style.visibility = Visibility.Hidden;
                return (canPlace: false, position: Vector2.zero);
            }

            return (canPlace: true, targetSlot.worldBound.position);

        }

    }
}
