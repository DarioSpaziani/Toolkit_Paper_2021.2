using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Item")]
public class ItemDefinition : ScriptableObject
{
    public string ID = Guid.NewGuid().ToString();
    public string itemName;
    public string description;
    public int sellPrice;
    public Sprite icon;
    public Dimensions SlotDimension;
    
    [Serializable]
    public struct Dimensions
    {
        public int Height;
        public int Width;
    }
}
