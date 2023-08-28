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
            paint2D.MoveTo(new Vector2(150f, 150));
            paint2D.LineTo(new Vector2(170, 200));
            paint2D.LineTo(new Vector2(170, 160));
            paint2D.LineTo(new Vector2(210, 160));
            paint2D.LineTo(new Vector2(210, 140));
            paint2D.LineTo(new Vector2(170, 140));
            paint2D.LineTo(new Vector2(170, 100));
            paint2D.LineTo(new Vector2(150, 150));
            paint2D.ClosePath();
            paint2D.Fill();
        }

    }
}
