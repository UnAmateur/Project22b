using System;
using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefCurseur : DefCouleur
    {
        public SizeF Taille { get { return new DefPoint((Noeud)this["Taille"]); } set { this["Taille"] = (DefPoint)value; } }
        public TypeCurseur Style
        {
            get { return GetValue<TypeCurseur>(ConvertTo, "Style"); }
            set { this["Style"] = value.ToString(); }
        }
        public Color Couleur { get { return base.ToColor(); } }
        internal DefCurseur() : this("Curseur", 10f, 10f, Color.White, TypeCurseur.Rond) { }
        internal DefCurseur(Size dimension, Color couleur, TypeCurseur style) : this("Curseur", dimension, couleur, style) { }
        internal DefCurseur(SizeF dimension, Color couleur, TypeCurseur style) : this("Curseur", dimension, couleur, style) { }
        internal DefCurseur(string name, SizeF dim, Color couleur, TypeCurseur style) : this(name, dim.Width, dim.Height, couleur, style) { }
        internal DefCurseur(string name, Size dim, Color couleur, TypeCurseur style) : this(name, dim.Width, dim.Height, couleur, style) { }
        internal DefCurseur(string name, float dimX, float dimY, Color couleur, TypeCurseur style) : base(name, couleur.R, couleur.G, couleur.B)
        {
            Add(new DefPoint("Taille", dimX, dimY)); ;
            Add("Style", TypeCurseur.Rond);
            Style = style;
        }
        internal DefCurseur(Noeud noeud) : base(noeud)
        {
            if (noeud.IsValid("Taille", "Style"))
            {
                Taille = new DefPoint((Noeud)this["Taille"]);
                Style = noeud.GetValue(ConvertTo, "Style");
            }
        }
        private TypeCurseur ConvertTo(object value)
        {
            if (value != null)
            {
                if (Enum.TryParse<TypeCurseur>(value.ToString(), out TypeCurseur result))
                {
                    return result;
                }
                else { return TypeCurseur.None; }
            }
            return TypeCurseur.None;
        }
        protected override void Create()
        {
            base.Create();
            Add("Taille", 10f);
            Add("Style", TypeCurseur.Rond);
        }
    }
}
