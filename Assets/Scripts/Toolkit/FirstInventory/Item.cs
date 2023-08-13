using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "item", menuName = "ItemInventory/Inventory")]
public class Item : ScriptableObject
{
    public string description;
    public string displayName;
    public Sprite icon;
}
