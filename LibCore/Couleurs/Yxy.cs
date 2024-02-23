using LibCore.Parametrages;

namespace LibCore.Couleurs
{
    internal class Yxy : CouleurComplexe
    {
        public static implicit operator XYZ(Yxy value) { return value.ToXYZ(); }
        public double X
        {
            get { return valeurs[0]; }
            set { valeurs[0] = value; }
        }
        public double Y
        {
            get { return valeurs[1]; }
            set { valeurs[1] = value; }
        }
        public double Yy
        {
            get { return valeurs[2]; }
            set { valeurs[2] = value; }
        }

        protected Yxy(string name) : base(name, 3) { }
        internal Yxy() : base("xyY", 3) { }
        internal Yxy(double x, double y, double yy) : this() { X = x; Y = y; Yy = yy; }
        internal Yxy(string name, double x, double y, double yy) : this(name) { X = x; Y = y; Yy = yy; }
        internal Yxy(Noeud noeud) : this(noeud.Name)
        {
            if (noeud.IsValid("x", "y", "Y"))
            {
                X = noeud.GetValue<double>("x");
                Y = noeud.GetValue<double>("y");
                Yy = noeud.GetValue<double>("Y");
            }
        }
        public override Noeud ToNoeud()
        {
            Noeud noeud = new Noeud { Name = Name };
            noeud.Add("x", X);
            noeud.Add("y", Y);
            noeud.Add("Y", Yy);
            return noeud;
        }
        public XYZ ToXYZ()
        {
            double Xa;
            double Ya;
            double Za;
            if (Y != 0)
            {
                Za = (1 - X - Y) * Yy / Y;
                Ya = Yy;
                Xa = X * Yy / Y;
            }
            else
            {
                Za = (1 - X - Y);
                Ya = Yy;
                Xa = X;
            }
            if (Name == "xyY") { return new XYZ("XYZ", Xa, Ya, Za); }
            else { return new XYZ(Name, Xa, Ya, Za); }
        }
        public override string ToString()
        {
            return string.Format("xyY <{0,8:N6}|{1,8:N6}|{2,8:N6}>", X, Y, Yy);
        }
    }
}
