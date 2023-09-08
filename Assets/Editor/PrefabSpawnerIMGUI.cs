using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Editor
{
    [CustomEditor(typeof(PrefabSpawnerIMGUI))]
    public class PrefabSpawnerIMGUI : EditorWindow
    {
        public GameObject prefab;
        public Vector3 minPos;
        public Vector3 maxPos;
        public LayerMask layerMask;
        public Vector3 minRotation;
        public Vector3 maxRotation;
        public int minScale;
        public int maxScale;
        public bool activeToggle;
        public bool alignToNormal;


        [MenuItem("Tools/SpawnerIMGUI")]
        public static void ShowWindow()
        {
            //another method to create a window with width and height
            var window = GetWindowWithRect<PrefabSpawnerIMGUI>(new Rect(0, 0, 300, 300));
            window.minSize = new Vector2(300, 300);
            window.maxSize = new Vector2(400, 400);

            window.titleContent = new GUIContent("Prefab Window");
        }
        
        public void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            
            EditorGUILayout.LabelField("Game Object To Spawn", EditorStyles.boldLabel);
            prefab = (GameObject)EditorGUILayout.ObjectField(prefab, typeof(GameObject), true);
            minPos = EditorGUILayout.Vector3Field("Position", minPos);
            maxPos = EditorGUILayout.Vector3Field("Position", maxPos);
            layerMask = EditorGUILayout.LayerField(0 >> 8);
            
            EditorGUILayout.LabelField("Rotation", EditorStyles.boldLabel);
            minRotation = EditorGUILayout.Vector3Field("MinRotation", minRotation);
            maxRotation = EditorGUILayout.Vector3Field("MaxRotation", maxRotation);

            EditorGUILayout.LabelField("Scale", EditorStyles.boldLabel);
            minScale = EditorGUILayout.IntField("MinScale", minScale);
            maxScale = EditorGUILayout.IntField("MaxScale",maxScale);
            
            activeToggle = EditorGUILayout.Toggle("Align To Normal", alignToNormal);
            activeToggle = EditorGUILayout.Toggle("ActiveToggle", activeToggle);
            
            EditorGUILayout.EndVertical();
            
            GUI.backgroundColor = Color.blue;

            if (GUILayout.Button("CREATE!"))
            {
                Instantiate(prefab, RandomPos(), Quaternion.identity);
                ApplyRandomRotation();
                ApplyRandomScale();
            }
            
            // Vector3 mousePos = Input.mousePosition;
            // Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
            // RaycastHit hit;
            //
            // if (Physics.Raycast(castPoint, out hit, Mathf.Infinity,  layerMask))
            // {
            //     Debug.Log("name : " + hit.collider.gameObject.name);
            //     Debug.DrawLine(castPoint.origin, hit.point, Color.yellow);
            //     Instantiate(prefab, hit.point, Quaternion.identity);
            // }
            
        }

        private Vector3 RandomPos()
        {
            var pos = prefab.transform.position;

            prefab.transform.position = new Vector3(
                minPos.x + Random.Range(minPos.x, maxPos.x),
                minPos.y + Random.Range(minPos.y, maxPos.y),
                minPos.x + Random.Range(minPos.z, maxPos.z));

            return pos;
        }

        private void ApplyRandomRotation()
        {
            //if (alignToNormal) obj.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            
            var rotationEuler = prefab.transform.rotation.eulerAngles;
            prefab.transform.rotation = Quaternion.Euler(
                rotationEuler.x + Random.Range(minRotation.x, maxRotation.x),
                rotationEuler.y + Random.Range(minRotation.y, maxRotation.y),
                rotationEuler.z + Random.Range(minRotation.z, maxRotation.z)
            );
        }

        private void ApplyRandomScale()
        {
            prefab.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        }
    }
}