using LibCore.Parametrages;
using LibCore.Parametrages.Definitions;

namespace LibCore.Couleurs
{
    internal class WorkingSpace : Core
    {
        public static implicit operator Noeud(WorkingSpace space) { return space?.ToNoeud(); }
        public DefGamma Gamma { get; private set; }
        public Yxy Red { get; private set; }
        public Yxy Green { get; private set; }
        public Yxy Blue { get; private set; }
        public string White { get; private set; }

        public WorkingSpace() : base() { }
        public WorkingSpace(string name, Yxy red, Yxy green, Yxy blue, string white, TypeGamma gamma, double gammaValeur = double.NaN) : base(name)
        {
            Gamma = new DefGamma(gamma, gammaValeur);
            Red = red; Red.Name = "Rouge";
            Green = green; Green.Name = "Vert";
            Blue = blue; Blue.Name = "Bleu";
            White = white;
        }
        public WorkingSpace(Noeud noeud) : base(noeud.Name)
        {
            if (noeud.IsValid("Gamma", "Rouge", "Vert", "Bleu", "BlancRef"))
            {
                Gamma = new DefGamma((Noeud)noeud["Gamma"]);
                Red = new Yxy((Noeud)noeud["Rouge"]);
                Green = new Yxy((Noeud)noeud["Vert"]);
                Blue = new Yxy((Noeud)noeud["Bleu"]);
                White = noeud.GetValue<string>("BlancRef");
                Name = noeud.Name;
            }
        }
        public Noeud ToNoeud()
        {
            Noeud noeud = new Noeud() { Name = Name };
            noeud.Add(Gamma);
            noeud.Add(Red);
            noeud.Add(Green);
            noeud.Add(Blue);
            noeud.Add("BlancRef", White);
            return noeud;
        }


        public override string ToString()
        {
            return string.Format("Working Space : {0}\r\n\t{1}\r\n\tBlanc de Reference : {2}\r\n\t{3}\r\n\t{4}\r\n\t{5}", Name, Gamma, White, Red, Green, Blue);
        }
    }
}
