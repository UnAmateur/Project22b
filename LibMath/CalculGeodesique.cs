namespace LibMath
{
    internal static class CalculGeodesique
    {
        #region Geodesique
        /// <summary>
        /// Calcule la distance entre deux points geodesiques
        /// </summary>
        /// <param name="latitudeA">DMS ou decimal</param>
        /// <param name="longitudeA">DMS ou decimal</param>
        /// <param name="latitudeB">DMS ou decimal</param>
        /// <param name="longitudeB">DMS ou decimal</param>
        /// <param name="espace">TRUE : DMS separé par un espace</param>
        /// <returns></returns>
        public static decimal Geodesique(string latitudeA, string longitudeA, string latitudeB, string longitudeB, bool espace)
        {
            var la_A = Convertisseur.DmsToDec(latitudeA, espace);
            var lo_A = Convertisseur.DmsToDec(longitudeA, espace);
            var la_B = Convertisseur.DmsToDec(latitudeB, espace);
            var lo_B = Convertisseur.DmsToDec(longitudeB, espace);
            var SinA = DecimalMath.Sin(la_A * DecimalMath.Pi / 180m);
            var SinB = DecimalMath.Sin(la_B * DecimalMath.Pi / 180m);
            var CosA = DecimalMath.Cos(la_A * DecimalMath.Pi / 180m);
            var CosB = DecimalMath.Cos(la_B * DecimalMath.Pi / 180m);
            var d = (lo_B * DecimalMath.Pi / 180m) - (lo_A * DecimalMath.Pi / 180m);
            var CosD = DecimalMath.Cos(d);
            return 6378137 * DecimalMath.Acos(SinA * SinB + CosA * CosB * CosD);
        }
        public static decimal Geodesique(decimal latitudeA, decimal longitudeA, decimal latitudeB, decimal longitudeB)
        {
            var SinA = DecimalMath.Sin(latitudeA * DecimalMath.Pi / 180m);
            var SinB = DecimalMath.Sin(latitudeB * DecimalMath.Pi / 180m);
            var CosA = DecimalMath.Cos(latitudeA * DecimalMath.Pi / 180m);
            var CosB = DecimalMath.Cos(latitudeB * DecimalMath.Pi / 180m);
            var d = (longitudeB * DecimalMath.Pi / 180m) - (longitudeA * DecimalMath.Pi / 180m);
            var CosD = DecimalMath.Cos(d);
            return 6378137 * DecimalMath.Acos(SinA * SinB + CosA * CosB * CosD);
        }
        #endregion
    }
}
