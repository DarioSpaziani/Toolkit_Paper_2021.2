using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class PieChartWindow : EditorWindow
    {
        [MenuItem("Tools/PieChartWindow")]
        public static void ShowWindow()
        {
            GetWindow<PieChartWindow>().Show();

            PieChartWindow window = CreateInstance<PieChartWindow>();
            window.titleContent = new GUIContent("Pie Chart Window");
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            Label label = new Label("Pie chart");
            
            root.Add(new Label("Pie chart"));
            root.Add(new PieChart());
            root.Add(new Label());
            
            //Create button
            Button button = new Button();
            button.name = "button";
            button.text = "Randomize";
            root.Add(button);
        }
    }
}
