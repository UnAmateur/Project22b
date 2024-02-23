using LibCore.Formulaires;

using System.Windows.Forms;

namespace TestWindow
{
    public partial class Form1 : CoreFormes
    {
        public Form1() : base()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            ChoixCouleurs cc = new ChoixCouleurs();
            if (cc.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Valider " + cc.Couleur.ToString();
            }
            else
            {
                label1.Text = "Annuler " + cc.Couleur.ToString();
            }
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            ChargementImage ci = new ChargementImage();
        }
    }
}
