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
            paint2D.MoveTo(new Vector2(80f, 120f));
            paint2D.LineTo(new Vector2(75f, 130f));
            paint2D.LineTo(new Vector2(131f, 012f));
            paint2D.LineTo(new Vector2(45f, 50f));
            paint2D.ClosePath();
            paint2D.Fill();
        }

    }
}
