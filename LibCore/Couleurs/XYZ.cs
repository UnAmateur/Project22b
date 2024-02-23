using LibCore.Parametrages;

namespace LibCore.Couleurs
{
    internal class XYZ : CouleurComplexe
    {
        public static implicit operator Yxy(XYZ value) { return value.ToxyY(); }

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
        public double Z
        {
            get { return valeurs[2]; }
            set { valeurs[2] = value; }
        }
        protected XYZ(string name) : base(name, 3) { }
        internal XYZ() : this("XYZ") { }
        internal XYZ(double x, double y, double z) : this() { X = x; Y = y; Z = z; }
        internal XYZ(string name, double x, double y, double z) : this(name) { X = x; Y = y; Z = z; }
        internal XYZ(Noeud noeud) : this(noeud.Name)
        {
            if (noeud.IsValid("X", "Y", "Z"))
            {
                X = noeud.GetValue<double>("X");
                Y = noeud.GetValue<double>("Y");
                Z = noeud.GetValue<double>("Z");
            }
        }
        public override Noeud ToNoeud()
        {
            Noeud noeud = new Noeud { Name = Name };
            noeud.Add("X", X);
            noeud.Add("Y", Y);
            noeud.Add("Z", Z);
            return noeud;
        }

        public Yxy ToxyY()
        {
            double k = X + Y + Z;
            double Xa = Y == 0 ? X : X / k;
            double Ya = Y == 0 ? Y : Y / k;
            if (Name == "XYZ") { return new Yxy("xyY", Xa, Ya, Y); }
            else { return new Yxy(Name, Xa, Ya, Y); }
        }
        public override string ToString()
        {
            return string.Format("XYZ <{0,8:N6}|{1,8:N6}|{2,8:N6}>", X, Y, Z);
        }
    }

}
