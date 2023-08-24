using UnityEngine;

namespace _01_Scripts.Toolkit.FirstInventory
{
    [CreateAssetMenu(fileName = "item", menuName = "ItemInventory/Inventory")]
    public class Item : ScriptableObject
    {
        public string description;
        public string displayName;
        public Sprite icon;
    }
}
