using LibCore.Controles.Donnees;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibCore.Controles.Graphiques
{
    internal partial class GraphTsl : CoreControle, IDonneesTsl, IDonneesBase, IDonneesCurseurs
    {
        private readonly DonneesTsl donneesTsl;
        public GraphTsl()
        {
            InitializeComponent();
            MouseDown += GraphTsl_MouseDown;
            MouseUp += GraphTsl_MouseUp;
            MouseMove += GraphTsl_MouseMove;
            donneesTsl = new DonneesTsl(this);
            donneesTsl.Changed += DonneesTsl_Changed;
        }

        private void GraphTsl_MouseMove(object sender, MouseEventArgs e) { MoveMouse(e); }

        private void GraphTsl_MouseUp(object sender, MouseEventArgs e) { UpMouse(e); }

        private void GraphTsl_MouseDown(object sender, MouseEventArgs e) { DownMouse(e); }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            donneesTsl.Draw(e.Graphics);
        }

        public float MaxX { get => ((IDonneesBase)donneesTsl).MaxX; set => ((IDonneesBase)donneesTsl).MaxX = value; }
        public float MaxY { get => ((IDonneesBase)donneesTsl).MaxY; set => ((IDonneesBase)donneesTsl).MaxY = value; }
        public float MinX { get => ((IDonneesBase)donneesTsl).MinX; set => ((IDonneesBase)donneesTsl).MinX = value; }
        public float MinY { get => ((IDonneesBase)donneesTsl).MinY; set => ((IDonneesBase)donneesTsl).MinY = value; }
        public float Marge { get => ((IDonneesBase)donneesTsl).Marge; set => ((IDonneesBase)donneesTsl).Marge = value; }
        public Color Couleur { get => ((IDonneesCurseurs)donneesTsl).Couleur; set => ((IDonneesCurseurs)donneesTsl).Couleur = value; }
        public TypeCurseur Curseur { get => ((IDonneesCurseurs)donneesTsl).Curseur; set => ((IDonneesCurseurs)donneesTsl).Curseur = value; }
        public SizeF DefaultTaille { get => ((IDonneesCurseurs)donneesTsl).DefaultTaille; set => ((IDonneesCurseurs)donneesTsl).DefaultTaille = value; }
        public TypeSens Sens { get => ((IDonneesCurseurs)donneesTsl).Sens; set => ((IDonneesCurseurs)donneesTsl).Sens = value; }
        public float ValeurX { get => ((IDonneesCurseurs)donneesTsl).ValeurX; set => ((IDonneesCurseurs)donneesTsl).ValeurX = value; }
        public float ValeurY { get => ((IDonneesCurseurs)donneesTsl).ValeurY; set => ((IDonneesCurseurs)donneesTsl).ValeurY = value; }

        public event EventHandler<ValeurEventArgs> Changed
        {
            add
            {
                ((IDonneesBase)donneesTsl).Changed += value;
            }

            remove
            {
                ((IDonneesBase)donneesTsl).Changed -= value;
            }
        }

        public void DownMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesTsl).DownMouse(e);
        }

        public void Draw(Graphics e)
        {
            ((IDonneesTsl)donneesTsl).Draw(e);
        }

        public PointF GraphToValeur(PointF value)
        {
            return ((IDonneesBase)donneesTsl).GraphToValeur(value);
        }

        public float GraphToValeurX(float value)
        {
            return ((IDonneesBase)donneesTsl).GraphToValeurX(value);
        }

        public float GraphToValeurY(float value)
        {
            return ((IDonneesBase)donneesTsl).GraphToValeurY(value);
        }

        public void MoveMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesTsl).MoveMouse(e);
        }

        public void UpMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesTsl).UpMouse(e);
        }

        public PointF ValeurToGraph(PointF value)
        {
            return ((IDonneesBase)donneesTsl).ValeurToGraph(value);
        }

        public float ValeurToGraphX(float value)
        {
            return ((IDonneesBase)donneesTsl).ValeurToGraphX(value);
        }

        public float ValeurToGraphY(float value)
        {
            return ((IDonneesBase)donneesTsl).ValeurToGraphY(value);
        }

        private void DonneesTsl_Changed(object sender, ValeurEventArgs e)
        {
            Refresh();
        }
    }
}
