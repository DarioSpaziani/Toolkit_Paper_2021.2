using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot
{
    public Button button;
    public Item item;
    
    public InventorySlot(Item item, VisualTreeAsset template)
    {
        TemplateContainer itemButtonContainer = template.Instantiate();

        button = itemButtonContainer.Q<Button>();
        this.item = item;
        button.style.backgroundImage =new StyleBackground(item.icon);
        
        button.RegisterCallback<ClickEvent>(OnClick);

    }

    public void OnClick(ClickEvent clickEvent)
    {
        Debug.Log("Invetory slot with the name " + item.displayName + " has been clicked");
    }
}