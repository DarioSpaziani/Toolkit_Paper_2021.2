using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.line_chart
{
    public class LineChart : VisualElement
    {
        private VisualElement _mLine;
    
        #region Line Variables

        private readonly Vector2 _p0Line = new(100, 100);
        private readonly Vector2 _p1Line = new(150, 120);
        private readonly Vector2 _p2Line = new(200, 150);
        private readonly Vector2 _p3Line = new(250, 80);
        private readonly Vector2 _p4Line = new(300, 120);
        private readonly Vector2 _p5Line = new(350, 40);
        private readonly Vector2 _p6Line = new(400, 50);
        private readonly Vector2 _p7Line = new(450, 70);
        private readonly Vector2 _p8Line = new(500, 120);
        private readonly Vector2 _p9Line = new(550, 100);

        #endregion

        public LineChart()
        {
            generateVisualContent += DrawCanvas;
        }

        void DrawCanvas(MeshGenerationContext ctx)
        {
            var paint2D = ctx.painter2D;

            paint2D.strokeColor = Color.green;
            paint2D.lineWidth = 10f;
            paint2D.lineJoin = LineJoin.Miter;
            paint2D.lineCap = LineCap.Round;
            
            //Create a line graph with the dots;
            paint2D.BeginPath();
            paint2D.MoveTo(p0Line);
            paint2D.LineTo(p1Line);
            paint2D.LineTo(p2Line);
            paint2D.LineTo(p3Line);
            paint2D.LineTo(p4Line);
            paint2D.LineTo(p5Line);
            paint2D.LineTo(p6Line);
            paint2D.LineTo(p7Line);
            paint2D.LineTo(p8Line);
            paint2D.LineTo(p9Line);
            paint2D.MoveTo(_p0Line);
            paint2D.LineTo(_p1Line);
            paint2D.LineTo(_p2Line);
            paint2D.LineTo(_p3Line);
            paint2D.LineTo(_p4Line);
            paint2D.LineTo(_p5Line);
            paint2D.LineTo(_p6Line);
            paint2D.LineTo(_p7Line);
            paint2D.LineTo(_p8Line);
            paint2D.LineTo(_p9Line);
            paint2D.Stroke();

            //Design a circle using Arc path
            paint2D.fillColor = Color.blue;
            paint2D.BeginPath();
            paint2D.Arc(new Vector2(100,400), 50f , 0f, 360f);
            paint2D.Fill();

            // paint2D.strokeColor = Color.red;
            // paint2D.BeginPath();
            // paint2D.ArcTo(p0Line,p1Line,5f);
            // paint2D.ArcTo(p1Line,p2Line,6f);
            // paint2D.ArcTo(p2Line,p3Line,10f);
            // paint2D.ArcTo(p4Line,p5Line,20f);
            // paint2D.ArcTo(p6Line,p7Line,5f);
            // paint2D.ArcTo(p8Line,p9Line,1f);
            
        }
    }
}
