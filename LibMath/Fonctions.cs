using System.Collections.Generic;
using System.Linq;

namespace LibMath
{
    public static class Fonctions
    {
        #region Min
        public static byte Min(params byte[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                byte k = 255;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] < k) { k = args[index]; }
                }
                return k;
            }
        }
        public static int Min(params int[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                int k = int.MaxValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] < k) { k = args[index]; }
                }
                return k;
            }
        }
        public static long Min(params long[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                long k = long.MaxValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] < k) { k = args[index]; }
                }
                return k;
            }
        }
        public static float Min(params float[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                float k = float.MaxValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] < k) { k = args[index]; }
                }
                return k;
            }
        }
        public static double Min(params double[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                double k = double.MaxValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] < k) { k = args[index]; }
                }
                return k;
            }
        }
        #endregion

        #region Max
        public static byte Max(params byte[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                byte k = 0;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] > k) { k = args[index]; }
                }
                return k;
            }
        }
        public static int Max(params int[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                int k = int.MinValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] > k) { k = args[index]; }
                }
                return k;
            }
        }
        public static long Max(params long[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                long k = long.MinValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] > k) { k = args[index]; }
                }
                return k;
            }
        }
        public static float Max(params float[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                float k = float.MinValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] > k) { k = args[index]; }
                }
                return k;
            }
        }
        public static double Max(params double[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                double k = double.MinValue;
                for (int index = 0; index < args.Length; index++)
                {
                    if (args[index] > k) { k = args[index]; }
                }
                return k;
            }
        }
        #endregion

        #region Median
        public static byte Median(params byte[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                List<byte> list = args.ToList();
                list.Sort();
                return list[(list.Count - 1) / 2];

            }
        }
        public static int Median(params int[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                List<int> list = new List<int>();
                list.Sort();
                return list[(list.Count - 1) / 2];

            }
        }
        public static float Median(params float[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                List<float> list = new List<float>();
                list.Sort();
                return list[(list.Count - 1) / 2];
            }
        }
        public static double Median(params double[] args)
        {
            if (args is null) { return 0; }
            else if (args.Length == 0) { return 0; }
            else if (args.Length == 1) { return args[0]; }
            else
            {
                List<double> list = args.ToList();
                list.Sort();
                return list[(list.Count - 1) / 2];
            }
        }
        #endregion

        #region CLAMP
        public static byte Clamp(byte value, byte min, byte max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }
            else { return value; }
        }
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }
            else { return value; }
        }
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }
            else { return value; }
        }
        public static double Clamp(double value, double min, double max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }
            else { return value; }
        }
        #endregion

        #region Convert

        #endregion

        #region MODULO
        public static double Modulo(double a, double b)
        {
            if (b == 0) { return a; }
            a -= b * System.Math.Floor(a / b);
            if (a >= 0) { return a; } else { return a + b; }
        }
        #endregion

        #region Rotate
        static public double Rotate(double value, double max)
        {
            if (double.IsNaN(value)) { return 0; }
            value = Modulo(value, max) * System.Math.Sign(value);
            if (value < 0) { return max + value; }
            else { return value; }
        }
        #endregion
    }
}
