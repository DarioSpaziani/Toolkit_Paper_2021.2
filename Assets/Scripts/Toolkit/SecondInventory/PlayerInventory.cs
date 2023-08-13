using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Toolkit.SecondInventory
{
    public sealed class PlayerInventory : MonoBehaviour
    {
        private static PlayerInventory _instance;

        private VisualElement _root;
        private VisualElement _inventoryGrid;
        private static Label _itemDetailHeader;
        private static Label _itemDetailBody;
        private static Label _itemDetailPrice;
        private bool _isInventoryReady;
        public static ItemDefinition.Dimensions SlotDimension { get; private set; }
        public List<StoredItem> storedItems = new List<StoredItem>();
        public ItemDefinition.Dimensions inventoryDimensions;
    
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    
        private void Start() => LoadInventory();
    
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
    
        private void AddItemToInventoryGrid(VisualElement item) => _inventoryGrid.Add(item);
        private void RemoveItemFromInventoryGrid(VisualElement item) => _inventoryGrid.Remove(item);
        private static void ConfigureInventoryItem(StoredItem item, ItemVisual visual)
        {
            item.rootVisual = visual;
            visual.style.visibility = Visibility.Visible;
        }

        private async void Configure()
        {
            _root = GetComponentInChildren<UIDocument>().rootVisualElement;
            _inventoryGrid = _root.Q<VisualElement>("Grid");
        
            VisualElement itemDetails = _root.Q<VisualElement>("ItemDetails");
        
            _itemDetailHeader = itemDetails.Q<Label>("Header");
            _itemDetailBody = itemDetails.Q<Label>("Body");
            _itemDetailPrice = itemDetails.Q<Label>("SellPrice");
        
            await UniTask.WaitForEndOfFrame();
        
            ConfigureSlotDimensions();
        
            _isInventoryReady = true;
        }

        private void ConfigureSlotDimensions()
        {
            VisualElement firstSlot = _inventoryGrid.Children().First();

            SlotDimension = new ItemDefinition.Dimensions()
            {
                width = Mathf.RoundToInt(firstSlot.worldBound.width),
                height = Mathf.RoundToInt(firstSlot.worldBound.height)
            };
        }

        private async Task<bool> GetPositionForItem(VisualElement newItem)
        {
            for (int y = 0; y < inventoryDimensions.height; y++)
            {
                for (int x = 0; x < inventoryDimensions.width; x++)
                {
                    SetItemPosition(newItem, new Vector2(SlotDimension.width * x, SlotDimension.height * y));

                    await UniTask.WaitForEndOfFrame();

                    StoredItem overlappingItem = storedItems.FirstOrDefault(s =>
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
}
