using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.line_chart
{
    public class LineChart : VisualElement
    {
        private VisualElement _mLine;
    
        #region Line Variables

        private readonly Vector2 _p0Line = new(100, 600);
        private readonly Vector2 _p1Line = new(150, 620);
        private readonly Vector2 _p2Line = new(200, 650);
        private readonly Vector2 _p3Line = new(250, 580);
        private readonly Vector2 _p4Line = new(300, 620);
        private readonly Vector2 _p5Line = new(350, 540);
        private readonly Vector2 _p6Line = new(400, 550);
        private readonly Vector2 _p7Line = new(450, 570);
        private readonly Vector2 _p8Line = new(500, 620);
        private readonly Vector2 _p9Line = new(550, 600);

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

            /* Design a circle using Arc path
            paint2D.fillColor = Color.blue;
            paint2D.BeginPath();
            paint2D.Arc(new Vector2(400,800), 50f , 0f, 360f);
            paint2D.Fill();
            */

        }
    }
}
