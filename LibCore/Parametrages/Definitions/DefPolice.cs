using System;
using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal sealed class DefPolice : Definition
    {
        public static implicit operator Font(DefPolice defPolice) { return defPolice.ToFont(); }

        public DefPolice() : this("Police") { }
        public DefPolice(string name) : this(name, "Arial", 10f, FontStyle.Regular) { }
        public DefPolice(string nameFont, float sizeFont, FontStyle styleFont) : this("Police", nameFont, sizeFont, styleFont) { }
        public DefPolice(string name, string nameFont, float sizeFont, FontStyle styleFont) : base(name)
        {
            Add("Taille", sizeFont);
            Add("Style", styleFont);
            Add("Fonte", nameFont);
        }
        public DefPolice(Noeud noeud) : base(noeud)
        {
            if (!noeud.IsValid("Taille", "Style", "Fonte")) { Create(); }
        }
        public Font ToFont() { return new Font(GetValue<string>("Fonte"), GetValue<float>("Taille"), GetValue<FontStyle>(ConvertStyle, "Style")); }
        private FontStyle ConvertStyle(object value)
        {
            if (value == null) { return FontStyle.Regular; }
            else
            {
                if (Enum.TryParse<FontStyle>(value.ToString(), false, out FontStyle style))
                {
                    return style;
                }
                else { return FontStyle.Regular; }
            }
        }
        protected override void Create()
        {
            Clear();
            Add("Taille", 10f);
            Add("Style", FontStyle.Regular);
            Add("Fonte", "Arial");
        }
    }

}
