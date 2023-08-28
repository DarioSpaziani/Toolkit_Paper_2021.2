using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.custom_geometry
{
    [RequireComponent(typeof(UIDocument))]
    public class CustomGeometryComponent : MonoBehaviour
    {
        private CustomGeometry _customGeometry;

        private void Start()
        {
            _customGeometry = new CustomGeometry();
            GetComponent<UIDocument>().rootVisualElement.Add(_customGeometry);
        }
    }
}
