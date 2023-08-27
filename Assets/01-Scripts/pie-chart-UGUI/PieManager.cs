using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _01_Scripts.pie_chart_UGUI
{
    public class PieManager : MonoBehaviour
    {
        public Image[] wedgesPieChart;
        [Range(0,100)] public float[] values;

        private void Update()
        {
            SetValues(values);
        }

        public void SetValues(float[] valuesToSet)
        {
            float totalValues = 0;
            for (int i = 0; i < wedgesPieChart.Length; i++)
            {
                totalValues += FindPercentage(valuesToSet, i);
                wedgesPieChart[i].fillAmount = totalValues;
            }
        }

        private float FindPercentage(float[] valueToSet, int index)
        {
            float totalAmount = 0;

            for (int i = 0; i < valueToSet.Length; i++)
            {
                totalAmount += valueToSet[i];
            }

            return valueToSet[index] / totalAmount;
        }
    }
    
    
}
