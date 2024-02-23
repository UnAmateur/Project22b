namespace LibCore.Parametrages.Definitions
{
    internal abstract class Definition : Noeud
    {
        protected Definition() : this("Definition") { }

        protected Definition(string name) : base(name) { }

        protected Definition(Noeud noeud) : base(noeud) { }
        internal Noeud ToNoeud() { return this; }
        protected void Default() { Create(); }
        protected abstract void Create();
    }
}
