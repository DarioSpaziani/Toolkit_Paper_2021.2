    using System.Collections.Generic;
    using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    private UIDocument uiInventory;
    public VisualTreeAsset itemButtonTemplate;

    public List<Item> items;

    private void OnEnable()
    {
        uiInventory = GetComponent<UIDocument>();

        foreach (Item item in items)
        {
            InventorySlot newSlot = new InventorySlot(item, itemButtonTemplate);
            
            uiInventory.rootVisualElement.Q("ItemRow")
                .Add(newSlot.button); //dargli il nome del contenitore dentro ad inventory (il visual element)
        }


    }
}