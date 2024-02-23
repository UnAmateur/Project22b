using LibCore.Controles.Donnees;
using LibCore.Couleurs;
using LibCore.Parametrages;
using LibCore.Parametrages.Definitions;

using System.Drawing;

namespace LibCore.Controles
{
    internal partial class ChoixCmjk : CoreChoix<Cmjk>
    {
        public ChoixCmjk()
        {
            InitializeComponent();
            graphGradient1.CouleurMax = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-1", "Fin"]);
            graphGradient1.CouleurMin = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-1", "Debut"]);
            graphGradient1.Couleur = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-1", "Curseur"]);
            graphGradient2.CouleurMax = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-2", "Fin"]);
            graphGradient2.CouleurMin = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-2", "Debut"]);
            graphGradient2.Couleur = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-2", "Curseur"]);
            graphGradient3.CouleurMax = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-3", "Fin"]);
            graphGradient3.CouleurMin = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-3", "Debut"]);
            graphGradient3.Couleur = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-3", "Curseur"]);
            graphGradient4.CouleurMax = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-4", "Fin"]);
            graphGradient4.CouleurMin = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-4", "Debut"]);
            graphGradient4.Couleur = (Color)new DefCouleur((Noeud)Parametres.Themes.ChoixCouleurCmjk["Grad-4", "Curseur"]);
            graphGradient1.Changed += CmjkChanged;
            graphGradient2.Changed += CmjkChanged;
            graphGradient3.Changed += CmjkChanged;
            graphGradient4.Changed += CmjkChanged;
            Couleur = new Cmjk(0.5, 0.5, 0.5, 0.5);
        }
        protected override void OnCouleurChanged(Cmjk value)
        {
            if (value is null) { return; }
            if (Couleur != value)
            {
                graphGradient1.ValeurX = (float)value.Cyan * 100.0f;
                graphGradient2.ValeurX = (float)value.Magenta * 100.0f;
                graphGradient3.ValeurX = (float)value.Jaune * 100.0f;
                graphGradient4.ValeurX = (float)value.Noir * 100.0f;
                PutCouleur(value);
                ChangeCouleur();
            }
        }

        private void CmjkChanged(object sender, ValeurEventArgs e)
        {
            ChangeCouleur();
        }

        private void ChangeCouleur()
        {
            Cmjk value = new Cmjk
            {
                Cyan = graphGradient1.ValeurX / 100.0,
                Magenta = graphGradient2.ValeurX / 100.0,
                Jaune = graphGradient3.ValeurX / 100.0,
                Noir = graphGradient4.ValeurX / 100.0
            };
            PutCouleur(value);
            Affiche();
        }
        private void Affiche()
        {
            label1.Text = Couleur.ToString();
            panel1.BackColor = (Rgb)Couleur;
            OnCouleurChanged();
        }
    }
}
