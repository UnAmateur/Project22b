namespace LibCore.Parametrages.Definitions
{
    internal class DefGammaL : DefGammaBase
    {

        public DefGammaL() { Default(); }

        protected override void Create()
        {
            Add("Type", TypeGamma.L);
        }

        protected override double ToRgb(double value)
        {

            if (value < Parametres.Couleurs.Epsilon)
            {
                return value * Parametres.Couleurs.Kappa / 100.0;
            }
            else
            {
                return (1.16 * System.Math.Pow(value, 1 / 3.0) - 0.16);
            }
        }
        protected override double ToXyz(double value)
        {
            if (value < Parametres.Couleurs.Epsilon)
            {
                return 100.0 * value / Parametres.Couleurs.Kappa;
            }
            else
            {
                return System.Math.Pow(((value + 0.16) / 1.16), 3);
            }
        }
    }
}
