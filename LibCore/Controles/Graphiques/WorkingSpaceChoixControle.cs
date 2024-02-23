using LibCore.Controles.Courbes;
using LibCore.Couleurs;
using LibCore.Parametrages;

using System;
using System.Drawing;

namespace LibCore.Controles.Graphiques
{
    public partial class WorkingSpaceChoixControle : CoreControle
    {

        private WorkingSpace workingSpaceSelected = null;
        private readonly CoreCourbes CourbePoint;
        private readonly CoreCourbes CourbeLigne;
        private readonly CoreCourbes CourbeRef;
        internal WorkingSpace Reference = Parametres.Couleurs.WorkingSpaceReference;
        internal WorkingSpace Seleted { get { return workingSpaceSelected; } set { OnWorkingSpaceChanged(value); } }
        public WorkingSpaceChoixControle()
        {
            InitializeComponent();
            CourbePoint = new CoreCourbes()
            {
                CourbesType = TypeCourbes.None,
                Crayon = new Pen(Color.White, 1f)
            };
            CourbeLigne = new CoreCourbes()
            {
                CourbesType = TypeCourbes.LigneFermer,
                Crayon = new Pen(Color.White, 1f) { DashPattern = new float[] { 5, 5 } }
            };
            CourbeRef = new CoreCourbes()
            {
                CourbesType = TypeCourbes.LigneFermer,
                Crayon = new Pen(Color.Gray, 1f) { DashPattern = new float[] { 2, 2 } }
            };
            graphCourbe1.AddCourbe(CourbeLigne);
            graphCourbe1.AddCourbe(CourbePoint);
            graphCourbe1.AddCourbe(CourbeRef);
            graphCourbe1.CourbesList.Toutes();
            labelRougeT.Text = Parametres.Langues.Traduction("Couleurs", "Rouge");
            labelVertT.Text = Parametres.Langues.Traduction("Couleurs", "Vert");
            labelBleuT.Text = Parametres.Langues.Traduction("Couleurs", "Bleu");
            labelGammaT.Text = Parametres.Langues.Traduction("Couleurs", "Gamma");
            labelBlancT.Text = Parametres.Langues.Traduction("Couleurs", "Illuminant");
            labelRef.Text = string.Format("{0} : {1}", Parametres.Langues.Traduction("Couleurs", "Reference"), Reference.Name);
            comboBox1.Items.AddRange(Parametres.Couleurs.WorkingSpacesKeys.ToArray());
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            workingSpaceSelected = Parametres.Couleurs.WorkingSpace((string)comboBox1.SelectedItem);
            Draw();
        }
        private void OnWorkingSpaceChanged(WorkingSpace value)
        {
            if (value.Name != workingSpaceSelected.Name)
            {
                int index = Parametres.Couleurs.WorkingSpacesKeys.IndexOf(value.Name);
                if (index != -1)
                {
                    comboBox1.SelectedIndex = index;
                }
            }
        }
        private void Draw()
        {
            if (workingSpaceSelected is null) { return; }
            labelGammaV.Text = workingSpaceSelected.Gamma.ToString();
            labelBlancV.Text = string.Format("{0}\r\n{1}", workingSpaceSelected.White, Parametres.Langues.Traduction("BlancRef", workingSpaceSelected.White));
            labelRougeV.Text = workingSpaceSelected.Red.ToString();
            labelVertV.Text = workingSpaceSelected.Green.ToString();
            labelBleuV.Text = workingSpaceSelected.Blue.ToString();
            Yxy white = Parametres.Couleurs.BlancRef(workingSpaceSelected.White);
            ///Creation des courbes Point et Ligne triangle selectionné                    
            CourbePoint.Clear();
            CourbePoint.Add(new GraphPoint((float)workingSpaceSelected.Red.X * 100, (float)workingSpaceSelected.Red.Y * 100)
            {
                Remplissage = true,
                Marqueur = TypePoint.Cercle,
                Couleur = Color.Red
            });
            CourbePoint.Add(new GraphPoint((float)workingSpaceSelected.Green.X * 100, (float)workingSpaceSelected.Green.Y * 100)
            {
                Remplissage = true,
                Marqueur = TypePoint.Cercle,
                Couleur = Color.Green
            });
            CourbePoint.Add(new GraphPoint((float)workingSpaceSelected.Blue.X * 100, (float)workingSpaceSelected.Blue.Y * 100)
            {
                Remplissage = true,
                Marqueur = TypePoint.Cercle,
                Couleur = Color.Blue
            });
            CourbePoint.Add(new GraphPoint((float)white.X * 100, (float)white.Y * 100)
            {
                Remplissage = true,
                Marqueur = TypePoint.Cercle,
                Couleur = Color.White
            });
            CourbeLigne.Clear();
            CourbeLigne.Clear();
            CourbeLigne.Add(new GraphPoint((float)workingSpaceSelected.Red.X * 100, (float)workingSpaceSelected.Red.Y * 100));
            CourbeLigne.Add(new GraphPoint((float)workingSpaceSelected.Green.X * 100, (float)workingSpaceSelected.Green.Y * 100));
            CourbeLigne.Add(new GraphPoint((float)workingSpaceSelected.Blue.X * 100, (float)workingSpaceSelected.Blue.Y * 100));
            // Affichage triangle de reference           
            if (Reference != null)
            {
                CourbeRef.Clear();
                CourbeRef.Add(new GraphPoint((float)Reference.Red.X * 100, (float)Reference.Red.Y * 100));
                CourbeRef.Add(new GraphPoint((float)Reference.Green.X * 100, (float)Reference.Green.Y * 100));
                CourbeRef.Add(new GraphPoint((float)Reference.Blue.X * 100, (float)Reference.Blue.Y * 100));


                WorkingSpaceCalcul working = new WorkingSpaceCalcul(Reference);
                panelBlanc.BackColor = working.XyzToRgb(white);
                panelRouge.BackColor = working.XyzToRgb(workingSpaceSelected.Red);
                panelVert.BackColor = working.XyzToRgb(workingSpaceSelected.Green);
                panelBleu.BackColor = working.XyzToRgb(workingSpaceSelected.Blue);
            }
            Refresh();
        }
    }
}
