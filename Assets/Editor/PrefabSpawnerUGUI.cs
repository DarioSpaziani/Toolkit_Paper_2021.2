using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Editor
{
    [CustomEditor(typeof(SpawnerScript))]
    public class PrefabSpawnerIMGUI : EditorWindow
    {
        [MenuItem("Tools/SpawnerIMGUI")]
        static void Init()
        {
            PrefabSpawnerIMGUI window = (PrefabSpawnerIMGUI)GetWindow(typeof(PrefabSpawnerIMGUI));
            window.minSize = new Vector2(450, 350);
            window.Show();
        }
        
        public void OnGUI()
        {
            SpawnerScript spawnerScript = FindObjectOfType<SpawnerScript>();
            
            spawnerScript.prefab = EditorGUILayout.ObjectField(spawnerScript.prefab, typeof(GameObject), true) as GameObject;
            
            EditorGUILayout.LayerField("LayerMask", 0 >> 8);
            EditorGUILayout.LabelField("Rotation", EditorStyles.boldLabel);
            spawnerScript.minRotation = EditorGUILayout.Vector3Field("MinRotation", spawnerScript.minRotation);
            spawnerScript.maxRotation = EditorGUILayout.Vector3Field("MaxRotation", spawnerScript.maxRotation);
            EditorGUILayout.LabelField("Scale", EditorStyles.boldLabel);
            spawnerScript.minScale = EditorGUILayout.IntField("MinScale", spawnerScript.minScale);
            spawnerScript.maxScale = EditorGUILayout.IntField("MaxScale",spawnerScript.maxScale);
            spawnerScript.activeToggle = EditorGUILayout.Toggle("ActiveToggle", spawnerScript.activeToggle);
            spawnerScript.activeToggle = EditorGUILayout.Toggle("Align To Normal", spawnerScript.alignToNormal);
            
        }
        
    }
}
