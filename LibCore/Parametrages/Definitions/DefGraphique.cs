namespace LibCore.Parametrages.Definitions
{
    internal class DefGraphique : DefGraphiqueBase
    {
        public DefAxe Axe { get { return new DefAxe((Noeud)this["Axe"]); } }
        public DefAxe Primaire { get { return new DefAxe((Noeud)this["Primaire"]); } }
        public DefAxe Secondaire { get { return new DefAxe((Noeud)this["Secondaire"]); } }
        public DefAxe Tertiaire { get { return new DefAxe((Noeud)this["Tertiaire"]); } }

        public DefGraphique(DefPinceau zone, DefCrayon cadre, DefAxe axe, DefAxe primaire, DefAxe secondaire, DefAxe tertiaire)
                : this("Graphique", zone, cadre, axe, primaire, secondaire, tertiaire) { }
        public DefGraphique(string name, DefPinceau zone, DefCrayon cadre, DefAxe axe, DefAxe primaire, DefAxe secondaire, DefAxe tertiaire) : base(name, zone, cadre)
        {
            Add(axe);
            Add(primaire);
            Add(secondaire);
            Add(tertiaire);
        }
        public DefGraphique(Noeud noeud) : base(noeud)
        {
            if (!IsValid("Zone", "Cadre", "Axe", "Primaire", "Secondaire", "Tertiaire"))
            {
                Create();
            }
        }
        protected override void Create()
        {
            base.Create();
            Add(new DefAxe("Axe"));
            Add(new DefAxe("Primaire"));
            Add(new DefAxe("Secondaire"));
            Add(new DefAxe("Tertiaire"));
        }
    }
}
