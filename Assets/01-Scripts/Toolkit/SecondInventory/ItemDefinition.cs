using System;
using UnityEngine;

namespace Toolkit.SecondInventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Data/Item")]
    public class ItemDefinition : ScriptableObject
    {
        public string id = Guid.NewGuid().ToString();
        public string itemName;
        public string description;
        public int sellPrice;
        public Sprite icon;
        public Dimensions slotDimension;

        [Serializable]
        public struct Dimensions
        {
            public int height;
            public int width;
        }
    }
}