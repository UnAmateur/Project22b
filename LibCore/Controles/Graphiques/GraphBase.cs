using LibCore.Controles.Donnees;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LibCore.Controles.Graphiques
{
    internal partial class GraphBase : CoreControle, IDonneesThemes
    {
        internal DonneesGraphiques donneesGraphiques;
        public GraphBase() : this("Default") { }
        public GraphBase(string nametheme) : base(nametheme)
        {
            InitializeComponent();
            donneesGraphiques = new DonneesGraphiques(TypeGraphTheme.Default, this);
            donneesGraphiques.Changed += DonneesGraphiques_Changed;
        }

        private void DonneesGraphiques_Changed(object sender, EventArgs e)
        {
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
        }
        [Category("Mise en forme graphiques")]
        public string Format { get => ((IDonneesThemes)donneesGraphiques).Format; set => ((IDonneesThemes)donneesGraphiques).Format = value; }
        [Category("Donnees Graphiques")]
        public float MaxX { get => ((IDonneesBase)donneesGraphiques).MaxX; set => ((IDonneesBase)donneesGraphiques).MaxX = value; }
        [Category("Donnees Graphiques")]
        public float MaxY { get => ((IDonneesBase)donneesGraphiques).MaxY; set => ((IDonneesBase)donneesGraphiques).MaxY = value; }
        [Category("Donnees Graphiques")]
        public float MinX { get => ((IDonneesBase)donneesGraphiques).MinX; set => ((IDonneesBase)donneesGraphiques).MinX = value; }
        [Category("Donnees Graphiques")]
        public float MinY { get => ((IDonneesBase)donneesGraphiques).MinY; set => ((IDonneesBase)donneesGraphiques).MinY = value; }
        [Category("Mise en forme graphiques")]
        public bool AxeX { get => ((IDonneesThemes)donneesGraphiques).AxeX; set => ((IDonneesThemes)donneesGraphiques).AxeX = value; }
        [Category("Mise en forme graphiques")]
        public bool AxeY { get => ((IDonneesThemes)donneesGraphiques).AxeY; set => ((IDonneesThemes)donneesGraphiques).AxeY = value; }
        [Category("Mise en forme graphiques")]
        public bool Cadre { get => ((IDonneesThemes)donneesGraphiques).Cadre; set => ((IDonneesThemes)donneesGraphiques).Cadre = value; }
        [Category("Mise en forme graphiques")]
        public bool PrimaireX { get => ((IDonneesThemes)donneesGraphiques).PrimaireX; set => ((IDonneesThemes)donneesGraphiques).PrimaireX = value; }
        [Category("Mise en forme graphiques")]
        public bool PrimaireY { get => ((IDonneesThemes)donneesGraphiques).PrimaireY; set => ((IDonneesThemes)donneesGraphiques).PrimaireY = value; }
        [Category("Mise en forme graphiques")]
        public bool SecondaireX { get => ((IDonneesThemes)donneesGraphiques).SecondaireX; set => ((IDonneesThemes)donneesGraphiques).SecondaireX = value; }
        [Category("Mise en forme graphiques")]
        public bool SecondaireY { get => ((IDonneesThemes)donneesGraphiques).SecondaireY; set => ((IDonneesThemes)donneesGraphiques).SecondaireY = value; }
        [Category("Mise en forme graphiques")]
        public bool TertiaireX { get => ((IDonneesThemes)donneesGraphiques).TertiaireX; set => ((IDonneesThemes)donneesGraphiques).TertiaireX = value; }
        [Category("Mise en forme graphiques")]
        public bool TertiaireY { get => ((IDonneesThemes)donneesGraphiques).TertiaireY; set => ((IDonneesThemes)donneesGraphiques).TertiaireY = value; }
        [Category("Mise en forme graphiques")]
        public bool TexteX { get => ((IDonneesThemes)donneesGraphiques).TexteX; set => ((IDonneesThemes)donneesGraphiques).TexteX = value; }
        [Category("Mise en forme graphiques")]
        public bool TexteY { get => ((IDonneesThemes)donneesGraphiques).TexteY; set => ((IDonneesThemes)donneesGraphiques).TexteY = value; }
        [Category("Mise en forme graphiques")]
        public TypePosition PositionX { get => ((IDonneesThemes)donneesGraphiques).PositionX; set => ((IDonneesThemes)donneesGraphiques).PositionX = value; }
        [Category("Mise en forme graphiques")]
        public TypePosition PositionY { get => ((IDonneesThemes)donneesGraphiques).PositionY; set => ((IDonneesThemes)donneesGraphiques).PositionY = value; }
        [Category("Mise en forme graphiques")]
        public float Marge { get => ((IDonneesBase)donneesGraphiques).Marge; set => ((IDonneesBase)donneesGraphiques).Marge = value; }
        [Category("Theme")]
        public TypeGraphTheme Theme { get => ((IDonneesThemes)donneesGraphiques).Theme; set => ((IDonneesThemes)donneesGraphiques).Theme = value; }



        event EventHandler<ValeurEventArgs> IDonneesBase.Changed
        {
            add
            {
                ((IDonneesBase)donneesGraphiques).Changed += value;
            }

            remove
            {
                ((IDonneesBase)donneesGraphiques).Changed -= value;
            }
        }

        public void Draw(Graphics g)
        {
            ((IDonneesBase)donneesGraphiques).Draw(g);
        }

        public PointF GraphToValeur(PointF value)
        {
            return ((IDonneesBase)donneesGraphiques).GraphToValeur(value);
        }

        public float GraphToValeurX(float value)
        {
            return ((IDonneesBase)donneesGraphiques).GraphToValeurX(value);
        }

        public float GraphToValeurY(float value)
        {
            return ((IDonneesBase)donneesGraphiques).GraphToValeurY(value);
        }

        public PointF ValeurToGraph(PointF value)
        {
            return ((IDonneesBase)donneesGraphiques).ValeurToGraph(value);
        }

        public float ValeurToGraphX(float value)
        {
            return ((IDonneesBase)donneesGraphiques).ValeurToGraphX(value);
        }

        public float ValeurToGraphY(float value)
        {
            return ((IDonneesBase)donneesGraphiques).ValeurToGraphY(value);
        }
    }


}