using LibCore.Couleurs;

namespace LibCore.Controles
{
    internal partial class ChoixTsl : CoreChoix<Tsl>
    {
        public ChoixTsl()
        {
            InitializeComponent();
            graphTsl1.Changed += TslChanged;
            graphGradientLum.Changed += TslChanged;
            graphGradientSat.Changed += TslChanged;
            Couleur = new Tsl(180, 0.5, 0.5);
        }

        private void TslChanged(object sender, Donnees.ValeurEventArgs e)
        {
            ChangeCouleur();
        }

        protected override void OnCouleurChanged(Tsl value)
        {
            if (value is null) { return; }
            if (Couleur != value)
            {
                graphGradientSat.ValeurX = (float)value.Saturation * 100.0f;
                graphGradientLum.ValeurX = (float)value.Lumiere * 100.0f;
                graphTsl1.ValeurX = (float)value.Teinte;
                PutCouleur(value);
                ChangeCouleur();
            }
        }
        private void ChangeCouleur()
        {
            Tsl value = new Tsl
            {
                Teinte = graphTsl1.ValeurX,
                Saturation = graphGradientSat.ValeurX / 100.0f,
                Lumiere = graphGradientLum.ValeurX / 100.0f
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
