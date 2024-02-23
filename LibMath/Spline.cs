using System;
using System.Collections.Generic;
using System.Drawing;

namespace LibMath
{
    public static class Spline
    {
        #region METHODE SPLINE
        private static double[] SecondDerivative(List<PointF> P)
        {
            int n = P.Count;

            // build the tridiagonal system 
            // (assume 0 boundary conditions: y2[0]=y2[-1]=0) 

            double[,] matrix = new double[n, 3];

            double[] result = new double[n];
            matrix[0, 1] = 1;
            for (int i = 1; i < n - 1; i++)
            {
                matrix[i, 0] = (double)(P[i].X - P[i - 1].X) / 6;
                matrix[i, 1] = (double)(P[i + 1].X - P[i - 1].X) / 3;
                matrix[i, 2] = (double)(P[i + 1].X - P[i].X) / 6;
                result[i] = (double)(P[i + 1].Y - P[i].Y) / (P[i + 1].X - P[i].X) - (double)(P[i].Y - P[i - 1].Y) / (P[i].X - P[i - 1].X);
            }
            matrix[n - 1, 1] = 1;

            // solving pass1 (up->down)
            for (int i = 1; i < n; i++)
            {
                double k = matrix[i, 0] / matrix[i - 1, 1];
                matrix[i, 1] -= k * matrix[i - 1, 2];
                matrix[i, 0] = 0;
                result[i] -= k * result[i - 1];
            }
            // solving pass2 (down->up)
            for (int i = n - 2; i >= 0; i--)
            {
                double k = matrix[i, 2] / matrix[i + 1, 1];
                matrix[i, 1] -= k * matrix[i + 1, 0];
                matrix[i, 2] = 0;
                result[i] -= k * result[i + 1];
            }

            // return second derivative value for each point P
            double[] y2 = new double[n];
            for (int i = 0; i < n; i++) y2[i] = result[i] / matrix[i, 1];
            return y2;
        }
        public static PointF[] MethodeSpline(List<PointF> points)
        {
            if (points == null) { throw new ArgumentException("Liste NULLE dans Spline"); }
            double[] sd = SecondDerivative(points);

            List<PointF> result = new List<PointF>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                PointF cur = points[i];
                PointF next = points[i + 1];
                float x = cur.X;
                while (x <= next.X)
                {

                    double t = (double)(x - cur.X) / (next.X - cur.X);

                    double a = 1 - t;
                    double b = t;
                    double h = next.X - cur.X;
                    double y = a * cur.Y + b * next.Y + (h * h / 6) * ((a * a * a - a) * sd[i] + (b * b * b - b) * sd[i + 1]);
                    result.Add(new PointF(x, (float)y));
                    x++;
                }
            }

            return result.ToArray();
        }
        public static int[] MethodeSpline(PointF[] args, int maxX, int maxY)
        {
            List<PointF> p = new List<PointF>();
            p.AddRange(args);
            PointF[] k = MethodeSpline(p);
            int index = 0;
            int[] result = new int[maxX];
            while (index < maxX)
            {
                result[index] = (int)LibMath.Fonctions.Clamp(k[index].Y, 0, maxY);
                index++;
            }
            return result;
        }
        #endregion
    }
}
