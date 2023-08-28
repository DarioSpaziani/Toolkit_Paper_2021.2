using _01_Scripts.line_chart;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class LineChartWindow : EditorWindow
    {
        [MenuItem("Tools/LineChart Window")]
        public static void ShowWindow()
        {
            LineChartWindow window = GetWindow<LineChartWindow>();
            window.titleContent = new GUIContent("Line Chart Window");
        }

        void CreateGUI()
        {
            VisualElement root = rootVisualElement;
        
            root.Add(new LineChart());
        }
    }
}
