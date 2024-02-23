using LibCore.Controles.Courbes;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibCore.Controles.Graphiques
{
    internal partial class GraphCourbe : GraphBase
    {
        private readonly CoreCourbesSelect _courbesList;
        public CoreCourbesSelect CourbesList { get { return _courbesList; } }
        public GraphCourbe() : this("Default")
        {


        }
        public GraphCourbe(string nameTheme) : base(nameTheme)
        {
            InitializeComponent();
            _courbesList = new CoreCourbesSelect();
            _courbesList.IndexChanged += CourbesList_IndexChanged;
            _courbesList.ListeChanged += CourbesList_ListeChanged;
        }

        private void CourbesList_ListeChanged(object sender, EventArgs e) { Refresh(); }

        private void CourbesList_IndexChanged(object sender, EventArgs e) { Refresh(); }
        public void AddCourbe(CoreCourbes courbes) { _courbesList.Add(courbes); }
        public void AddCourbes(List<GraphPoint> graphpoints)
        {
            CoreCourbes courbe = new CoreCourbes();
            courbe.AddRange(graphpoints);
            _courbesList.Add(courbe);
        }
        public void Clear() { _courbesList.Clear(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _courbesList.Draw(e.Graphics, ValeurToGraph);
        }
    }
}
