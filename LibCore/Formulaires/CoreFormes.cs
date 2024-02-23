using LibCore.Parametrages;

using System.ComponentModel;
using System.Windows.Forms;

namespace LibCore.Formulaires
{
    public partial class CoreFormes : Form
    {
        protected string nameTheme = string.Empty;
        [Category("Theme")]
        public string NameTheme { get { return nameTheme; } set { OnNameThemeChanged(value); } }
        public CoreFormes() : this("Default")
        {
        }
        public CoreFormes(string nametheme)
        {
            nameTheme = nametheme;
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Parametres.Themes.Fond;
            ForeColor = Parametres.Themes.Texte;
            Font = Parametres.Themes.Police;
            Verification();
            ControlAdded += CoreFormes_ControlAdded;
        }
        private void Verification()
        {
            foreach (Control c in Controls)
            {
                c.BackColor = Parametres.Themes.Fond;
                c.ForeColor = Parametres.Themes.Texte;
                c.Font = Parametres.Themes.Police;
            }
        }


        private void CoreFormes_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.BackColor = Parametres.Themes.Fond;
            e.Control.ForeColor = Parametres.Themes.Texte;
            e.Control.Font = Parametres.Themes.Police;
        }
        private void OnNameThemeChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value != nameTheme)
                {
                    nameTheme = value;
                    OnThemeChanged();
                }
            }
        }
        protected virtual void OnThemeChanged() { Refresh(); }
    }
}
