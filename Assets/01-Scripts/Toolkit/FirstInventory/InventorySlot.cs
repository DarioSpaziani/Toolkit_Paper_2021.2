using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.Toolkit.FirstInventory
{
    public class InventorySlot
    {
        public readonly Button button;
        private readonly Item _item;
    
        public InventorySlot(Item item, VisualTreeAsset template)
        {
            TemplateContainer itemButtonContainer = template.Instantiate();

            button = itemButtonContainer.Q<Button>();
            _item = item;
            button.style.backgroundImage =new StyleBackground(item.icon);
        
            button.RegisterCallback<ClickEvent>(OnClick);

        }

        public void OnClick(ClickEvent clickEvent)
        {
            Debug.Log("Inventory slot with the name " + _item.displayName + " has been clicked");
        }
    }
}