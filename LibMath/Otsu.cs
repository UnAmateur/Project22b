using System;
using System.Linq;

namespace LibMath
{
    public static class Otsu
    {
        #region METHODE OTSU
        public static int Methode(int[] points)
        {
            double[] valeus = Array.ConvertAll<int, double>(points, IntToDouble);
            return (int)Methode(valeus);
        }
        private static double IntToDouble(int value) { return value; }
        /// <summary>
        /// Determination du meilleur seuil dans une histogramme
        /// Liste des point à determiné le seuil ideal selon la methode
        /// </summary>
        /// <param name="points">Liste des points normalisés</param>        
        /// <returns></returns>
        public static double Methode(double[] points)
        {
            double[] vec = new double[points.Length];
            double p1, p2, p12;
            for (int index = 1; index < points.Count(); index++)
            {
                p1 = PX(0, index, points);
                p2 = PX(index + 1, points.Count(), points);
                p12 = p1 * p2;
                if (p12 == 0) { p12 = 1; }
                double diff = (MX(0, index, points) * p2 - (MX(index + 1, points.Count(), points) * p1));
                vec[index] = diff * diff / p12;
            }
            return FindMax(vec);
        }
        private static double PX(int init, int end, double[] points)
        {
            double sum = 0;
            for (int index = init; index < end; index++)
            {
                sum += points[index];
            }
            return sum;
        }
        private static double MX(int init, int end, double[] points)
        {
            double sum = 0;
            for (int index = init; index < end; index++)
            {
                sum += index * points[index];
            }
            return sum;
        }
        private static int FindMax(double[] vec)
        {
            double maxvec = 0;
            int idx = 0;
            for (int index = 1; index < vec.Length - 1; index++)
            {
                if (vec[index] > maxvec)
                {
                    maxvec = vec[index];
                    idx = index;
                }
            }
            return idx;
        }
        #endregion
    }
}
