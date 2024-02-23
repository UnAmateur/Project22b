using System.Drawing;
using System.Drawing.Drawing2D;

namespace LibCore.Controles.Donnees
{

    internal class DonneesGradient : DonneesCurseurs, IDonneesGradient
    {
        private Color couleurMin = Color.Black;
        private Color couleurMax = Color.White;

        public DonneesGradient(CoreControle parent) : base("DonneesGraphique", parent) { OnConstructionChanged(); }
        public Color CouleurMin { get { return couleurMin; } set { OnCouleurMinchanged(value); } }
        public Color CouleurMax { get { return couleurMax; } set { OnCouleurMaxChanged(value); } }
        private void OnCouleurMaxChanged(Color value)
        {
            if (couleurMax != value)
            {
                couleurMax = value;
                OnConstructionChanged();
            }
        }

        private void OnCouleurMinchanged(Color value)
        {
            if (couleurMin != value)
            {
                couleurMin = value;
                OnConstructionChanged();
            }
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }
        protected override void Create(Graphics g)
        {
            base.Create(g);
            if (ZoneGraphique.Width > 0 && ZoneGraphique.Height > 0)
            {

                if (Sens == TypeSens.Horizontale)
                {
                    using (Brush pinceau = new LinearGradientBrush(ZoneGraphique, couleurMin, couleurMax, 0f))
                    {
                        g.FillRectangle(pinceau, ZoneGraphique);
                    }
                }
                else if (Sens == TypeSens.Verticale)
                {
                    using (Brush pinceau = new LinearGradientBrush(ZoneGraphique, couleurMin, couleurMax, 90f))
                    {
                        g.FillRectangle(pinceau, ZoneGraphique);
                    }
                }
                else
                {
                    g.DrawRectangles(Pens.White, new RectangleF[] { ZoneGraphique });

                }
            }
        }
    }
}
