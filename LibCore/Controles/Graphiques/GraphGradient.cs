using LibCore.Controles.Donnees;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibCore.Controles.Graphiques
{
    internal partial class GraphGradient : CoreControle, IDonneesGradient, IDonneesBase, IDonneesCurseurs
    {
        private readonly DonneesGradient donneesGradient;
        public GraphGradient()
        {
            InitializeComponent();
            MouseDown += GraphGradient_MouseDown;
            MouseUp += GraphGradient_MouseUp;
            MouseMove += GraphGradient_MouseMove;
            donneesGradient = new DonneesGradient(this);
            donneesGradient.Changed += DonneesGradient_Changed;
        }

        private void GraphGradient_MouseMove(object sender, MouseEventArgs e) { MoveMouse(e); }
        private void GraphGradient_MouseUp(object sender, MouseEventArgs e) { UpMouse(e); }
        private void GraphGradient_MouseDown(object sender, MouseEventArgs e) { DownMouse(e); }

        public event EventHandler<ValeurEventArgs> Changed
        {
            add
            {
                ((IDonneesBase)donneesGradient).Changed += value;
            }

            remove
            {
                ((IDonneesBase)donneesGradient).Changed -= value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            donneesGradient.Draw(e.Graphics);
        }

        public Color CouleurMax { get => ((IDonneesGradient)donneesGradient).CouleurMax; set => ((IDonneesGradient)donneesGradient).CouleurMax = value; }
        public Color CouleurMin { get => ((IDonneesGradient)donneesGradient).CouleurMin; set => ((IDonneesGradient)donneesGradient).CouleurMin = value; }
        public float MaxX { get => ((IDonneesBase)donneesGradient).MaxX; set => ((IDonneesBase)donneesGradient).MaxX = value; }
        public float MaxY { get => ((IDonneesBase)donneesGradient).MaxY; set => ((IDonneesBase)donneesGradient).MaxY = value; }
        public float MinX { get => ((IDonneesBase)donneesGradient).MinX; set => ((IDonneesBase)donneesGradient).MinX = value; }
        public float MinY { get => ((IDonneesBase)donneesGradient).MinY; set => ((IDonneesBase)donneesGradient).MinY = value; }
        public float Marge { get => ((IDonneesBase)donneesGradient).Marge; set => ((IDonneesBase)donneesGradient).Marge = value; }
        public Color Couleur { get => ((IDonneesCurseurs)donneesGradient).Couleur; set => ((IDonneesCurseurs)donneesGradient).Couleur = value; }
        public TypeCurseur Curseur { get => ((IDonneesCurseurs)donneesGradient).Curseur; set => ((IDonneesCurseurs)donneesGradient).Curseur = value; }
        public SizeF DefaultTaille { get => ((IDonneesCurseurs)donneesGradient).DefaultTaille; set => ((IDonneesCurseurs)donneesGradient).DefaultTaille = value; }
        public TypeSens Sens { get => ((IDonneesCurseurs)donneesGradient).Sens; set => ((IDonneesCurseurs)donneesGradient).Sens = value; }
        public float ValeurX { get => ((IDonneesCurseurs)donneesGradient).ValeurX; set => ((IDonneesCurseurs)donneesGradient).ValeurX = value; }
        public float ValeurY { get => ((IDonneesCurseurs)donneesGradient).ValeurY; set => ((IDonneesCurseurs)donneesGradient).ValeurY = value; }

        private void DonneesGradient_Changed(object sender, ValeurEventArgs e)
        {
            Refresh();
        }

        public void Draw(Graphics g)
        {
            ((IDonneesBase)donneesGradient).Draw(g);
        }

        public PointF GraphToValeur(PointF value)
        {
            return ((IDonneesBase)donneesGradient).GraphToValeur(value);
        }

        public float GraphToValeurX(float value)
        {
            return ((IDonneesBase)donneesGradient).GraphToValeurX(value);
        }

        public float GraphToValeurY(float value)
        {
            return ((IDonneesBase)donneesGradient).GraphToValeurY(value);
        }

        public PointF ValeurToGraph(PointF value)
        {
            return ((IDonneesBase)donneesGradient).ValeurToGraph(value);
        }

        public float ValeurToGraphX(float value)
        {
            return ((IDonneesBase)donneesGradient).ValeurToGraphX(value);
        }

        public float ValeurToGraphY(float value)
        {
            return ((IDonneesBase)donneesGradient).ValeurToGraphY(value);
        }

        public void DownMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesGradient).DownMouse(e);
        }



        public void MoveMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesGradient).MoveMouse(e);
        }

        public void UpMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesGradient).UpMouse(e);
        }
    }
}
