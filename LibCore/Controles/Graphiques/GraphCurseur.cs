using LibCore.Controles.Donnees;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibCore.Controles.Graphiques
{
    internal class GraphCurseur : CoreControle, IDonneesCurseurs, IDonneesBase
    {
        private readonly DonneesCurseurs donneesCurseurs;

        public bool TempsReel { get; set; } = false;
        public Color Couleur { get => ((IDonneesCurseurs)donneesCurseurs).Couleur; set => ((IDonneesCurseurs)donneesCurseurs).Couleur = value; }
        public TypeCurseur Curseur { get => ((IDonneesCurseurs)donneesCurseurs).Curseur; set => ((IDonneesCurseurs)donneesCurseurs).Curseur = value; }
        public SizeF DefaultTaille { get => ((IDonneesCurseurs)donneesCurseurs).DefaultTaille; set => ((IDonneesCurseurs)donneesCurseurs).DefaultTaille = value; }
        public TypeSens Sens { get => ((IDonneesCurseurs)donneesCurseurs).Sens; set => ((IDonneesCurseurs)donneesCurseurs).Sens = value; }
        public float ValeurX { get => ((IDonneesCurseurs)donneesCurseurs).ValeurX; set => ((IDonneesCurseurs)donneesCurseurs).ValeurX = value; }
        public float ValeurY { get => ((IDonneesCurseurs)donneesCurseurs).ValeurY; set => ((IDonneesCurseurs)donneesCurseurs).ValeurY = value; }
        public float MaxX { get => ((IDonneesBase)donneesCurseurs).MaxX; set => ((IDonneesBase)donneesCurseurs).MaxX = value; }
        public float MaxY { get => ((IDonneesBase)donneesCurseurs).MaxY; set => ((IDonneesBase)donneesCurseurs).MaxY = value; }
        public float MinX { get => ((IDonneesBase)donneesCurseurs).MinX; set => ((IDonneesBase)donneesCurseurs).MinX = value; }
        public float MinY { get => ((IDonneesBase)donneesCurseurs).MinY; set => ((IDonneesBase)donneesCurseurs).MinY = value; }
        public float Marge { get => ((IDonneesBase)donneesCurseurs).Marge; set => ((IDonneesBase)donneesCurseurs).Marge = value; }

        public GraphCurseur() : this("CoreCurseur") { }
        public GraphCurseur(string name) : base(name)
        {
            donneesCurseurs = new DonneesCurseurs(this);
            donneesCurseurs.Changed += DonneesCurseurs_Changed;
            MouseDown += CoreCurseur_MouseDown;
            MouseMove += CoreCurseur_MouseMove;
            MouseUp += CoreCurseur_MouseUp;
        }

        private void DonneesCurseurs_Changed(object sender, ValeurEventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            donneesCurseurs.Draw(e.Graphics);
        }
        public event EventHandler<ValeurEventArgs> Changed
        {
            add
            {
                ((IDonneesBase)donneesCurseurs).Changed += value;
            }

            remove
            {
                ((IDonneesBase)donneesCurseurs).Changed -= value;
            }
        }

        private void CoreCurseur_MouseUp(object sender, MouseEventArgs e) { UpMouse(e); }
        private void CoreCurseur_MouseMove(object sender, MouseEventArgs e) { MoveMouse(e); }
        private void CoreCurseur_MouseDown(object sender, MouseEventArgs e) { DownMouse(e); }

        public void DownMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesCurseurs).DownMouse(e);
        }

        public void Draw(Graphics e)
        {
            ((IDonneesCurseurs)donneesCurseurs).Draw(e);
        }



        public void MoveMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesCurseurs).MoveMouse(e);
        }

        public void UpMouse(MouseEventArgs e)
        {
            ((IDonneesCurseurs)donneesCurseurs).UpMouse(e);
        }

        public PointF GraphToValeur(PointF value)
        {
            return ((IDonneesBase)donneesCurseurs).GraphToValeur(value);
        }

        public float GraphToValeurX(float value)
        {
            return ((IDonneesBase)donneesCurseurs).GraphToValeurX(value);
        }

        public float GraphToValeurY(float value)
        {
            return ((IDonneesBase)donneesCurseurs).GraphToValeurY(value);
        }

        public PointF ValeurToGraph(PointF value)
        {
            return ((IDonneesBase)donneesCurseurs).ValeurToGraph(value);
        }

        public float ValeurToGraphX(float value)
        {
            return ((IDonneesBase)donneesCurseurs).ValeurToGraphX(value);
        }

        public float ValeurToGraphY(float value)
        {
            return ((IDonneesBase)donneesCurseurs).ValeurToGraphY(value);
        }
    }
}
