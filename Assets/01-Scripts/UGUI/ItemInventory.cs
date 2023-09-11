
using TMPro;
using UnityEngine;

namespace _01_Scripts.UGUI
{
    public class ItemInventory : MonoBehaviour
    {
        
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI description;
        public TextMeshProUGUI coins;

        public void handgunDescr()
        {
            Debug.Log("Is over");
            itemName.text = "Handgun";
            description.text = "This handgun is very useful if you don't have anything else in hand...";
            coins.text = "50";
        }
    }
}
