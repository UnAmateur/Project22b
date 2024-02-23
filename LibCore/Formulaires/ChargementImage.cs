using LibCore.Couleurs;
using LibCore.Parametrages;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibCore.Formulaires
{
    public partial class ChargementImage : CoreFormes
    {
        private readonly WorkingSpace espace;
        public ChargementImage()
        {
            ChoixWorkingSpace cw = new ChoixWorkingSpace();
            if (cw.ShowDialog() == DialogResult.OK)
            {
                espace = cw.Espace;
            }
            else
            {
                espace = Parametres.Couleurs.WorkingSpaceReference;
            }
            InitializeComponent();
        }
    }
}
