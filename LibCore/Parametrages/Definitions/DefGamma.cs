using LibCore.Couleurs;

using LibMath;

using System;

namespace LibCore.Parametrages.Definitions
{
    internal class DefGamma : Core
    {
        public static implicit operator Noeud(DefGamma value) { return value?.ToNoeud(); }
        public static implicit operator DefGamma(Noeud value) { return value is null ? null : new DefGamma(value); }
        private DefGammaBase _base;
        public double Valeur { get { return _base.Valeur; } }
        public TypeGamma Type { get { return _base.Type; } }
        public DefGamma(TypeGamma typeGamma, double valeur = double.NaN) : base("Gamma")
        {
            Create(typeGamma, valeur);
        }
        internal DefGamma(Noeud noeud) : base(noeud is null ? "Gamma" : noeud.Name)
        {
            if (noeud.IsValid("Type"))
            {
                TypeGamma type = noeud.GetValue(ConvertStyle, "Type");
                double valeur = double.NaN;
                if (noeud.Keys.Contains("Valeur"))
                {
                    valeur = noeud.GetValue<double>("Valeur");
                }
                Create(type, valeur);
            }
        }
        private void Create(TypeGamma type, double valeur)
        {
            switch (type)
            {
                case TypeGamma.Valeur:
                    _base = new DefGammaValeur(valeur);
                    break;
                case TypeGamma.sRGB:
                    _base = new DefGammaRgb();
                    break;
                case TypeGamma.L:
                    _base = new DefGammaL();
                    break;
                default:
                    _base = null;
                    break;
            }
        }
        public Noeud ToNoeud() { return _base; }
        public Rgb XyzToRgb(Matrice matrice) { return new Rgb(_base.XyzToRgb(matrice)); }
        public Matrice RgbToXyz(Rgb rgb) { return _base.RgbToXYZ(rgb); }
        public override string ToString()
        {
            return _base.ToString();
        }
        private TypeGamma ConvertStyle(object value)
        {
            if (value == null) { return TypeGamma.Valeur; }
            else
            {
                if (Enum.TryParse<TypeGamma>(value.ToString(), false, out TypeGamma style))
                {
                    return style;
                }
                else { return TypeGamma.Valeur; }
            }
        }

    }
}
