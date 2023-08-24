using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.Toolkit.FirstInventory
{
    public class Inventory : MonoBehaviour
    {
        private UIDocument _uiInventory;
        public VisualTreeAsset itemButtonTemplate;

        public List<Item> items;

        private void OnEnable()
        {
            _uiInventory = GetComponent<UIDocument>();

            foreach (Item item in items)
            {
                InventorySlot newSlot = new InventorySlot(item, itemButtonTemplate);

                _uiInventory.rootVisualElement.Q("ItemRow")
                    .Add(newSlot.button); //dargli il nome del contenitore dentro ad inventory (il visual element)
            }
        }
    }
}