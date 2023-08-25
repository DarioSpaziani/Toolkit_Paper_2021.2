using UnityEditor;
using UnityEngine;

namespace _01_Scripts
{
    public class ObjectBuilderScript : MonoBehaviour 
    {
        public GameObject obj;
        public LayerMask mask;
        public GameObject prefab;
        public Vector3 minRotation;
        public Vector3 maxRotation;
        public int minScale;
        public int maxScale;
        public bool activeToggle;
        public bool alignToNormal;


        public void BuildObject()
        {
            var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            Physics.Raycast(ray, out var raycastHit, Mathf.Infinity, layerMask: 0 >> 8);
        
            Instantiate(obj, raycastHit.point, Quaternion.identity);

        }
    }
}