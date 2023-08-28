using _01_Scripts.custom_geometry;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class CustomGeometryWindow : EditorWindow
    {
        [MenuItem("Tools/CustomGeometryWindow")]
        public static void ShowWindow()
        {
            CustomGeometryWindow window = GetWindow<CustomGeometryWindow>();
            window.titleContent = new GUIContent("Custom Geometry Window");
        }

        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;
        
            root.Add(new Label("Arrow"));


            root.Add(new CustomGeometry());
        }
    }
}