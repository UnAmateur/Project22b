using LibCore.Controles.Donnees;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibCore.Controles.Graphiques
{
    internal partial class GraphRgb : CoreControle, IDonneesRgb, IDonneesBase, IDonneesCurseurs

    {
        private readonly DonneesRgb donneesRgb;
        public GraphRgb()
        {
            InitializeComponent();
            MouseDown += GraphRgb_MouseDown;
            MouseMove += GraphRgb_MouseMove;
            MouseUp += GraphRgb_MouseUp;
            donneesRgb = new DonneesRgb(this);
            donneesRgb.Changed += DonneesRgb_Changed;
        }

        private void GraphRgb_MouseUp(object sender, MouseEventArgs e) { UpMouse(e); }

        private void GraphRgb_MouseMove(object sender, MouseEventArgs e) { MoveMouse(e); }

        private void GraphRgb_MouseDown(object sender, MouseEventArgs e) { DownMouse(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            donneesRgb.Draw(e.Graphics);
        }
        public float ValeurZ { get => ((IDonneesRgb)donneesRgb).ValeurZ; set => ((IDonneesRgb)donneesRgb).ValeurZ = value; }
        public Color Couleur { get => ((IDonneesCurseurs)donneesRgb).Couleur; set => ((IDonneesCurseurs)donneesRgb).Couleur = value; }
        public TypeCurseur Curseur { get => ((IDonneesCurseurs)donneesRgb).Curseur; set => ((IDonneesCurseurs)donneesRgb).Curseur = value; }
        public SizeF DefaultTaille { get => ((IDonneesCurseurs)donneesRgb).DefaultTaille; set => ((IDonneesCurseurs)donneesRgb).DefaultTaille = value; }
        public TypeSens Sens { get => ((IDonneesCurseurs)donneesRgb).Sens; set => ((IDonneesCurseurs)donneesRgb).Sens = value; }
        public float ValeurX { get => ((IDonneesCurseurs)donneesRgb).ValeurX; set => ((IDonneesCurseurs)donneesRgb).ValeurX = value; }
        public float ValeurY { get => ((IDonneesCurseurs)donneesRgb).ValeurY; set => ((IDonneesCurseurs)donneesRgb).ValeurY = value; }
        public float MaxX { get => ((IDonneesBase)donneesRgb).MaxX; set => ((IDonneesBase)donneesRgb).MaxX = value; }
        public float MaxY { get => ((IDonneesBase)donneesRgb).MaxY; set => ((IDonneesBase)donneesRgb).MaxY = value; }
        public float MinX { get => ((IDonneesBase)donneesRgb).MinX; set => ((IDonneesBase)donneesRgb).MinX = value; }
        public float MinY { get => ((IDonneesBase)donneesRgb).MinY; set => ((IDonneesBase)donneesRgb).MinY = value; }
        public float Marge { get => ((IDonneesBase)donneesRgb).Marge; set => ((IDonneesBase)donneesRgb).Marge = value; }

        public event EventHandler<ValeurEventArgs> Changed
        {
            add
            {
                ((IDonneesBase)donneesRgb).Changed += value;
            }

            remove
            {
                ((IDonneesBase)donneesRgb).Changed -= value;
            }
        }

        public void DownMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesRgb).DownMouse(e);
        }

        public void Draw(Graphics e)
        {
            ((IDonneesCurseurs)donneesRgb).Draw(e);
        }

        public PointF GraphToValeur(PointF value)
        {
            return ((IDonneesBase)donneesRgb).GraphToValeur(value);
        }

        public float GraphToValeurX(float value)
        {
            return ((IDonneesBase)donneesRgb).GraphToValeurX(value);
        }

        public float GraphToValeurY(float value)
        {
            return ((IDonneesBase)donneesRgb).GraphToValeurY(value);
        }



        public void MoveMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesRgb).MoveMouse(e);
        }

        public void UpMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesRgb).UpMouse(e);
        }

        public PointF ValeurToGraph(PointF value)
        {
            return ((IDonneesBase)donneesRgb).ValeurToGraph(value);
        }

        public float ValeurToGraphX(float value)
        {
            return ((IDonneesBase)donneesRgb).ValeurToGraphX(value);
        }

        public float ValeurToGraphY(float value)
        {
            return ((IDonneesBase)donneesRgb).ValeurToGraphY(value);
        }

        private void DonneesRgb_Changed(object sender, ValeurEventArgs e)
        {
            Refresh();
        }
    }
}
