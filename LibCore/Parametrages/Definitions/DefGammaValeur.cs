using System;

namespace LibCore.Parametrages.Definitions
{
    internal class DefGammaValeur : DefGammaBase
    {
        public DefGammaValeur(double valeur)
        {
            Default();
            Valeur = valeur;
        }


        protected override void Create()
        {
            Add("Type", TypeGamma.Valeur);
            Add("Valeur", Valeur);
        }

        protected override double ToRgb(double value)
        {
            double k = Math.Sign(value);
            return k * Math.Pow(Math.Abs(value), 1.0 / Valeur);
        }
        protected override double ToXyz(double value)
        {
            return Math.Pow(value, Valeur);
        }
    }
}
