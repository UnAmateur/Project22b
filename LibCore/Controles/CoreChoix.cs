using System;

namespace LibCore.Controles
{
    internal partial class CoreChoix<T> : CoreControle
    {
        public event EventHandler<CouleurEventArg<T>> CouleurChanged;
        private T couleur = default;
        public T Couleur { get { return couleur; } set { OnCouleurChanged(value); } }
        public CoreChoix()
        {
            InitializeComponent();
        }
        protected void PutCouleur(T value) { couleur = value; }
        protected virtual void OnCouleurChanged(T value) { }
        protected void OnCouleurChanged()
        {
            CouleurChanged?.Invoke(this, new CouleurEventArg<T>(couleur));
        }
    }
}
