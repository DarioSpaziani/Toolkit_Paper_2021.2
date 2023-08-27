using _01_Scripts.line_chart;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LineChartWindow : EditorWindow
{
    [MenuItem("Tools/LineChartWindow")]
    public static void ShowWindow()
    {
        LineChartWindow window = GetWindow<LineChartWindow>();
        window.titleContent = new GUIContent("Line Chart Window");
    }

    private void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        root.Add(new LineChart());
    }
}