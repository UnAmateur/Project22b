using LibCore.Parametrages;

using LibMath;

using System;
using System.Collections.Generic;
using System.Drawing;

namespace LibCore.Couleurs
{
    public class Rgb : CouleurSimple, IEqualityComparer<Rgb>, IEquatable<Rgb>, IComparable<Rgb>
    {
        public static implicit operator Color(Rgb rgb)
        {
            byte[] u = rgb.ToBytes();
            return Color.FromArgb(u[0], u[1], u[2]);
        }
        public static implicit operator Rgb(Color color) { return new Rgb(color.R, color.G, color.B); }
        public static implicit operator Tsl(Rgb rgb) { return rgb.ToTsl(); }
        public static implicit operator Cmjk(Rgb rgb) { return rgb.ToCmjk(); }
        public static implicit operator byte[](Rgb rgb) { return rgb.ToBytes(); }
        public static implicit operator Rgb(byte[] bytes) { return new Rgb(bytes); }

        public static bool operator ==(Rgb A, Rgb B) => A.Equals(B);
        public static bool operator !=(Rgb A, Rgb B) => !(A == B);

        #region Operations
        public static Rgb Add(Rgb A, Rgb B)
        {

            double r = LibMath.Fonctions.Clamp(A.Rouge + B.Rouge, 0, 255);
            double v = LibMath.Fonctions.Clamp(A.Vert + B.Vert, 0, 255);
            double b = LibMath.Fonctions.Clamp(A.Bleu + B.Bleu, 0, 255);
            return new Rgb(r, v, b);
        }
        public static Rgb Mul(Rgb A, double b)
        {
            if (b >= -1 || b <= 1)
            { return new Rgb(A.Rouge * b, A.Vert * b, A.Bleu * b); }
            else { return A; }
        }

        public static Rgb Sub(Rgb A, Rgb B)
        {

            double r = LibMath.Fonctions.Clamp(A.Rouge - B.Rouge, 0, 255);
            double v = LibMath.Fonctions.Clamp(A.Vert - B.Vert, 0, 255);
            double b = LibMath.Fonctions.Clamp(A.Bleu - B.Bleu, 0, 255);
            return new Rgb(r, v, b);
        }
        public static Rgb Shl(Rgb A)
        {
            double r = A.Rouge;
            double v = A.Vert;
            double b = A.Bleu;
            return new Rgb(v, b, r);
        }
        public static Rgb Shr(Rgb A)
        {
            double r = A.Rouge;
            double v = A.Vert;
            double b = A.Bleu;
            return new Rgb(b, r, v);
        }
        public static Rgb Xor(Rgb A, Rgb B)
        {
            Rgb g1 = A.Gris(TypeGris.Moyen);
            Rgb g2 = B.Gris(TypeGris.Moyen);
            return new Rgb((byte)g1.Rouge ^ (byte)g2.Rouge, (byte)g1.Vert ^ (byte)g2.Vert, (byte)g1.Bleu ^ (byte)g2.Bleu);
        }
        public static Rgb Or(Rgb A, Rgb B)
        {
            Rgb g1 = A.Gris(TypeGris.Moyen);
            Rgb g2 = B.Gris(TypeGris.Moyen);
            return new Rgb((byte)g1.Rouge | (byte)g2.Rouge, (byte)g1.Vert | (byte)g2.Vert, (byte)g1.Bleu | (byte)g2.Bleu);
        }
        public static Rgb And(Rgb A, Rgb B)
        {
            Rgb g1 = A.Gris(TypeGris.Moyen);
            Rgb g2 = B.Gris(TypeGris.Moyen);
            return new Rgb((byte)g1.Rouge & (byte)g2.Rouge, (byte)g1.Vert & (byte)g2.Vert, (byte)g1.Bleu & (byte)g2.Bleu);
        }
        #endregion

        public bool IsGris
        {
            get
            {
                if (Rouge == Vert)
                {
                    if (Vert == Bleu)
                    {
                        if (Bleu == Rouge)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
        }
        public static Rgb Empty { get { return new Rgb(-1, -1, -1); } }
        public bool IsEmpty { get { return (Rouge == -1 & Vert == -1 & Bleu == -1); } }
        public double Rouge
        {
            get { return valeurs[0]; }
            set { valeurs[0] = value; }
        }
        public double Vert
        {
            get { return valeurs[1]; }
            set { valeurs[1] = value; }
        }
        public double Bleu
        {
            get { return valeurs[2]; }
            set { valeurs[2] = value; }
        }
        internal Rgb() : base("Rgb", 3) { }
        public Rgb(double rouge, double vert, double bleu) : this()
        {
            Rouge = rouge;
            Vert = vert;
            Bleu = bleu;
        }
        internal Rgb(Matrice matrice) : this()
        {
            if (matrice.NBLigne >= 3)
            {
                Rouge = matrice[0, 0];
                Vert = matrice[0, 1];
                Bleu = matrice[0, 2];
            }
        }
        internal Rgb(Noeud noeud) : this()
        {
            if (noeud.IsValid("Rouge", "Vert", "Bleu"))
            {
                Name = noeud.Name;
                Rouge = noeud.GetValue<double>("Rouge");
                Vert = noeud.GetValue<double>("Vert");
                Bleu = noeud.GetValue<double>("Bleu");
            }
        }
        internal Rgb(Tsl value) : base("Rgb", 3)
        {
            double c = (1 - System.Math.Abs(2 * value.Lumiere - 1)) * value.Saturation;
            double x = c * (1 - System.Math.Abs(LibMath.Fonctions.Modulo(value.Teinte / 60, 2) - 1));
            double m = value.Lumiere - c / 2;
            if (value.Teinte <= 60) { Rouge = (byte)((c + m) * 255.0); Vert = (byte)((x + m) * 255.0); Bleu = (byte)(m * 255.0); }
            else if (value.Teinte <= 120) { Rouge = (byte)((x + m) * 255.0); Vert = (byte)((c + m) * 255.0); Bleu = (byte)(m * 255.0); }
            else if (value.Teinte <= 180) { Rouge = (byte)(m * 255.0); Vert = (byte)((c + m) * 255.0); Bleu = (byte)((x + m) * 255.0); }
            else if (value.Teinte <= 240) { Rouge = (byte)(m * 255.0); Vert = (byte)((x + m) * 255.0); Bleu = (byte)((c + m) * 255.0); }
            else if (value.Teinte <= 300) { Rouge = (byte)((x + m) * 255.0); Vert = (byte)(m * 255.0); Bleu = (byte)((c + m) * 255.0); }
            else if (value.Teinte <= 360) { Rouge = (byte)((c + m) * 255.0); Vert = (byte)(m * 255.0); Bleu = (byte)((x + m) * 255.0); }
            else
            {
                Rouge = 0;
                Vert = 0;
                Bleu = 0;
            }
        }
        public Rgb(double gris) : this(gris, gris, gris) { }
        public Rgb GetRouge() { return new Rgb(Rouge, 0, 0); }
        public Rgb GetVert() { return new Rgb(0, Vert, 0); }
        public Rgb GetBleu() { return new Rgb(0, 0, Bleu); }
        public Rgb GetCyan() { return new Rgb(0, Vert, Bleu); }
        public Rgb GetMagenta() { return new Rgb(Rouge, 0, Bleu); }
        public Rgb GetJaune() { return new Rgb(Rouge, Vert, 0); }
        public double GetGris(TypeGris gris)
        {
            double k;
            switch (gris)
            {
                case TypeGris.Moyen:
                    k = (Rouge + Vert + Bleu) / 3.0;
                    break;
                case TypeGris.Max:
                    k = LibMath.Fonctions.Max(Rouge, Vert, Bleu);
                    break;
                case TypeGris.Min:
                    k = LibMath.Fonctions.Min(Rouge, Vert, Bleu);
                    break;
                case TypeGris.Cie:
                    k = Rouge * Parametres.Couleurs.CoefCieRouge + Vert * Parametres.Couleurs.CoefCieVert + Bleu * Parametres.Couleurs.CoefCieBleu;
                    break;
                case TypeGris.Median:
                    k = LibMath.Fonctions.Median(Rouge, Vert, Bleu);
                    break;
                default:
                    k = 0;
                    break;
            }
            return k;
        }
        public Rgb Gris(TypeGris gris) { return new Rgb(GetGris(gris)); }
        protected Rgb(byte[] value) : base("Rgb", 3)
        {
            if (value.Length != 3)
            {
                throw new ArgumentException("Rgb::ctor(byte[]) => Le nombre de parametre est incorrect");
            }
            Rouge = value[0] < 0 ? 0 : value[0] > 255 ? 255 : value[0];
            Vert = value[1] < 0 ? 0 : value[1] > 255 ? 255 : value[1];
            Bleu = value[2] < 0 ? 0 : value[2] > 255 ? 255 : value[2];
        }
        public Rgb Left() { return new Rgb(Vert, Bleu, Rouge); }
        public Rgb Right() { return new Rgb(Bleu, Rouge, Vert); }
        public Rgb Negatif() { return new Rgb(255 - Rouge, 255 - Vert, 255 - Bleu); }
        public Rgb Gamma(double k)
        {
            double r = System.Math.Pow(Rouge / 255.0, k) * 255.0;
            double v = System.Math.Pow(Vert / 255.0, k) * 255.0;
            double b = System.Math.Pow(Bleu / 255.0, k) * 255.0;
            return new Rgb(r, v, b);
        }
        public Rgb Lumiere(double k)
        {
            Tsl tsl = this;
            double m = LibMath.Fonctions.Clamp(tsl.Lumiere * (1 + k), 0, 1);
            tsl.Lumiere = m;
            return tsl;
        }
        public Rgb Normalise()
        {
            double S = Rouge + Vert + Bleu;
            if (S == 0) { return new Rgb(); }
            return new Rgb(255.0 * Rouge / S, 255.0 * Vert / S, 255.0 * Bleu / S);
        }
        protected override byte[] ToBytes() { return new byte[] { (byte)Rouge, (byte)Vert, (byte)Bleu }; }
        protected override Rgb ToRgb()
        {
            return this;
        }
        protected override Tsl ToTsl()
        {
            return new Tsl(this);
        }
        protected override Cmjk ToCmjk()
        {
            double r = Rouge / 255.0f;
            double v = Vert / 255.0f;
            double b = Bleu / 255.0f;
            double k = 1 - LibMath.Fonctions.Max(r, v, b);
            double c = (1 - r - k) / (1 - k);
            double m = (1 - v - k) / (1 - k);
            double j = (1 - b - k) / (1 - k);
            return new Cmjk(c, m, j, k);
        }
        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Rgb [###-###-###]";
            }
            else
            {
                return string.Format("Rgb [{0:000}-{1:000}-{2:000}]", (int)Rouge, (int)Vert, (int)Bleu);
            }
        }

        public override Noeud ToNoeud()
        {
            Noeud result = new Noeud
            {
                Name = Name
            };
            result.Add("Rouge", Rouge);
            result.Add("Vert", Vert);
            result.Add("Bleu", Bleu);
            return result;
        }

        public int GetHashCode(Rgb obj)
        {
            return (int)(obj.Rouge * 256 * 256 + obj.Vert * 256 + obj.Bleu);
        }
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
        public override bool Equals(object obj) => obj is Rgb rgb && Equals(rgb);
        public bool Equals(Rgb other)
        {
            if (other is null) { return false; }
            return Rouge == other.Rouge && Vert == other.Vert && Bleu == other.Bleu;
        }

        public int CompareTo(Rgb other)
        {
            if (other is null) { return 1; }
            else if (this == other) { return 0; }
            else if (GetHashCode() < other.GetHashCode()) { return -1; }
            else { return 1; }
        }

        public bool Equals(Rgb x, Rgb y)
        {
            if (x is null) { return false; }
            return x.Equals(y);
        }
    }
}
