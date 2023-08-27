using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.line_chart
{
    [RequireComponent(typeof(UIDocument))]
    public class LineChartComponent : MonoBehaviour
    {
        private LineChart _lineChart;

        private void Start()
        {
            _lineChart = new LineChart();
            GetComponent<UIDocument>().rootVisualElement.Add(_lineChart);
        }
    }
}
