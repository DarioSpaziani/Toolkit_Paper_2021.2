using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.Toolkit
{
    public class HealthBarUI : MonoBehaviour
    {
        public Transform TransformToFollow;
        private VisualElement m_Bar;
        private Camera m_MainCamera;
        
        private void Start()
        {
            m_MainCamera = Camera.main;
            m_Bar = GetComponent<UIDocument>().rootVisualElement.Q("Container");
            SetPosition();
        }

        private void LateUpdate()
        {
            if (TransformToFollow != null)
            {
                SetPosition();
            }
        }

        public void SetPosition()
        {
            Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(
                m_Bar.panel, TransformToFollow.position, m_MainCamera);

            m_Bar.transform.position = newPosition.WithNewX(newPosition.x - m_Bar.layout.width / 2);
        }
    }
}
