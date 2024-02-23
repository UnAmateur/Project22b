namespace LibCore.Parametrages.Definitions
{
    internal class DefGammaRgb : DefGammaBase
    {
        public DefGammaRgb() { Default(); }
        protected override double ToXyz(double value)
        {
            if (value < 0.04045)
            {
                return value / 12.92;
            }
            else
            {
                return System.Math.Pow((value + 0.055) / 1.055, 2.4);
            }
        }
        protected override double ToRgb(double value)
        {
            if (value < 0.0031308)
            {
                return value * 12.92;
            }
            else
            {
                return (System.Math.Pow(1.055 * value, 1 / 2.4) - 0.055);
            }

        }

        protected override void Create()
        {
            Clear();
            Add("Type", TypeGamma.sRGB);
        }
    }
}
