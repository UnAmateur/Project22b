using LibMath;

using System;

namespace LibCore.Parametrages.Definitions
{
    internal abstract class DefGammaBase : Definition
    {
        public TypeGamma Type
        {
            get
            {
                return GetValue(ConvertStyle, "Type");
            }
            protected set
            {
                this["Type"] = value;
            }
        }
        public double Valeur
        {
            get
            {
                if (Keys.Contains("Valeur")) { return GetValue<double>("Valeur"); } else { return double.NaN; }
            }
            protected set
            {
                if (Keys.Contains("Valeur")) { this["Valeur"] = value; }
            }
        }
        public DefGammaBase() : base("Gamma") { }
        public Matrice RgbToXYZ(Matrice value)
        {
            value[0, 0] = ToXyz(Fonctions.Clamp(value[0, 0] / 255.0, 0, 1));
            value[0, 1] = ToXyz(Fonctions.Clamp(value[0, 1] / 255.0, 0, 1));
            value[0, 2] = ToXyz(Fonctions.Clamp(value[0, 2] / 250.0, 0, 1));
            return value;
        }
        public Matrice XyzToRgb(Matrice value)
        {
            value[0, 0] = Fonctions.Clamp(ToRgb(value[0, 0]) * 255.0, 0, 255.0);
            value[0, 1] = Fonctions.Clamp(ToRgb(value[0, 1]) * 255.0, 0, 255.0);
            value[0, 2] = Fonctions.Clamp(ToRgb(value[0, 2]) * 255.0, 0, 255.0);
            return value;
        }
        protected virtual double ToRgb(double value) { return value; }
        protected virtual double ToXyz(double value) { return value; }
        public override string ToString()
        {
            if (double.IsNaN(Valeur))
            {
                return Type.ToString();
            }
            else
            {
                return Valeur.ToString();
            }
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
