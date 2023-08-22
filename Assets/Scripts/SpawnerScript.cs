using UnityEditor;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public LayerMask mask;
    public GameObject prefab;
    public Vector3 minRotation;
    public Vector3 maxRotation;
    public int minScale;
    public int maxScale;
    public bool activeToggle;
    public bool alignToNormal;
    

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    public void OnSceneGUI(SceneView sceneView)
    {
        Debug.Log("ciao");
        if (sceneView != null)
        {
            //if(!activeToggle) return;
            
            var evt = Event.current;

            if (evt.IsLeftMouseButtonDown())
            {
                var ray = HandleUtility.GUIPointToWorldRay(evt.mousePosition);
                Physics.Raycast(ray, out var raycastHit, Mathf.Infinity, mask);
                
                if (raycastHit.collider)
                {
                    Instantiate(prefab, transform.position, transform.rotation);
                    Debug.Log("hitted " + raycastHit.collider.name);
                }
            }
            
        }
        
    }
}
