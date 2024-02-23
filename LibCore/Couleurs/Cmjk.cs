using LibCore.Parametrages;

namespace LibCore.Couleurs
{
    public class Cmjk : CouleurSimple
    {
        public static implicit operator Tsl(Cmjk cmjk) { return cmjk.ToTsl(); }
        public static implicit operator Rgb(Cmjk cmjk) { return cmjk.ToRgb(); }
        public static implicit operator byte[](Cmjk cmjk) { return cmjk.ToBytes(); }
        public double Cyan { get { return valeurs[0]; } set { valeurs[0] = value; } }
        public double Magenta { get { return valeurs[1]; } set { valeurs[1] = value; } }

        public double Jaune { get { return valeurs[2]; } set { valeurs[2] = value; } }
        public double Noir { get { return valeurs[3]; } set { valeurs[3] = value; } }

        internal Cmjk() : base("Cmjk", 4) { }
        public Cmjk(double cyan, double magenta, double jaune, double noir) : this()
        {
            Cyan = cyan;
            Magenta = magenta;
            Jaune = jaune;
            Noir = noir;
        }
        internal Cmjk(Noeud noeud) : this()
        {
            if (noeud.IsValid("Cyan", "Magenta", "Jaune", "Noir"))
            {
                Name = noeud.Name;
                Cyan = noeud.GetValue<double>("Cyan");
                Magenta = noeud.GetValue<double>("Magenta");
                Jaune = noeud.GetValue<double>("Jaune");
                Noir = noeud.GetValue<double>("Noir");
            }
        }
        public Cmjk GetMagenta() { return new Cmjk(0, Magenta, 0, 0); }
        public Cmjk GetCyan() { return new Cmjk(Cyan, 0, 0, 0); }
        public Cmjk GetJaune() { return new Cmjk(0, 0, Jaune, 0); }
        protected override Cmjk ToCmjk()
        {
            return this;
        }
        protected override Rgb ToRgb()
        {
            return new Rgb((byte)(255 * (1 - Cyan) * (1 - Noir)), (byte)(255 * (1 - Magenta) * (1 - Noir)), (byte)(255 * (1 - Jaune) * (1 - Noir)));
        }
        protected override Tsl ToTsl() { return ToRgb(); }
        public override string ToString()
        {
            return string.Format("Cmjk[{0:000}-{1:000}-{2:000}-{3:000}]", (int)(Cyan * 100), (int)(Magenta * 100), (int)(Jaune * 100), (int)(Noir * 100));
        }

        public override Noeud ToNoeud()
        {
            Noeud result = new Noeud
            {
                Name = Name
            };
            result.Add("Cyan", Cyan);
            result.Add("Magenta", Magenta);
            result.Add("Jaune", Jaune);
            result.Add("Noir", Noir);
            return result;
        }
    }
}
