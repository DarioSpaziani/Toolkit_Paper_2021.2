using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Editor
{
    public class PrefabSpawner : EditorWindow
    {
        [SerializeField] private VisualTreeAsset tree;

        private LayerMaskField layerInput;
        private Vector3Field minRotationInput;
        private Vector3Field maxRotationInput;
        private FloatField minScaleInput;
        private FloatField maxScaleInput;
        private Toggle activeToggle;
        private Toggle alignToNormalToogle;

        private GameObject prefab;

        [MenuItem("Tools/Spawner")]
        public static void ShowEditor()
        {
            var window = GetWindow<PrefabSpawner>();
            window.titleContent = new GUIContent("Spawner");
        }

        private void CreateGUI()
        {
            tree.CloneTree(rootVisualElement);
            InitFields();
        }

        private void OnEnable()
        {
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            if (sceneView != null)
            {
                if (!activeToggle.value) return;
                var evt = Event.current;

                if (evt.IsLeftMouseButtonDown())
                {
                    Debug.Log("Left Button Clicked");

                    var ray = HandleUtility.GUIPointToWorldRay(evt.mousePosition);
                    Physics.Raycast(ray, out var raycastHit, Mathf.Infinity, layerInput.value);

                    if (raycastHit.collider)
                    {
                        var obj = CreatePrefab(raycastHit.point);
                        ApplyRandomRotation(obj,raycastHit.normal);
                        ApplyRandomScale(obj);
                    
                        Undo.RegisterCreatedObjectUndo(obj, "Prefab Spawned");
                    }

                }
            }
            
        }
        
        private GameObject CreatePrefab(Vector3 pos)
        {
            var obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject; //permetti di creare un prefab è come l'instantiate

            obj.transform.position = pos;

            return obj;
        }

        private void ApplyRandomScale(GameObject obj)
        {
            var minScale = minScaleInput.value;
            var maxScale = maxScaleInput.value;
            obj.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        }
        
        private void ApplyRandomRotation(GameObject obj, Vector3 normal)
        {
            var minRotation = minRotationInput.value;
            var maxRotation = maxRotationInput.value;
            var alignToNormal = alignToNormalToogle.value;

            if (alignToNormal)
            {
                obj.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            }

            var rotationInEuler = obj.transform.rotation.eulerAngles;
            obj.transform.rotation = Quaternion.Euler(
                rotationInEuler.x + Random.Range(minRotation.x, maxRotation.x),
                rotationInEuler.y + Random.Range(minRotation.y, maxRotation.y),
                rotationInEuler.z + Random.Range(minRotation.z, maxRotation.z)
            );
        }

        private void InitFields()
        {
            layerInput = rootVisualElement.Q<LayerMaskField>("Layer");
            minRotationInput = rootVisualElement.Q<Vector3Field>("MinRotation");
            maxRotationInput = rootVisualElement.Q<Vector3Field>("MaxRotation");
            minScaleInput = rootVisualElement.Q<FloatField>("MinScale");
            maxScaleInput = rootVisualElement.Q<FloatField>("MaxScale");
            activeToggle = rootVisualElement.Q<Toggle>("Active");
            alignToNormalToogle = rootVisualElement.Q<Toggle>("AlignToNormal");

            var prefabInput = rootVisualElement.Q<ObjectField>("Prefab");
            prefabInput.RegisterValueChangedCallback(evt =>
            {
                prefab = evt.newValue as GameObject;
            });
        }
    }
}
