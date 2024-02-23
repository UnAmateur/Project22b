using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefPinceau : DefCouleur
    {
        public static implicit operator Brush(DefPinceau defPinceau) { return defPinceau.ToBrush(); }
        public static implicit operator DefPinceau(Color color) { return new DefPinceau(color); }
        public DefPinceau() : this("Pinceau") { }

        public DefPinceau(string name) : this(name, 0, 0, 0) { }

        public DefPinceau(double rouge, double vert, double bleu) : this("Pinceau", rouge, vert, bleu) { }

        public DefPinceau(string name, double rouge, double vert, double bleu) : base(name, rouge, vert, bleu) { }
        public DefPinceau(Color couleur) : this("Pinceau", couleur.R, couleur.G, couleur.B) { }
        public DefPinceau(Noeud noeud) : base(noeud) { }
        public Brush ToBrush() { return new SolidBrush(ToColor()); }
        protected override void Create()
        {
            base.Create();
        }
    }

}
