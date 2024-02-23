using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LibCore.Controles.Donnees
{


    internal class DonneesCurseurs : DonneesBase, IDonneesCurseurs
    {
        private Bitmap curseurBmp;
        private TypeSens sens = TypeSens.None;
        private TypeCurseur curseur = TypeCurseur.Carre;
        private SizeF defaultTaille = new SizeF(10, 10);
        private RectangleF ZoneMouvement = new RectangleF(0, 0, 0, 0);
        private Color couleur = Color.White;
        private PointF position;
        private bool MouseOk = false;
        public Color Couleur { get { return couleur; } set { OnCouleurChanged(value); } }

        public float ValeurX
        {
            get { return GraphToValeurX(position.X); }
            set
            {
                switch (sens)
                {
                    case TypeSens.Verticale:

                        break;
                    case TypeSens.Horizontale:
                        if (value >= MinX && value <= MaxX)
                        {
                            position.X = ValeurToGraphX(value);
                            OnDonneesChanged(new ValeurEventArgs(GetPosition(), float.NaN));
                        }
                        break;
                    case TypeSens.None:
                        if (value >= MinX && value <= MaxX)
                        {
                            position.X = ValeurToGraphX(value);
                            OnDonneesChanged(new ValeurEventArgs(GetPosition(), float.NaN));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public float ValeurY
        {
            get { return GraphToValeurY(position.Y); }
            set
            {
                switch (sens)
                {
                    case TypeSens.Verticale:
                        if (value >= MinY && value <= MaxY)
                        {
                            position.Y = ValeurToGraphY(value);
                            OnDonneesChanged(new ValeurEventArgs(GetPosition(), float.NaN));
                        }
                        break;
                    case TypeSens.Horizontale:

                        break;
                    case TypeSens.None:
                        if (value >= MinY && value <= MaxY)
                        {
                            position.Y = ValeurToGraphY(value);
                            OnDonneesChanged(new ValeurEventArgs(GetPosition(), float.NaN));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public TypeCurseur Curseur { get { return curseur; } set { OnCurseurChanged(value); } }
        public TypeSens Sens { get { return sens; } set { OnSensChanged(value); } }
        public SizeF DefaultTaille { get { return defaultTaille; } set { OnTailleChanged(value); } }
        public DonneesCurseurs(CoreControle parent) : this("DonneesCurseurs", parent) { }
        public DonneesCurseurs(string name, CoreControle parent) : base(name, parent) { position = new PointF(ZoneGraphique.X + ZoneGraphique.Width / 2.0f, ZoneGraphique.Y + ZoneGraphique.Height / (2.0f)); }
        private void OnCouleurChanged(Color value)
        {
            if (value != couleur)
            {
                couleur = value;
                OnConstructionChanged();
            }
        }
        private void OnSensChanged(TypeSens value)
        {
            if (sens != value)
            {
                sens = value;

                OnConstructionChanged();
            }
        }
        private void OnCurseurChanged(TypeCurseur value)
        {
            if (value != curseur)
            {
                curseur = value;
                OnConstructionChanged();
            }
        }
        private void OnTailleChanged(SizeF value)
        {
            if (value != defaultTaille)
            {
                defaultTaille = value;
                OnConstructionChanged();
            }
        }
        private bool InCurseur(PointF e)
        {
            if (e.X >= position.X - curseurBmp.Width / 2.0f && e.X <= position.X + curseurBmp.Width / 2.0f)
            {
                if (e.Y >= position.Y - curseurBmp.Height / 2.0f && e.Y <= position.Y + curseurBmp.Height / 2.0f)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        private void MoveCurseur(float x, float y)
        {

            if (ZoneMouvement.Contains(x, y))
            {
                switch (sens)
                {
                    case TypeSens.Verticale:
                        position = new PointF(position.X, y);
                        break;
                    case TypeSens.Horizontale:
                        position = new PointF(x, position.Y);
                        break;
                    case TypeSens.None:
                        position = new PointF(x, y);
                        break;
                    default:
                        break;
                }
                OnPositionChanged(new ValeurEventArgs(GetPosition(), float.NaN));
            }

        }
        private void MoveCurseur(PointF e) { MoveCurseur(e.X, e.Y); }
        public void DownMouse(MouseEventArgs e)
        {
            if (InCurseur(e.Location))
            {
                Parent.Cursor = Cursors.Hand;
                MouseOk = true;
            }
        }

        public void UpMouse(MouseEventArgs e)
        {
            if (MouseOk)
            {
                Parent.Cursor = Cursors.Default;
                MouseOk = false;
                MoveCurseur(e.Location);
            }
        }

        public void MoveMouse(MouseEventArgs e)
        {
            if (MouseOk && e.Button == MouseButtons.Left && InCurseur(e.Location))
            {
                MoveCurseur(e.Location);
            }
        }
        public override void Draw(Graphics e)
        {
            base.Draw(e);
            DrawCurseur(e);
        }
        protected void DrawCurseur(Graphics e)
        {
            if (curseurBmp is null) { return; }
            float X = position.X - curseurBmp.Width / 2.0f;
            float Y = position.Y - curseurBmp.Height / 2.0f;
            if (sens == TypeSens.Horizontale)
            {
                e.DrawImage(curseurBmp, X, Y);
            }
            else if (sens == TypeSens.Verticale)
            {
                e.DrawImage(curseurBmp, X, Y);
            }
            else
            {
                e.DrawImage(curseurBmp, X, Y);
            }
        }
        private GraphicsPath GetCurseur(Bitmap value)
        {
            GraphicsPath result = new GraphicsPath();
            switch (Curseur)
            {
                case TypeCurseur.Carre:
                    result.AddRectangle(new Rectangle(0, 0, value.Width, value.Height));
                    break;
                case TypeCurseur.Rond:
                    result.AddEllipse(new Rectangle(0, 0, value.Width, value.Height));
                    break;
                case TypeCurseur.None:
                    result.AddRectangle(new Rectangle(0, 0, value.Width, value.Height));
                    break;
                default:
                    break;
            }
            return result;
        }
        protected override void Create(Graphics g)
        {
            base.Create(g);
            position = new PointF(ZoneGraphique.X + ZoneGraphique.Width / 2.0f, ZoneGraphique.Y + ZoneGraphique.Height / (2.0f));
            curseurBmp?.Dispose();
            if (sens == TypeSens.Horizontale)
            {
                curseurBmp = new Bitmap((int)defaultTaille.Width, (int)ZoneGraphique.Height);
                position.Y = ZoneGraphique.Y + ZoneGraphique.Height / 2.0f;
            }
            else if (sens == TypeSens.Verticale)
            {
                curseurBmp = new Bitmap((int)ZoneGraphique.Width, (int)defaultTaille.Height);
                position.X = ZoneGraphique.X + ZoneGraphique.Width / 2.0f;
            }
            else
            {
                curseurBmp = new Bitmap((int)defaultTaille.Width, (int)defaultTaille.Height);
            }
            using (Graphics gr = Graphics.FromImage(curseurBmp))
            {
                gr.Clear(Color.Transparent);
                using (GraphicsPath path = GetCurseur(curseurBmp))
                {
                    using (PathGradientBrush pinceau = new PathGradientBrush(path))
                    {
                        pinceau.CenterColor = Color.Transparent;
                        pinceau.SurroundColors = new Color[] { Couleur };
                        gr.FillPath(pinceau, path);
                    }
                }
            }
            ZoneMouvement = new RectangleF(ZoneGraphique.X - 1, ZoneGraphique.Y - 1, ZoneGraphique.Width + 2f, ZoneGraphique.Height + 2f);
        }

        protected PointF GetPosition()
        {
            PointF e = GraphToValeur(position);
            switch (sens)
            {
                case TypeSens.Verticale:
                    return new PointF(float.NaN, e.Y);
                case TypeSens.Horizontale:
                    return new PointF(e.X, float.NaN);
                case TypeSens.None:
                    return e;
                default:
                    return e;
            }
        }
        protected virtual void OnPositionChanged(ValeurEventArgs e)
        {
            OnDonneesChanged(e);
        }
    }

}
