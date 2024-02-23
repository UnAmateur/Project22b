using LibCore.Parametrages;

using System.ComponentModel;
using System.Windows.Forms;

namespace LibCore.Controles
{
    public partial class CoreControle : UserControl
    {
        protected string nameTheme = string.Empty;
        [Category("Theme")]
        public string NameTheme { get { return nameTheme; } set { OnNameThemeChanged(value); } }
        public CoreControle() : this("Default") { }
        public CoreControle(string nametheme)
        {
            nameTheme = nametheme;
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Parametres.Themes.Fond;
            ForeColor = Parametres.Themes.Texte;
            Font = Parametres.Themes.Police;
            Verification();
            ControlAdded += CoreControle_ControlAdded;
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

        private void CoreControle_ControlAdded(object sender, ControlEventArgs e)
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
        internal float GetBordure
        {
            get
            {
                switch (BorderStyle)
                {
                    case BorderStyle.None:
                        return 0;
                    case BorderStyle.FixedSingle:
                        return 2;
                    case BorderStyle.Fixed3D:
                        return 4;
                    default:
                        return 0;
                }
            }
        }
    }
}
