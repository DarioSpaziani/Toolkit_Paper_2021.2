using UnityEditor;
using UnityEngine;

namespace _01_Scripts
{
    public class ObjectBuilderScript : MonoBehaviour 
    {
        public GameObject obj;

        public void BuildObject()
        {
            var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            Physics.Raycast(ray, out var raycastHit, Mathf.Infinity, layerMask: 0 >> 8);
        
            Instantiate(obj, raycastHit.point, Quaternion.identity);

        }
    }
}