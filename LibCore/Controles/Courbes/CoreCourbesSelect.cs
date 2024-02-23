using System;
using System.Drawing;

namespace LibCore.Controles.Courbes
{
    internal class CoreCourbesSelect : CoreCourbesList
    {
        public event EventHandler IndexChanged;
        private const int AucuneCourbes = -2;
        private int indexCourant = AucuneCourbes;
        private bool CourantIsNull { get { return indexCourant == -2; } }
        public CoreCourbesSelect() : this("CoreCourbesSelect") { }
        public CoreCourbesSelect(string name) : base(name) { }
        public void Aucune()
        {
            indexCourant = -2;
            OnIndexChanged();
        }
        protected override void OnListChanged()
        {
            base.OnListChanged();
            indexCourant = Count - 1;
        }
        public void Avance()
        {
            if (indexCourant == AucuneCourbes & Count != 0) { indexCourant = 0; }
            if (indexCourant + 1 < Count)
            { indexCourant++; }
            else { indexCourant = 0; }
            OnIndexChanged();
        }
        public void Recule()
        {
            if (indexCourant == AucuneCourbes & Count != 0) { indexCourant = 0; }
            if (indexCourant - 1 > -1) { indexCourant--; }
            else { indexCourant = Count - 1; }
            OnIndexChanged();
        }
        public void Debut()
        {
            if (Count > 0)
            {
                indexCourant = 0;
                OnIndexChanged();
            }
        }
        public void Fin()
        {
            if (Count > 0)
            {
                indexCourant = Count - 1;
                OnIndexChanged();
            }
        }
        public void Toutes()
        {
            if (Count != 0)
            {
                indexCourant = -1;
                OnIndexChanged();
            }
        }
        public void Draw(Graphics g, CalculGraphique calcul)
        {
            if (indexCourant == -2) { return; }
            else if (indexCourant == -1)
            {
                for (int index = 0; index < Count; index++)
                {
                    if (this[index] != null)
                    {
                        this[index].Draw(g, calcul);
                    }
                }
            }
            else
            {
                if (CourantIsNull) { return; }
                this[indexCourant].Draw(g, calcul);
            }
        }
        protected virtual void OnIndexChanged()
        {
            IndexChanged?.Invoke(this, null);
        }
    }
}