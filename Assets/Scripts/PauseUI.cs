using UnityEngine;
using UnityEngine.UIElements;

public class PauseUI : MonoBehaviour
{

    private UIDocument doc;
    private Button uiButtonPause;
    private VisualTreeAsset UIBaseTemplate;
    private VisualElement UIBase;
    public VisualElement UIPause;

    private void OnEnable()
    {
        doc = GetComponent<UIDocument>();

        if (doc == null)
        {
            Debug.LogError("No button document found!");
        }

        uiButtonPause = doc.rootVisualElement.Q("TestButton") as Button; //il bottone del componente UIButton

        if (uiButtonPause != null)
        {
            Debug.Log("Button found!");
        }

        uiButtonPause.RegisterCallback<ClickEvent>(onUIButtonClick);
    }

    private void onUIButtonClick(ClickEvent clickEvent)
    {
        Debug.Log("The inventory is now open");
    }
}
