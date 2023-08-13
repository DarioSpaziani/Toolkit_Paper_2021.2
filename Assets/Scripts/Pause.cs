using UnityEngine;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public VisualElement inventoryUI;
    public VisualElement pauseWrapper;
    private UIDocument _doc;

    private Button _inventory;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _inventory = _doc.rootVisualElement.Q<Button>("Inventory");

        _inventory.clicked += OnInventoryClicked;
        pauseWrapper = _doc.rootVisualElement.Q<VisualElement>("Pause");
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
        pauseWrapper.Clear();
        
    }
}
