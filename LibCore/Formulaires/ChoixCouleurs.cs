using LibCore.Controles;
using LibCore.Couleurs;
using LibCore.Parametrages;

using System;

namespace LibCore.Formulaires
{
    public partial class ChoixCouleurs : CoreFormes
    {
        private Rgb couleur = new Rgb();
        public Rgb Couleur { get { return couleur; } set { OnCouleurRgbChanged(value); } }
        public ChoixCouleurs()
        {
            InitializeComponent();
            Text = Parametres.Langues.Traduction("Formulaires", "Choix couleurs");
            Active();
            choixRgb1.Couleur = new Rgb(118, 68, 38);
            buttonAnnule.Text = Parametres.Langues.Traduction("General", "Annule");
            buttonValide.Text = Parametres.Langues.Traduction("General", "Valide");
        }
        private void Active()
        {
            choixRgb1.CouleurChanged += ChoixRgb1_CouleurChanged;
            choixTsl1.CouleurChanged += ChoixTsl1_CouleurChanged;
            choixCmjk1.CouleurChanged += ChoixCmjk1_CouleurChanged;
        }



        private void Desactive()
        {
            choixRgb1.CouleurChanged -= ChoixRgb1_CouleurChanged;
            choixTsl1.CouleurChanged -= ChoixTsl1_CouleurChanged;
            choixCmjk1.CouleurChanged -= ChoixCmjk1_CouleurChanged;
        }
        private void ChoixCmjk1_CouleurChanged(object sender, CouleurEventArg<Cmjk> e)
        {
            if (couleur != (Rgb)e.Couleur)
            {
                OnCouleurCmjkChanged(e.Couleur);
            }
        }
        private void ChoixTsl1_CouleurChanged(object sender, CouleurEventArg<Tsl> e)
        {
            if (couleur != (Rgb)e.Couleur)
            {
                OnCouleurTslChanged(e.Couleur);
            }
        }
        private void ChoixRgb1_CouleurChanged(object sender, CouleurEventArg<Couleurs.Rgb> e)
        {
            if (couleur != e.Couleur)
            {
                OnCouleurRgbChanged(e.Couleur);
            }
        }
        private void OnCouleurRgbChanged(Rgb value)
        {
            if (couleur != value)
            {
                couleur = value;
                Desactive();
                choixTsl1.Couleur = (Tsl)couleur;
                choixCmjk1.Couleur = (Cmjk)couleur;
                Active();
            }
        }
        private void OnCouleurTslChanged(Tsl value)
        {
            if (couleur != (Rgb)value)
            {
                couleur = (Rgb)value;
                Desactive();
                choixRgb1.Couleur = couleur;
                choixCmjk1.Couleur = couleur;
                Active();
            }
        }
        private void OnCouleurCmjkChanged(Tsl value)
        {
            if (couleur != (Rgb)value)
            {
                couleur = (Rgb)value;
                Desactive();
                choixRgb1.Couleur = couleur;
                choixTsl1.Couleur = couleur;
                Active();
            }
        }
        private void ButtonAnnule_Click(object sender, EventArgs e)
        {
            Couleur = Rgb.Empty;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void ButtonValide_Click(object sender, EventArgs e)
        {
            Couleur = choixRgb1.Couleur;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
