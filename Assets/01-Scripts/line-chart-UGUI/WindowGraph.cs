using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _01_Scripts.line_chart_UGUI
{
    public class WindowGraph : MonoBehaviour
    {
        [SerializeField] private Sprite circleSprite;
        private RectTransform _graphContainer;
        public int lengthOfLineRenderer = 20;

        private void Awake()
        {
            _graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

            List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
            ShowGraph(valueList);
        }

        private GameObject CreateCircle(Vector2 anchoredPosition)
        {
            GameObject o = new GameObject("circle", typeof(Image));
            o.transform.SetParent(_graphContainer, false);
            o.GetComponent<Image>().sprite = circleSprite;
            RectTransform rectTransform = o.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = new Vector2(11, 11);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            return o;
        }

        private void ShowGraph(List<int> valueList)
        {
            float graphHeight = _graphContainer.sizeDelta.y;
            //max of our value for the y axis
            float yMaximum = 100f;
            //distance between each circle in graph
            float xSize = 50f;

            GameObject lastCircleGameObject = null;
            
            for (int i = 0; i < valueList.Count; i++)
            {
                float xPosition = xSize + i * xSize;
                //in this case normalized the value, so if is 0 not goes really in 0
                float yPosition = valueList[i] / yMaximum * graphHeight;
                GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
                if (lastCircleGameObject != null) 
                { 
                    CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition); 
                } 
                lastCircleGameObject = circleGameObject;
            }
        }
        
        private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject go = new GameObject("dotConnection", typeof(Image));
            go.transform.SetParent(_graphContainer, false);
            gameObject.GetComponent<Image>().color = Color.white;
            RectTransform rectTransform = go.GetComponent<RectTransform>();

            LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.widthMultiplier = 0.2f;
            
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            lineRenderer.positionCount = lengthOfLineRenderer;
            // Vector2 dir = (dotPositionB - dotPositionA).normalized;
            // rectTransform.anchorMin = new Vector2(0, 0);
            // rectTransform.anchorMax = new Vector2(0, 0);
            // rectTransform.sizeDelta = new Vector2(100, 3);
            // rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
            //
            // rectTransform.localEulerAngles = new Vector3(0, 0, Vector2.Angle(dotPositionA, dotPositionB));
        }
    }
}
