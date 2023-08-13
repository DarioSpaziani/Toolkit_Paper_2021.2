using UnityEngine;
using UnityEngine.UIElements;

namespace Toolkit.SecondInventory
{
    public class ItemVisual : VisualElement
    {
        private readonly ItemDefinition _item;

        public ItemVisual(ItemDefinition item)
        {
            _item = item;

            name = $"{_item.itemName}";

            style.height = _item.slotDimension.height * PlayerInventory.SlotDimension.height;
            style.width = _item.slotDimension.width * PlayerInventory.SlotDimension.width;
            style.visibility = Visibility.Hidden;

            VisualElement icon = new VisualElement
            {
                style = { backgroundImage = _item.icon.texture }
            };
    
            Add(icon);
            icon.AddToClassList("visual-icon");
            AddToClassList("visual-icon-container");
        }

        public void SetPosition(Vector2 pos)
        {
            style.left = pos.x;
            style.top = pos.y;
        }
    }
}
