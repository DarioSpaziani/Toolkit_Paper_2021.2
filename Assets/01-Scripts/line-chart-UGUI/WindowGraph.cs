using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _01_Scripts.line_chart_UGUI
{
    public class WindowGraph : MonoBehaviour
    {
        [SerializeField] private Sprite circleSprite;
        private RectTransform _graphContainer;

        private void Awake()
        {
            _graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

            List<int> valueList = new List<int> { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
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
                     CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition,
                         circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                }

                lastCircleGameObject = circleGameObject;
            }
        }
        
        private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject go = new GameObject("dotConnection", typeof(Image));
            go.transform.SetParent(_graphContainer, false);
            go.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            RectTransform rectTransform = go.GetComponent<RectTransform>();
            
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 3);
            rectTransform.anchoredPosition = dotPositionA;
            float posX = dotPositionA.y;
            float posY = dotPositionB.y;

            float angle = Mathf.Atan2(posY,posX ) * Mathf.Rad2Deg;
            
            rectTransform.Rotate(new Vector3(0,0,angle));

            Vector3 pos = (dotPositionA + dotPositionB) / 2;
            rectTransform.transform.position = pos;

            //rectTransform.Rotate(new Vector3(angle,0 ,0));
            // dare come rotazione l 'angolo dal primo punto al secondo punto con Mathf.Atan2() così da indirizzarlo verso l'altro punto
            //mettere poi l'immagine al centro tra i due punti
        }
    }
}