using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.custom_geometry
{
    public class CustomGeometry : VisualElement
    {
        VisualElement _mGeometry;

        #region Arrow variables

        public Vector2 p0Arrow = new (400,150);
        public Vector2 p1Arrow = new (420, 200);
        public Vector2 p2Arrow = new (420, 160);
        public Vector2 p3Arrow = new (460, 160);
        public Vector2 p4Arrow = new (460, 140);
        public Vector2 p5Arrow = new (420, 140);
        public Vector2 p6Arrow = new (420,100);

        #endregion

        #region Hexagon Variables

        public Vector2 p0Hex = new(400, 350);
        public Vector2 p1Hex = new(450, 400);
        public Vector2 p2Hex = new(500, 350);
        public Vector2 p3Hex = new(500, 300);
        public Vector2 p4Hex = new(450, 250);
        public Vector2 p5Hex = new(400, 300);

        #endregion
        
        public CustomGeometry()
        {
            generateVisualContent += DrawCanvas;
        }
        
        void DrawCanvas(MeshGenerationContext ctx)
        {
            var paint2D = ctx.painter2D;

            #region Arrow

            paint2D.fillColor = Color.white;
            paint2D.BeginPath();
            paint2D.MoveTo(p0Arrow);
            paint2D.LineTo(p1Arrow);
            paint2D.LineTo(p2Arrow);
            paint2D.LineTo(p3Arrow);
            paint2D.LineTo(p4Arrow);
            paint2D.LineTo(p5Arrow);
            paint2D.LineTo(p6Arrow);
            paint2D.ClosePath();
            paint2D.Fill();

            #endregion

            #region Hexagon

            paint2D.fillColor = Color.red;
            paint2D.BeginPath();
            paint2D.MoveTo(p0Hex);
            paint2D.LineTo(p1Hex);
            paint2D.LineTo(p2Hex);
            paint2D.LineTo(p3Hex);
            paint2D.LineTo(p4Hex);
            paint2D.LineTo(p5Hex);
            paint2D.ClosePath();
            paint2D.Fill();

            #endregion

        }
    }
}
