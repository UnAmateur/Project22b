using LibCore.Couleurs;
using LibCore.Parametrages;

using System;
using System.Windows.Forms;

namespace LibCore.Formulaires
{
    internal partial class ChoixWorkingSpace : CoreFormes
    {
        private WorkingSpace espace;
        public WorkingSpace Espace { get { return espace; } set { OnEspaceCahnged(value); } }



        public ChoixWorkingSpace()
        {
            InitializeComponent();
            Text = Parametres.Langues.Traduction("Formulaires", "Choix workingspace");
            buttonAnnule.Text = Parametres.Langues.Traduction("General", "Annule");
            buttonValide.Text = Parametres.Langues.Traduction("General", "Valide");
        }
        private void OnEspaceCahnged(WorkingSpace value)
        {
            throw new NotImplementedException();
        }
        private void ButtonAnnule_Click(object sender, EventArgs e)
        {
            espace = Parametres.Couleurs.WorkingSpaceReference;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonValide_Click(object sender, EventArgs e)
        {
            espace = workingSpaceChoixControle1.Seleted;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
