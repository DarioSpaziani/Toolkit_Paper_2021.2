using _01_Scripts;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ObjectBuilderScript))]
    public class ObjectBuilder : UnityEditor.Editor
    {
        [MenuItem("Tools/SpawnerIMGUI")]
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}