using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefCouleur : Definition
    {
        public static implicit operator Color(DefCouleur defCouleur) { return defCouleur.ToColor(); }
        public static implicit operator DefCouleur(Color color) { return new DefCouleur(color.R, color.G, color.B); }

        public double Rouge { get { return GetValue<double>("Rouge"); } set { this["Rouge"] = value; } }
        public double Vert { get { return GetValue<double>("Vert"); } set { this["Vert"] = value; } }
        public double Bleu { get { return GetValue<double>("Bleu"); } set { this["Bleu"] = value; } }
        public DefCouleur() : this("Couleur") { }
        public DefCouleur(string name) : this(name, 0, 0, 0) { }
        public DefCouleur(double rouge, double vert, double bleu) : this("Couleur", rouge, vert, bleu) { }
        public DefCouleur(string name, double rouge, double vert, double bleu) : base(name)
        {
            Add("Rouge", rouge);
            Add("Vert", vert);
            Add("Bleu", bleu);
        }
        public DefCouleur(Noeud noeud) : base(noeud)
        {
            if (!noeud.IsValid("Rouge", "Vert", "Bleu"))
            {
                Default();
            }
        }
        public Color ToColor() { return Color.FromArgb((int)GetValue<double>("Rouge"), (int)GetValue<double>("Vert"), (int)GetValue<double>("Bleu")); }

        protected override void Create()
        {
            Clear();
            Add("Rouge", 0);
            Add("Vert", 0);
            Add("Bleu", 0);
        }
    }
}
