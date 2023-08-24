using _01_Scripts;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Editor
{
    public class PrefabSpawnerToolkit : EditorWindow
    {
        #region Variables
        
        [SerializeField] private VisualTreeAsset tree;

        private LayerMaskField _layerInput;
        private Vector3Field _minRotationInput;
        private Vector3Field _maxRotationInput;
        private FloatField _minScaleInput;
        private FloatField _maxScaleInput;
        private Toggle _activeToggle;
        private Toggle _alignToNormalToogle;

        private GameObject _prefab;

        #endregion

        [MenuItem("Tools/Spawner")]
        public static void ShowEditor()
        {
            var window = GetWindow<PrefabSpawnerToolkit>();
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
                if (!_activeToggle.value) return;
                var evt = Event.current;

                if (evt.IsLeftMouseButtonDown())
                {
                    var ray = HandleUtility.GUIPointToWorldRay(evt.mousePosition);
                    Physics.Raycast(ray, out var raycastHit, Mathf.Infinity, _layerInput.value);

                    if (raycastHit.collider)
                    {
                        var obj = CreatePrefab(raycastHit.point);
                        ApplyRandomRotation(obj,raycastHit.normal);
                        ApplyRandomScale(obj);
                    
                        Undo.RegisterCreatedObjectUndo(obj, "Prefab Spawned");  //utile per tornare indietro di un azione nel caso si commetta uno sbaglio
                    }
                }
            }
            
        }
        
        private GameObject CreatePrefab(Vector3 pos)
        {
            var obj = PrefabUtility.InstantiatePrefab(_prefab) as GameObject; //permette di creare un prefab è come l'instantiate

            if (obj != null)
            {
                obj.transform.position = pos;
                
            }
            return obj;
        }

        private void ApplyRandomScale(GameObject obj)
        {
            var minScale = _minScaleInput.value;
            var maxScale = _maxScaleInput.value;
            obj.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        }
        
        private void ApplyRandomRotation(GameObject obj, Vector3 normal)
        {
            var minRotation = _minRotationInput.value;
            var maxRotation = _maxRotationInput.value;
            var alignToNormal = _alignToNormalToogle.value;

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
            _layerInput = rootVisualElement.Q<LayerMaskField>("Layer");
            _minRotationInput = rootVisualElement.Q<Vector3Field>("MinRotation");
            _maxRotationInput = rootVisualElement.Q<Vector3Field>("MaxRotation");
            _minScaleInput = rootVisualElement.Q<FloatField>("MinScale");
            _maxScaleInput = rootVisualElement.Q<FloatField>("MaxScale");
            _activeToggle = rootVisualElement.Q<Toggle>("Active");
            _alignToNormalToogle = rootVisualElement.Q<Toggle>("AlignToNormal");

            var prefabInput = rootVisualElement.Q<ObjectField>("Prefab");
            prefabInput.RegisterValueChangedCallback(evt =>
            {
                _prefab = evt.newValue as GameObject;
            });
        }
    }
}
