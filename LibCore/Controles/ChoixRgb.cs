using LibCore.Couleurs;
using LibCore.Parametrages;
using LibCore.Parametrages.Definitions;

using System.Drawing;

namespace LibCore.Controles
{
    internal partial class ChoixRgb : CoreChoix<Rgb>
    {
        public ChoixRgb()
        {
            InitializeComponent();
            ChangeCouleur();
            graphRgb1.Couleur = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurRgb["Graph", "Curseur"]);
            graphGradient1.CouleurMax = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurRgb["Grad", "Fin"]);
            graphGradient1.CouleurMin = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurRgb["Grad", "Debut"]);
            graphGradient1.Couleur = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurRgb["Grad", "Curseur"]);
            graphRgb1.Changed += GraphRgb1_Changed;
            graphGradient1.Changed += GraphGradient1_Changed;
            Couleur = new Rgb(0, 255, 128);
        }

        protected override void OnCouleurChanged(Rgb value)
        {
            if (value is null) { return; }
            if (Couleur != value)
            {
                graphGradient1.ValeurY = (float)value.Bleu;
                graphRgb1.ValeurX = (float)value.Rouge;
                graphRgb1.ValeurY = (float)value.Vert;
                graphRgb1.ValeurZ = (float)value.Bleu;
                ChangeCouleur();
            }
        }
        private void GraphRgb1_Changed(object sender, Donnees.ValeurEventArgs e)
        {
            ChangeCouleur();
        }

        private void GraphGradient1_Changed(object sender, Donnees.ValeurEventArgs e)
        {

            graphRgb1.ValeurZ = e.Y;
            ChangeCouleur();
        }
        private void ChangeCouleur()
        {
            Rgb value = new Rgb
            {
                Rouge = graphRgb1.ValeurX,
                Vert = graphRgb1.ValeurY,
                Bleu = graphRgb1.ValeurZ
            };
            PutCouleur(value);
            Affiche();
        }
        private void Affiche()
        {
            label1.Text = Couleur.ToString();
            panel1.BackColor = Couleur;
            OnCouleurChanged();
        }

    }

}
