using _01_Scripts.Toolkit.SecondInventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace Toolkit.SecondInventory
{
    public class ItemVisual : VisualElement
    {
        private readonly ItemDefinition _item;
        
        private Vector2 _originalPosition;
        private bool _isDragging;
        
        private (bool canPlace, Vector2 position) _placementResults;
        
        public ItemVisual(ItemDefinition item)
        {
            _item = item;

            VisualElement icon = new VisualElement
            {
                style = { backgroundImage = _item.icon.texture },
                name = "Icon"
            };
            
            Add(icon);

            icon.AddToClassList("visual-icon");
            AddToClassList("visual-icon-container");
            
            name = $"{_item.itemName}";
            style.height = _item.slotDimension.height * PlayerInventory.SlotDimension.height;
            style.width = _item.slotDimension.width * PlayerInventory.SlotDimension.width;
            style.visibility = Visibility.Hidden;
            
            RegisterCallback<MouseMoveEvent>(OnMouseMoveEvent);
            RegisterCallback<MouseUpEvent>(OnMouseUpEvent);
        }
        
        ~ItemVisual()
        {
            UnregisterCallback<MouseMoveEvent>(OnMouseMoveEvent);
            UnregisterCallback<MouseUpEvent>(OnMouseUpEvent);
        }

        private Vector2 GetMousePosition(Vector2 mousePosition) => new Vector2(mousePosition.x - (layout.width / 2) - parent.worldBound.position.x, mousePosition.y - (layout.height / 2) - parent.worldBound.position.y);
        
        private void SetPosition(Vector2 pos)
        {
            style.left = pos.x;
            style.top = pos.y;
        }
        
        private void OnMouseUpEvent(MouseUpEvent mouseEvent)
        {
            if (!_isDragging)
            {
                StartDrag();
                PlayerInventory.UpdateItemDetails(_item);
                return;
            }

            _isDragging = false;

            if (_placementResults.canPlace)
            {
                SetPosition(new Vector2(
                    _placementResults.position.x - parent.worldBound.position.x,
                    _placementResults.position.y - parent.worldBound.position.y));
                return;
            }

            SetPosition(new Vector2(_originalPosition.x, _originalPosition.y));
        }

        private void StartDrag()
        {
            _isDragging = true;
            _originalPosition = worldBound.position - parent.worldBound.position;
            BringToFront();
        }
        
        private void OnMouseMoveEvent(MouseMoveEvent mouseEvent)
        {
            if (!_isDragging)
            { 
                return; 
            }

            SetPosition(GetMousePosition(mouseEvent.mousePosition));
            _placementResults = PlayerInventory.instance.ShowPlacementTarget(this);
        }
    }
}





        


