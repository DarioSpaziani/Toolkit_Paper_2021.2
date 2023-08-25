using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.pie_chart
{
    [RequireComponent(typeof(UIDocument))]
    public class PieChartComponent : MonoBehaviour
    {
        private PieChart _pieChart;

        private void Start()
        {
            _pieChart = new PieChart();
            GetComponent<UIDocument>().rootVisualElement.Add(_pieChart);
        }
    }
}
