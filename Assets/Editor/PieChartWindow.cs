using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class PieChartWindow : EditorWindow
    {
        //can not possible change variables at runtime. For now
        [MenuItem("Tools/PieChart window")]
        public static void ShowWindow()
        {
            PieChartWindow window = GetWindow<PieChartWindow>();
            window.titleContent = new GUIContent("Pie Chart Window");
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            //Create button
            // Button button = new Button();
            // button.name = "button";
            // button.text = "Randomize";
            // root.Add(button);

            root.Add(new PieChart());
        }
    }
}