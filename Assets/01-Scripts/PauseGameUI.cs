using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts
{
    public class PauseGameUI : MonoBehaviour
    {
        public GameObject pause;
        public VisualElement inventoryUI;
        private VisualElement _pauseWrapper;
        private UIDocument _doc;

        private Button _inventory;

        private void Awake()
        {
            _doc = GetComponent<UIDocument>();

            _inventory = _doc.rootVisualElement.Q<Button>("Inventory");

            _inventory.clicked += OnInventoryClicked;
            _pauseWrapper = _doc.rootVisualElement.Q<VisualElement>("Pause");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pause.SetActive(true);
            }
        }

        private void OnInventoryClicked()
        {
            _pauseWrapper.Clear();
        }
    }
}