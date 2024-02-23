using System;
using System.Globalization;

namespace LibMath
{
    public static class Convertisseur
    {
        static public double RadToDrg(double value) { return value * 180.0 / System.Math.PI; }
        static public double RadToGrd(double value) { return value * 200.0 / System.Math.PI; }
        static public double DrgToRad(double value) { return value * System.Math.PI / 180.0; }
        static public double GrdToRad(double value) { return value * System.Math.PI / 200.0; }
        public static string ToTime(long time)
        {
            double ms = time % 1000;
            double k = time / 1000;
            double s = k % 60;
            k = System.Math.Truncate(k / 60);
            double m = k % 60;
            k = System.Math.Truncate(k / 60);
            double h = k % 60;
            if (h == 0)
            {
                if (m == 0)
                {
                    if (s == 0)
                    {
                        return string.Format("{0:000} ms", ms);
                    }
                    else
                    {
                        return string.Format("{0:00} s {1:000} ms", s, ms);
                    }
                }
                else
                {
                    return string.Format("{0:00} mn {1:00} s {2:000}", m, s, ms);
                }
            }
            else
            {
                return string.Format("{0:00} h {1:00} mn {2:00} s {3:000}", h, m, s, ms);
            }
        }

        #region Nombre en 'Oc,Ko,Mo,Go,To'
        static public string ToOctets(long value, int dec)
        {
            string result;
            if (value / 1024.00 < 1) { result = string.Format(CultureInfo.CurrentCulture, "{0:N" + dec.ToString(CultureInfo.CurrentCulture) + "} O ", value); }
            else if (value / (1024.0 * 1024.0) < 1) { result = string.Format(CultureInfo.CurrentCulture, "{0:N" + dec.ToString(CultureInfo.CurrentCulture) + "} Ko", value / 1024.0); }
            else if (value / (1024.0 * 1024.0 * 1024.0) < 1) { result = string.Format(CultureInfo.CurrentCulture, "{0:N" + dec.ToString(CultureInfo.CurrentCulture) + "} Mo", value / 1024.0 / 1024.0); }
            else if (value / (1024.0 * 1024.0 * 1024.0 * 1024.0) < 1) { result = string.Format(CultureInfo.CurrentCulture, "{0:N" + dec.ToString(CultureInfo.CurrentCulture) + "} Go", value / 1024.0 / 1024.0 / 1024.0); }
            else if (value / (1024.0 * 1024.0 * 1024.0 * 1024.0 * 1024.0) < 1) { result = string.Format(CultureInfo.CurrentCulture, "{0:N" + dec.ToString(CultureInfo.CurrentCulture) + "} To", value / 1024.0 / 1024.0 / 1024.0 / 1024.0); }
            else { result = string.Format(CultureInfo.CurrentCulture, "{0:N" + dec.ToString(CultureInfo.CurrentCulture) + "} Po", value / 1024.0 / 1024.0 / 1024.0 / 1024.0 / 1024.0); }
            return result;
        }
        #endregion

        #region DmsToDec
        /// <summary>
        /// Transforme un chaine au format DMS en decimal
        /// </summary>
        /// <param name="value">chaine à convertir</param>
        /// <param name="espace">TRUE : les chiffres sont séparés par un espace sinon format xx°xx'xx" </param>
        /// <returns></returns>
        public static decimal DmsToDec(string value, bool espace)
        {
            if (string.IsNullOrEmpty(value)) { throw new ArgumentException("Chaine vide ou nulle"); }
            string[] t;
            if (espace) { t = value.Split(' '); } else { t = value.Split('°', '\'', '\"'); }
            if (t.Length == 0) { return 0m; }
            if (decimal.TryParse(t[0], out decimal d))
            {

                if (t.Length > 1)
                {
                    if (decimal.TryParse(t[1], out decimal m))
                    {
                        if (t.Length > 2)
                        {
                            if (decimal.TryParse(t[2], out decimal s))
                            {
                                return d < 0 ? -(-d + m / 60m + s / 3600m) : d + m / 60m + s / 3600m;
                            }
                            else { return d < 0 ? -(-d + m / 60m) : d + m / 60m; }
                        }
                        else { return d < 0 ? -(-d + m / 60m) : d + m / 60m; }
                    }
                    else { return d; }
                }
                else { return d; }
            }
            else { return 0m; }
        }
        #endregion

        #region HexToInt
        /// <summary>
        /// Convertir une chaine HEX en INT.
        /// </summary>
        /// <param name="value">chaine à convertir. </param>
        /// <param name="result">resultat si la fonction retourne true sinon INT.MAXVALUE. </param>
        /// <returns>True si la trasformation à reussi. </returns>

        public static bool HexToInt(string value, out int result)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (value.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase))
                {
                    value = value.Substring(2);
                    try
                    {
                        result = int.Parse(value, NumberStyles.HexNumber, CultureInfo.CurrentCulture);
                        return true;
                    }
                    catch (Exception)
                    {
                        result = int.MaxValue;
                        return false;
                    }
                }
            }
            result = int.MaxValue;
            return false;
        }
        #endregion

    }
}
