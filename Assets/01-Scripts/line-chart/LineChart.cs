using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.line_chart
{
    public class LineChart : VisualElement
    {
        private VisualElement _mLine;
    
        #region Line Variables

        private readonly Vector2 _p0Line = new(250, 900);
        private readonly Vector2 _p1Line = new(300, 300);
        private readonly Vector2 _p2Line = new(350, 450);
        private readonly Vector2 _p3Line = new(400, 550);
        private readonly Vector2 _p4Line = new(450, 620);
        private readonly Vector2 _p5Line = new(500, 640);
        private readonly Vector2 _p6Line = new(550, 750);
        private readonly Vector2 _p7Line = new(600, 870);
        private readonly Vector2 _p8Line = new(650, 720);
        private readonly Vector2 _p9Line = new(700, 700);

        #endregion

        public LineChart()
        {
            generateVisualContent += DrawCanvas;
        }

        void DrawCanvas(MeshGenerationContext ctx)
        {
            var paint2D = ctx.painter2D;
            var circlePainter2D = ctx.painter2D;

            circlePainter2D.strokeColor = Color.red;
            paint2D.strokeColor = new Color(255,255,255,0.3f);
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
            
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p0Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p1Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p2Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p3Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p4Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p5Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p6Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p7Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p8Line, 5f , 0f, 360f);
            circlePainter2D.Fill();
            
            circlePainter2D.BeginPath();
            circlePainter2D.Arc(_p9Line, 5f , 0f, 360f);
            circlePainter2D.Fill();

            /* Design a circle using Arc path
            paint2D.fillColor = Color.blue;
            paint2D.BeginPath();
            paint2D.Arc(new Vector2(400,800), 50f , 0f, 360f);
            paint2D.Fill();
            */

        }
    }
}
