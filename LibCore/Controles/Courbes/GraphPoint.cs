using System.Drawing;
using System.Drawing.Drawing2D;

namespace LibCore.Controles.Courbes
{
    internal class GraphPoint : Core
    {
        public PointF Point { get; set; } = PointF.Empty;
        public Color Couleur { get; set; } = Color.White;
        public float Epaisseur { get; set; } = 1f;
        public TypePoint Marqueur { get; set; } = TypePoint.None;
        public float Dimension { get; set; } = 10f;
        public bool MoveX { get; set; } = true;
        public bool MoveY { get; set; } = true;
        public bool Remplissage { get; set; } = true;
        public GraphPoint() : this("GraphPoint") { }
        public GraphPoint(string name) : base(name) { }
        public GraphPoint(string name, PointF point) : this(name) { Point = point; }
        public GraphPoint(string name, float x, float y) : this(name) { Point = new PointF(x, y); }
        public GraphPoint(float x, float y) : this() { Point = new PointF(x, y); }
        public GraphPoint Copy()
        {
            GraphPoint p = new GraphPoint(Name)
            {
                Couleur = Couleur,
                Epaisseur = Epaisseur,
                Marqueur = Marqueur,
                Dimension = Dimension,
                MoveX = MoveX,
                MoveY = MoveY,
                Remplissage = Remplissage
            };
            return p;
        }
        public bool IsInPoint(float x, float y)
        {
            if ((Point.X - Dimension / 2.0f < x & Point.X + Dimension / 2.0f > x) && (Point.Y - Dimension / 2.0f < y & Point.Y + Dimension / 2.0f > y))
            {
                return true;
            }
            return false;
        }
        public bool IsInPoint(PointF p)
        {
            if ((Point.X - 2 < p.X & Point.X + 2 > p.X) && (Point.Y - 2.0f < p.Y & Point.Y + 2.0f > p.Y))
            {
                return true;
            }
            return false;
        }
        public void Move(float dx, float dy)
        {
            if (MoveX)
            {
                if (MoveY)
                {
                    Point = new PointF(Point.X + dx, Point.Y + dy);
                }
                else
                {
                    Point = new PointF(Point.X + dx, Point.Y);
                }
            }
            else
            {
                if (MoveY)
                {
                    Point = new PointF(Point.X, Point.Y + dy);
                }
            }

        }
        public void Change(float x, float y)
        {

            if (MoveX)
            {
                if (MoveY)
                {
                    Point = new PointF(x, y);
                }
                else
                {
                    Point = new PointF(x, Point.Y);
                }
            }
            else
            {
                if (MoveY)
                {
                    Point = new PointF(Point.X, y);
                }
            }
        }
        public void Change(PointF p)
        {

            Change(p.X, p.Y);
        }
        public void Draw(Graphics g, CalculGraphique calcul)
        {
            using (GraphicsPath gp = Figures(calcul))
            {
                if (Remplissage)
                {
                    g.FillPath(Pinceau, gp);
                }
                else
                {
                    g.DrawPath(Crayon, gp);
                }
            }
        }
        private GraphicsPath Figures(CalculGraphique calcul)
        {
            GraphicsPath gp = new GraphicsPath();
            float x1;
            float y1;
            float x2;
            float y2;
            float x3;
            float y3;
            PointF p1;
            switch (Marqueur)
            {
                case TypePoint.Cercle:
                    p1 = calcul(Point);
                    p1.X -= Dimension / 2;
                    p1.Y -= Dimension / 2;
                    gp.AddEllipse(p1.X, p1.Y, Dimension, Dimension);
                    break;
                case TypePoint.Carre:
                    p1 = calcul(Point);
                    gp.AddRectangle(new RectangleF(p1.X, p1.Y, Dimension, Dimension));
                    break;
                case TypePoint.FlecheB:
                    p1 = calcul(Point);
                    x1 = p1.X - Dimension / 2.0f;
                    y1 = p1.Y - Dimension / 2.0f;
                    x2 = p1.X + Dimension / 2.0f;
                    y2 = p1.Y + Dimension / 2.0f;
                    x3 = (x2 + x1) / 2.0f;

                    gp.AddLine(x1, y1, x2, y1);
                    gp.AddLine(x2, y1, x3, y2);
                    gp.AddLine(x3, y2, x1, y1);
                    break;
                case TypePoint.FlecheG:
                    p1 = calcul(Point);
                    x1 = p1.X - Dimension / 2.0f;
                    y1 = p1.Y - Dimension / 2.0f;
                    x2 = p1.X + Dimension / 2.0f;
                    y2 = p1.Y + Dimension / 2.0f;

                    y3 = (y2 + y1) / 2.0f;

                    gp.AddLine(x1, y3, x2, y1);
                    gp.AddLine(x2, y1, x2, y2);
                    gp.AddLine(x2, y2, x1, y3);
                    break;
                case TypePoint.FlecheD:
                    p1 = calcul(Point);
                    x1 = p1.X - Dimension / 2.0f;
                    y1 = p1.Y - Dimension / 2.0f;
                    x2 = p1.X + Dimension / 2.0f;
                    y2 = p1.Y + Dimension / 2.0f;

                    y3 = (y2 + y1) / 2.0f;

                    gp.AddLine(x1, y1, x2, y3);
                    gp.AddLine(x2, y3, x1, y2);
                    gp.AddLine(x1, y2, x1, y1);
                    break;
                case TypePoint.FlecheH:
                    p1 = calcul(Point);
                    x1 = p1.X - Dimension / 2.0f;
                    y1 = p1.Y - Dimension / 2.0f;
                    x2 = p1.X + Dimension / 2.0f;
                    y2 = p1.Y + Dimension / 2.0f;

                    x3 = (x2 + x1) / 2.0f;

                    gp.AddLine(x3, y1, x2, y2);
                    gp.AddLine(x2, y2, x1, y2);
                    gp.AddLine(x1, y2, x3, y1);
                    break;
                case TypePoint.Losange:
                    p1 = calcul(Point);
                    x1 = p1.X - Dimension / 2.0f;
                    y1 = p1.Y - Dimension / 2.0f;
                    x2 = p1.X + Dimension / 2.0f;
                    y2 = p1.Y + Dimension / 2.0f;

                    x3 = (x2 + x1) / 2.0f;
                    y3 = (y2 + y1) / 2.0f;

                    gp.AddLine(x3, y1, x2, y3);
                    gp.AddLine(x2, y3, x3, y2);
                    gp.AddLine(x3, y2, x1, y3);
                    gp.AddLine(x1, y3, x3, y1);
                    break;
                case TypePoint.None:
                    break;
                default:
                    break;
            }
            return gp;
        }
        private Pen Crayon { get { return new Pen(Couleur, Epaisseur); } }
        private Brush Pinceau { get { return new SolidBrush(Couleur); } }
    }

    internal delegate PointF CalculGraphique(PointF value);
}
