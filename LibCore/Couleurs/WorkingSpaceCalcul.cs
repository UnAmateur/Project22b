using LibCore.Parametrages;

using LibMath;

using System;

namespace LibCore.Couleurs
{
    internal class WorkingSpaceCalcul : Core
    {
        private readonly WorkingSpace Espace = null;
        private readonly XYZ White;
        private readonly Matrice M_RgbToXyz = null;
        private readonly Matrice M_XyzToRgb = null;
        public WorkingSpaceCalcul() : this(Parametres.Couleurs.WorkingSpaceReference) { }

        public WorkingSpaceCalcul(WorkingSpace working) : base()
        {
            if (working is null) { throw new ArgumentException("Parametre null"); }
            Espace = working;
            White = Parametres.Couleurs.BlancRef(Espace.White);
            M_RgbToXyz = CalculM();
            M_XyzToRgb = M_RgbToXyz.Inverse();
        }


        public XYZ RgbToXyz(Rgb value)
        {
            Matrice rgb = Espace.Gamma.RgbToXyz(value);
            Matrice q = M_RgbToXyz * rgb;
            return new XYZ(q[0, 0], q[0, 1], q[0, 2]);
        }
        public Rgb XyzToRgb(XYZ value)
        {
            Matrice q = M_XyzToRgb * value;
            return Espace.Gamma.XyzToRgb(q);
        }
        public Lab XyzToLab(XYZ value)
        {
            double fx = value.X / White.X;
            double fy = value.Y / White.Y;
            double fz = value.Z / White.Z;
            if (fx > Parametres.Couleurs.Epsilon) { fx = System.Math.Pow(fx, 1 / 3.0); } else { fx = (Parametres.Couleurs.Kappa * fx + 16) / 116; }
            if (fy > Parametres.Couleurs.Epsilon) { fy = System.Math.Pow(fy, 1 / 3.0); } else { fy = (Parametres.Couleurs.Kappa * fy + 16) / 116; }
            if (fz > Parametres.Couleurs.Epsilon) { fz = System.Math.Pow(fz, 1 / 3.0); } else { fz = (Parametres.Couleurs.Kappa * fz + 16) / 116; }
            return new Lab(116 * fy - 16, 500.0 * (fx - fy), 200 * (fy - fz));
        }
        public XYZ LabToXyz(Lab value)
        {
            double fy = (value.L + 16) / 116;
            double fx = (value.A / 500) + fy;
            double fz = fy - (value.B / 200);
            if (System.Math.Pow(fx, 3) > Parametres.Couleurs.Epsilon) { fx = System.Math.Pow(fx, 3); } else { fx = (116 * fx - 16) / Parametres.Couleurs.Kappa; }
            if (value.L > (Parametres.Couleurs.Epsilon * Parametres.Couleurs.Kappa)) { fy = System.Math.Pow((value.L + 16) / 116.0, 3.0); } else { fy = value.L / Parametres.Couleurs.Kappa; }
            if (System.Math.Pow(fz, 3) > Parametres.Couleurs.Epsilon) { fz = System.Math.Pow(fz, 3); } else { fz = (116 * fz - 16) / Parametres.Couleurs.Kappa; }
            return new XYZ(fx * White.X, fy * White.Y, fz * White.Z);
        }
        public Rgb LabToRgb(Lab value) { return XyzToRgb(LabToXyz(value)); }
        public Lab RgbToLab(Rgb rgb) { return XyzToLab(RgbToXyz(rgb)); }
        public XYZ ChangeBlanc(XYZ value)
        {
            return null;
        }

        private Matrice CalculM()
        {
            Matrice M1 = new Matrice(3, 3);
            M1.SetColonne(0, Espace.Red.X / Espace.Red.Y, 1, (1 - Espace.Red.X - Espace.Red.Y) / Espace.Red.Y);
            M1.SetColonne(1, Espace.Green.X / Espace.Green.Y, 1, (1 - Espace.Green.X - Espace.Green.Y) / Espace.Green.Y);
            M1.SetColonne(2, Espace.Blue.X / Espace.Blue.Y, 1, (1 - Espace.Blue.X - Espace.Blue.Y) / Espace.Blue.Y);

            Matrice W = Parametres.Couleurs.BlancRef(Espace.White);
            Matrice S = M1.Inverse() * W;

            Matrice M = new Matrice(3, 3);

            M[0, 0] = S[0, 0] * M1[0, 0];
            M[0, 1] = S[0, 0] * M1[0, 1];
            M[0, 2] = S[0, 0] * M1[0, 2];

            M[1, 0] = S[0, 1] * M1[1, 0];
            M[1, 1] = S[0, 1] * M1[1, 1];
            M[1, 2] = S[0, 1] * M1[1, 2];

            M[2, 0] = S[0, 2] * M1[2, 0];
            M[2, 1] = S[0, 2] * M1[2, 1];
            M[2, 2] = S[0, 2] * M1[2, 2];

            return M;
        }
    }
}
