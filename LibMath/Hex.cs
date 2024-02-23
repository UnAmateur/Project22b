using System;
using System.Drawing;
using System.Globalization;

namespace LibMath
{

    public class Hex : IEquatable<Hex>
    {
        public static implicit operator Hex(string tmp) { return FromToString(tmp); }
        public static implicit operator Hex(Color tmp) { return FromColor(tmp); }
        public static implicit operator string(Hex tmp) { return tmp.ToString(); }
        public static implicit operator Color(Hex tmp) { return tmp.ToColor(); }
        public static Hex FromToString(string tmp) { return new Hex(tmp); }
        private readonly string Valeur;
        /// <summary>
        /// Creation d'un HEX à partir d'un entier strictement positif
        /// </summary>
        /// <param name="value">valeur à convertir</param>
        public Hex(uint value) { Valeur = value.ToString("X8"); }
        public Hex(int value) { Valeur = value.ToString("X8"); }
        /// <summary>
        /// Creation d'un HEX a partir d'une chaine de caractere
        /// - Elle doit commencer par "0x"
        /// - Si elle fait plus de 10 caracteres de long seul sont considérés les 8 derniers
        /// </summary>
        /// <param name="value">chaine à convertir</param>
        public Hex(string value)
        {
            if (string.IsNullOrEmpty(value)) { return; }
            if (value.StartsWith("0x", false, CultureInfo.CurrentCulture))
            {
                Valeur = value.Substring(2);
                if (Valeur.Length < 8) { Valeur = Valeur.PadLeft(8, '0'); }
                if (Valeur.Length > 8) { Valeur = Valeur.Substring(Valeur.Length - 8); }
                if (Valeur.Length < 8) { throw new ArgumentException(); }
            }
            else
            {
                Valeur = "00000000";
            }
        }
        /// <summary>
        /// Valeur maximum 0x7FFFFFFF
        /// </summary>
        public static Hex MaxValue { get { return new Hex("0x7FFFFFFF"); } }
        /// <summary>
        /// Valeur minimale 0xFFFFFFFF
        /// </summary>
        public static Hex MinValue { get { return new Hex("0xFFFFFFFF"); } }
        public override string ToString() { return "0x" + Valeur; }

        public static Hex FromColor(Color value) { return new Hex("0x" + value.ToArgb().ToString("X8")); }

        public Color ToColor()
        {
            if (Valeur == null) { return Color.Transparent; }
            int value = int.Parse(Valeur, NumberStyles.HexNumber);
            return Color.FromArgb(value);
        }

        public override bool Equals(object obj)
        {
            if ((obj is Hex other))
            {
                if (other.Valeur == Valeur) { return true; }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + Valeur.GetHashCode();
        }

        public bool Equals(Hex other)
        {
            if (other.Valeur == Valeur) { return true; } else { return false; }
        }



        public static bool operator ==(Hex left, Hex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Hex left, Hex right)
        {
            return !(left == right);
        }


    }



}
