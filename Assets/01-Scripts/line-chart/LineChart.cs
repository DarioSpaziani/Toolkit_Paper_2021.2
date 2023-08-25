using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.line_chart
{
    public class LineChart : VisualElement
    {
        VisualElement _mLine;
    
        public LineChart()
        {
            generateVisualContent += DrawCanvas;
        }
        void DrawCanvas(MeshGenerationContext mgc)
        {
            var paint2D = mgc.painter2D;
     
            paint2D.fillColor = Color.white;
            paint2D.BeginPath();
            paint2D.MoveTo(new Vector2(100, 120));
            paint2D.LineTo(new Vector2(120, 90));
            paint2D.LineTo(new Vector2(190, 70));
            paint2D.LineTo(new Vector2(210, 70));
            paint2D.ClosePath();
            paint2D.Fill();
        }

    }
}
