using LibCore.Parametrages;

namespace LibCore.Couleurs
{
    internal class Lab : CouleurComplexe
    {
        public double L
        {
            get { return valeurs[0]; }
            set { valeurs[0] = value; }
        }
        public double A
        {
            get { return valeurs[1]; }
            set { valeurs[1] = value; }
        }
        public double B
        {
            get { return valeurs[2]; }
            set { valeurs[2] = value; }
        }
        protected Lab(int nb) : this("Lab", nb) { }
        protected Lab(string name, int nb) : base(name, nb) { }
        internal Lab(double l, double a, double b) : this("Lab", 3) { L = l; A = a; B = b; }
        internal Lab(string name, double l, double a, double b) : this(name, 3) { L = l; A = a; B = b; }
        internal Lab(Noeud noeud) : base(3)
        {
            if (noeud.IsValid("L", "A", "B"))
            {
                Name = noeud.Name;
                L = noeud.GetValue<double>("L");
                A = noeud.GetValue<double>("A");
                B = noeud.GetValue<double>("B");
            }
        }
        public override Noeud ToNoeud()
        {
            Noeud noeud = new Noeud { Name = Name };
            noeud.Add("L", L);
            noeud.Add("a", A);
            noeud.Add("b", B);
            return noeud;
        }
        public override string ToString()
        {
            return string.Format("Lab <{0,4:N0}|{1,4:N0}|{2,4:N0}>", L, A, B);
        }
    }
}
