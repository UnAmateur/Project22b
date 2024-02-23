using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace LibMath
{
    [Serializable()]
    public class Matrice : IXmlSerializable
    {

        private double[] data;
        public double[] GetData() { return data; }
        public void SetData(double[] data) { this.data = data; }
        public int NBLigne { get; private set; }
        public int NBColonne { get; private set; }
        public int Length { get { return NBLigne * NBColonne; } }
        public bool IsVecteur { get { return (NBLigne == 1 || NBColonne == 1); } }
        public bool IsVecteurHZ { get { return (IsVecteur && NBLigne == 1); } }
        public bool IsVecteurVZ { get { return (IsVecteur && NBColonne == 1); } }
        public bool IsCarre { get { return NBLigne == NBColonne; } }
        public double this[int index] { get { return data[index]; } set { data[index] = value; } }
        public double this[int colonne, int ligne] { get { return data[colonne + ligne * NBColonne]; } set { data[colonne + ligne * NBColonne] = value; } }
        #region Ligne
        public void SetLigne(int lig, params double[] values)
        {
            if (values != null)
            {
                if (values.Length > NBColonne) { throw new ArgumentException("Erreur"); }
                Array.Copy(values, 0, data, lig * NBColonne, NBColonne);
            }
        }
        public double[] GetLigne(int lig)
        {
            double[] result = new double[NBColonne];
            Array.Copy(data, lig * NBColonne, result, 0, NBColonne);
            return result;
        }
        #endregion
        #region Colonne
        public void SetColonne(int col, params double[] values)
        {
            if (values != null)
            {
                if (values.Length > NBLigne) { throw new ArgumentException("Erreur"); }
                for (int index = 0; index < values.Length; index++)
                {
                    data[col + index * NBColonne] = values[index];
                }
            }
        }
        public double[] GetColonne(int col)
        {
            double[] result = new double[NBLigne];
            for (int index = 0; index < NBLigne; index++)
            {
                result[index] = data[col + index * NBColonne];
            }
            return result;
        }
        #endregion
        #region Adddition
        public static Matrice operator +(Matrice left, Matrice rigth) { return Matrice.Add(left, rigth); }
        public static Matrice Add(Matrice left, Matrice rigth)
        {

            if (!left.IsTailleIdentique(rigth)) { throw new ArgumentException("Erreur"); }
            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = left[index] + rigth[index]; }
            return result;
        }
        public static Matrice operator +(Matrice left, double rigth)
        {


            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = left[index] + rigth; }
            return result;
        }
        public static Matrice operator +(double rigth, Matrice left)
        {

            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = left[index] + rigth; }
            return result;
        }
        #endregion
        #region Soustraction
        public static Matrice operator -(Matrice left, Matrice rigth) { return Matrice.Subtract(left, rigth); }

        public static Matrice Subtract(Matrice left, Matrice rigth)
        {

            if (!left.IsTailleIdentique(rigth)) { throw new ArgumentException("Erreur"); }
            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = left[index] - rigth[index]; }
            return result;
        }
        public static Matrice operator -(Matrice left, double rigth)
        {

            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = left[index] - rigth; }
            return result;
        }
        public static Matrice operator -(double rigth, Matrice left)
        {

            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = rigth - left[index]; }
            return result;
        }
        #endregion
        #region Multiplication
        public static Matrice operator *(Matrice left, Matrice rigth) { return Matrice.Multiply(left, rigth); }

        public static Matrice Multiply(Matrice left, Matrice rigth)
        {

            if (left.NBColonne != rigth.NBLigne) { throw new ArgumentException("Erreur"); }
            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int y = 0; y < left.NBLigne; y++)
            {
                for (int x = 0; x < rigth.NBColonne; x++)
                {
                    result[x, y] = Multiplication(left.GetLigne(y), rigth.GetColonne(x));
                }
            }
            return result;
        }
        public static Matrice operator *(Matrice left, double rigth)
        {


            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = left[index] * rigth; }
            return result;
        }
        public static Matrice operator *(double rigth, Matrice left)
        {

            Matrice result = new Matrice(left.NBLigne, left.NBColonne);
            for (int index = 0; index < left.Length; index++) { result[index] = rigth * left[index]; }
            return result;
        }
        private static double Multiplication(double nombreA, double nombreB) { return nombreA * nombreB; }
        private static double Multiplication(double[] nombreA, double[] nombreB)
        {

            if (nombreA.Length != nombreB.Length) { throw new ArgumentException("Erreur"); }
            double result = 0;
            for (int index = 0; index < nombreA.Length; index++)
            {
                if (nombreA[index] != 0 | nombreB[index] != 0)
                { result += nombreA[index] * nombreB[index]; }
            }
            return result;
        }
        #endregion
        #region Inverse
        public Matrice Inverse()
        {
            double Det = Determinant();
            if (Det == 0) { throw new ArgumentException("Erreur"); }
            return Comatrice().Transpose() * (1 / Det);
        }
        #endregion
        #region Comatrice
        public Matrice Comatrice()
        {
            if (!IsCarre) { throw new ArgumentException("Erreur"); }
            Matrice result = new Matrice(NBColonne, NBLigne);
            for (int indexL = 0; indexL < NBLigne; indexL++)
            {
                for (int indexC = 0; indexC < NBColonne; indexC++)
                {
                    result[indexC, indexL] = Multiplication(Signe(indexC, indexL), Mineur(indexC, indexL).Determinant());
                }
            }
            return result;
        }
        #endregion
        #region Transpose
        public Matrice Transpose()
        {
            Matrice result = new Matrice(NBLigne, NBColonne);
            for (int index = 0; index < NBLigne; index++)
            {
                result.SetColonne(index, GetLigne(index));
            }
            return result;
        }
        #endregion
        #region Determinant
        public double Determinant()
        {
            double result = 0;
            if (Length == 4)
            {
                return (this[0] * this[3]) - (this[1] * this[2]);
            }
            else
            {
                for (int index = 0; index < NBColonne; index++)
                {
                    result += Multiplication(Multiplication(Signe(index, 0), this[index, 0]), Mineur(index, 0).Determinant());
                }
            }
            return result;
        }
        #endregion
        #region Fonctions diverses publiques
        /// <summary>
        /// Verifie si les matrices ont meme colonne et meme ligne
        /// </summary>
        /// <param name="matrice"></param>
        /// <returns></returns>
        public bool IsTailleIdentique(Matrice matrice)
        {

            if (NBLigne == matrice.NBLigne & NBColonne == matrice.NBColonne) { return true; } else { return false; }
        }
        /// <summary>
        /// Renvois la matrice carrée unitaire
        /// </summary>
        /// <param name="carre">N x N</param>
        /// <returns></returns>
        public static Matrice Identity(int carre)
        {
            Matrice result = new Matrice(carre, carre);
            for (int index = 0; index < result.NBColonne; index++)
            {
                result[index, index] = 1;
            }
            return result;
        }
        #endregion
        #region Fonctions diverses privées
        private Matrice Mineur(int col, int lig)
        {
            Matrice result = new Matrice(NBColonne - 1, NBLigne - 1);
            int klig = 0;

            for (int indexL = 0; indexL < NBLigne; indexL++)
            {
                if (indexL != lig)
                {

                    int kcol = 0;
                    for (int indexC = 0; indexC < NBColonne; indexC++)
                    {
                        if (indexC != col)
                        {
                            result[kcol, klig] = this[indexC, indexL];
                            kcol++;
                        }
                    }
                    klig++;
                }
            }
            return result;
        }

        private static double Signe(int col, int lig)
        {
            if (col % 2 == 0 && lig % 2 == 0) { return 1; }
            else if (col % 2 == 0 && lig % 2 == 1) { return -1; }
            else if (col % 2 == 1 && lig % 2 == 0) { return -1; }
            else { return 1; }

        }
        #endregion
        #region Constructeur
        /// <summary>
        /// Renvois une matrice N x P
        /// </summary>
        /// <param name="lig">nombre de ligne</param>
        /// <param name="col">nombre de colonne</param>
        public Matrice(int lig, int col)
        {
            NBLigne = lig;
            NBColonne = col;
            data = new double[lig * col];
        }
        public Matrice()
        {
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            string result = string.Empty;
            for (int indexLig = 0; indexLig < NBLigne; indexLig++)
            {
                result += "|";
                for (int indexCol = 0; indexCol < NBColonne; indexCol++)
                {
                    result += this[indexCol, indexLig].ToString(CultureInfo.CurrentCulture) + ";";
                }
                result = result.Substring(0, result.Length - 1) + "|\r\n";
            }
            return result;
        }
        public string ToString(string format)
        {
            string result = string.Empty;
            for (int indexLig = 0; indexLig < NBLigne; indexLig++)
            {
                result += "|";
                for (int indexCol = 0; indexCol < NBColonne; indexCol++)
                {
                    result += string.Format(CultureInfo.CurrentCulture, "{0}", this[indexCol, indexLig].ToString(format)) + ";";
                }
                result = result.Substring(0, result.Length - 1) + "|\r\n";
            }
            return result;
        }
        #endregion
        #region Xml
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader != null)
            {

                if (reader.NodeType == XmlNodeType.Element)
                {
                    NBLigne = int.Parse(reader.GetAttribute("ligne"), CultureInfo.CurrentCulture);
                    NBColonne = int.Parse(reader.GetAttribute("colonne"), CultureInfo.CurrentCulture);
                    reader.Read();
                    data = new double[NBLigne * NBColonne];
                    string[] s = reader.Value.Trim().Split(' ');
                    for (int index = 0; index < s.Length; index++)
                    {
                        data[index] = double.Parse(s[index], CultureInfo.CurrentCulture);
                    }
                }

            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer != null)
            {

                writer.WriteAttributeString("ligne", NBLigne.ToString(CultureInfo.CurrentCulture));
                writer.WriteAttributeString("colonne", NBColonne.ToString(CultureInfo.CurrentCulture));
                for (int index = 0; index < data.Length; index++)
                { writer.WriteValue(data[index].ToString(CultureInfo.CurrentCulture) + " "); }

            }
        }

        #endregion

    }
    public class MatriceRotation : Matrice
    {
        private double CosP;
        private double SinP;
        private double SinM;
        public MatriceRotation() : base(3, 3)
        {

        }
        public Matrice Rotation(TypeRotation axerotation, double angle)
        {
            switch (axerotation)
            {
                case TypeRotation.X:
                    return RotationX(angle);
                case TypeRotation.Y:
                    return RotationY(angle);
                case TypeRotation.Z:
                    return RotationZ(angle);
                case TypeRotation.XY:
                    return RotationX(angle) * RotationY(angle);
                case TypeRotation.XZ:
                    return RotationX(angle) * RotationZ(angle);
                case TypeRotation.YX:
                    return RotationY(angle) * RotationX(angle);
                case TypeRotation.YZ:
                    return RotationY(angle) * RotationZ(angle);
                case TypeRotation.ZX:
                    return RotationZ(angle) * RotationX(angle);
                case TypeRotation.ZY:
                    return RotationZ(angle) * RotationY(angle);
                case TypeRotation.XYZ:
                    return RotationX(angle) * RotationY(angle) * RotationZ(angle);
                case TypeRotation.YZX:
                    return RotationY(angle) * RotationZ(angle) * RotationX(angle);
                case TypeRotation.ZXY:
                    return RotationZ(angle) * RotationX(angle) * RotationY(angle);
                default:
                    return Identity(3);
            }
        }
        private MatriceRotation RotationX(double angle)
        {
            CosP = System.Math.Cos(angle);
            SinP = System.Math.Sin(angle);
            SinM = -SinP;
            SetLigne(0, 1, 0, 0);
            SetLigne(1, 0, CosP, SinM);
            SetLigne(2, 0, SinP, CosP);
            return this;
        }
        private MatriceRotation RotationY(double angle)
        {
            CosP = System.Math.Cos(angle);
            SinP = System.Math.Sin(angle);
            SinM = -SinP;
            SetLigne(0, CosP, 0, SinP);
            SetLigne(1, 0, 1, 0);
            SetLigne(2, SinM, 0, CosP);
            return this;
        }
        private MatriceRotation RotationZ(double angle)
        {
            CosP = System.Math.Cos(angle);
            SinP = System.Math.Sin(angle);
            SinM = -SinP;
            SetLigne(0, CosP, SinM, 0);
            SetLigne(1, SinP, CosP, 0);
            SetLigne(2, 0, 0, 1);
            return this;
        }
    }
    public enum TypeRotation { X, Y, Z, XY, XZ, YX, YZ, ZX, ZY, XYZ, YZX, ZXY }
}
