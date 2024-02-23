using System;

namespace LibMath
{
    public static class DecimalMath
    {
        /// <summary>
        /// represents PI
        /// </summary>
        public const decimal Pi = 3.14159265358979323846264338327950288419716939937510M;

        /// <summary>
        /// represents PI
        /// </summary>
        public const decimal Epsilon = 0.0000000000000000001M;

        /// <summary>
        /// represents 2*PI
        /// </summary>
        private const decimal PIx2 = 6.28318530717958647692528676655900576839433879875021M;

        /// <summary>
        /// represents E
        /// </summary>
        public const decimal E = 2.7182818284590452353602874713526624977572470936999595749M;

        /// <summary>
        /// represents PI/2
        /// </summary>
        private const decimal PIdiv2 = 1.570796326794896619231321691639751442098584699687552910487M;

        /// <summary>
        /// represents PI/4
        /// </summary>
        private const decimal PIdiv4 = 0.785398163397448309615660845819875721049292349843776455243M;

        /// <summary>
        /// represents 1.0/E
        /// </summary>
        private const decimal Einv = 0.3678794411714423215955237701614608674458111310317678M;

        /// <summary>
        /// log(10,E) factor
        /// </summary>
        private const decimal Log10Inv = 0.434294481903251827651128918916605082294397005803666566114M;

        /// <summary>
        /// Zero
        /// </summary>
        public const decimal Zero = 0.0M;

        /// <summary>
        /// One
        /// </summary>
        public const decimal One = 1.0M;

        /// <summary>
        /// Represents 0.5M
        /// </summary>
        private const decimal Half = 0.5M;

        /// <summary>
        /// Max iterations count in Taylor series
        /// </summary>
        private const int MaxIteration = 100;

        /// <summary>
        /// Analogy of Math.Exp method
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Exp(decimal valeur)
        {
            var count = 0;
            while (valeur > One)
            {
                valeur--;
                count++;
            }
            while (valeur < Zero)
            {
                valeur++;
                count--;
            }
            var iteration = 1;
            var result = One;
            var fatorial = One;
            decimal cachedResult;
            do
            {
                cachedResult = result;
                fatorial *= valeur / iteration++;
                result += fatorial;
            } while (cachedResult != result);
            if (count != 0) result *= PowerN(E, count);
            return result;
        }

        /// <summary>
        /// Analogy of Math.Pow method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pow"></param>
        /// <returns></returns>
        public static decimal Power(decimal value, decimal pow)
        {
            if (pow == Zero) return One;
            if (pow == One) return value;
            if (value == One) return One;

            if (value == Zero && pow == Zero) return One;

            if (value == Zero)
            {
                if (pow > Zero)
                {
                    return Zero;
                }

                throw new ArgumentException("Power base non valide");
            }

            if (pow == -One) return One / value;

            var isPowerInteger = IsInteger(pow);
            if (value < Zero && !isPowerInteger)
            {
                throw new ArgumentException("Probleme de base Power");
            }

            if (isPowerInteger && value > Zero)
            {
                int powerInt = (int)(pow);
                return PowerN(value, powerInt);
            }

            if (isPowerInteger && value < Zero)
            {
                int powerInt = (int)pow;
                if (powerInt % 2 == 0)
                {
                    return Exp(pow * Log(-value));
                }
                else
                {
                    return -Exp(pow * Log(-value));
                }
            }

            return Exp(pow * Log(value));
        }

        private static bool IsInteger(decimal value)
        {
            long longValue = (long)value;
            if (Abs(value - longValue) <= Epsilon)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Power to the integer value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public static decimal PowerN(decimal value, int power)
        {
            if (power == Zero) return One;
            if (power < Zero) return PowerN(One / value, -power);

            var q = power;
            var prod = One;
            var current = value;
            while (q > 0)
            {
                if (q % 2 == 1)
                {
                    // detects the 1s in the binary expression of power
                    prod = current * prod; // picks up the relevant power
                    q--;
                }
                current *= current; // value^i -> value^(2*i)
                q /= 2;
            }

            return prod;
        }

        /// <summary>
        /// Analogy of Math.Log10
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Log10(decimal valeur)
        {
            return Log(valeur) * Log10Inv;
        }

        /// <summary>
        /// Analogy of Math.Log
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Log(decimal valeur)
        {
            if (valeur <= Zero)
            {
                throw new ArgumentException("Valeur inferieure ou egale à zero");
            }
            var count = 0;
            while (valeur >= One)
            {
                valeur *= Einv;
                count++;
            }
            while (valeur <= Einv)
            {
                valeur *= E;
                count--;
            }
            valeur--;
            if (valeur == 0) return count;
            var result = Zero;
            var iteration = 0;
            var y = One;
            var cacheResult = result - One;
            while (cacheResult != result && iteration < MaxIteration)
            {
                iteration++;
                cacheResult = result;
                y *= -valeur;
                result += y / iteration;
            }
            return count - result;
        }

        /// <summary>
        /// Analogy of Math.Cos
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Cos(decimal valeur)
        {
            while (valeur > PIx2)
            {
                valeur -= PIx2;
            }
            while (valeur < -PIx2)
            {
                valeur += PIx2;
            }
            // now x in (-2pi,2pi)
            if (valeur >= Pi && valeur <= PIx2)
            {
                return -Cos(valeur - Pi);
            }
            if (valeur >= -PIx2 && valeur <= -Pi)
            {
                return -Cos(valeur + Pi);
            }
            valeur *= valeur;
            //y=1-x/2!+x^2/4!-x^3/6!...
            var xx = -valeur * Half;
            var y = One + xx;
            var cachedY = y - One;//init cache  with different value
            for (var i = 1; cachedY != y && i < MaxIteration; i++)
            {
                cachedY = y;
                decimal factor = i * (i + i + 3) + 1; //2i^2+2i+i+1=2i^2+3i+1
                factor = -Half / factor;
                xx *= valeur * factor;
                y += xx;
            }
            return y;
        }

        /// <summary>
        /// Analogy of Math.Tan
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Tan(decimal valeur)
        {
            var cos = Cos(valeur);
            if (cos == Zero) throw new ArgumentException("Parametre invalide");
            return Sin(valeur) / cos;
        }

        /// <summary>
        /// Analogy of Math.Sin
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Sin(decimal valeur)
        {
            var cos = Cos(valeur);
            var moduleOfSin = Sqrt(One - (cos * cos));
            var sineIsPositive = IsSignOfSinePositive(valeur);
            if (sineIsPositive) return moduleOfSin;
            return -moduleOfSin;
        }

        private static bool IsSignOfSinePositive(decimal valeur)
        {
            //truncating to  [-2*PI;2*PI]
            while (valeur >= PIx2)
            {
                valeur -= PIx2;
            }

            while (valeur <= -PIx2)
            {
                valeur += PIx2;
            }

            //now x in [-2*PI;2*PI]
            if (valeur >= -PIx2 && valeur <= -Pi) return true;
            if (valeur >= -Pi && valeur <= Zero) return false;
            if (valeur >= Zero && valeur <= Pi) return true;
            if (valeur >= Pi && valeur <= PIx2) return false;

            //will not be reached
            throw new ArgumentException("Parmaetre invalide");
        }

        /// <summary>
        /// Analogy of Math.Sqrt
        /// </summary>
        /// <param name="valeur"></param>
        /// <param name="epsilon">lasts iteration while error less than this epsilon</param>
        /// <returns></returns>
        public static decimal Sqrt(decimal valeur, decimal epsilon = Zero)
        {
            if (valeur < Zero) throw new OverflowException("Valeur inferieure à zero");
            //initial approximation
            decimal current = (decimal)System.Math.Sqrt((double)valeur), previous;
            do
            {
                previous = current;
                if (previous == Zero) return Zero;
                current = (previous + valeur / previous) * Half;
            } while (Abs(previous - current) > epsilon);
            return current;
        }
        /// <summary>
        /// Analogy of Math.Sinh
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Sinh(decimal valeur)
        {
            var y = Exp(valeur);
            var yy = One / y;
            return (y - yy) * Half;
        }

        /// <summary>
        /// Analogy of Math.Cosh
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Cosh(decimal valeur)
        {
            var y = Exp(valeur);
            var yy = One / y;
            return (y + yy) * Half;
        }

        /// <summary>
        /// Analogy of Math.Sign
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static int Sign(decimal valeur)
        {
            return valeur < Zero ? -1 : (valeur > Zero ? 1 : 0);
        }

        /// <summary>
        /// Analogy of Math.Tanh
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Tanh(decimal valeur)
        {
            var y = Exp(valeur);
            var yy = One / y;
            return (y - yy) / (y + yy);
        }

        /// <summary>
        /// Analogy of Math.Abs
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Abs(decimal valeur)
        {
            if (valeur <= Zero)
            {
                return -valeur;
            }
            return valeur;
        }

        /// <summary>
        /// Analogy of Math.Asin
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Asin(decimal valeur)
        {
            if (valeur > One || valeur < -One)
            {
                throw new ArgumentException("Valeur non compris dans [-1,1]");
            }
            //known values
            if (valeur == Zero) return Zero;
            if (valeur == One) return PIdiv2;
            //asin function is odd function
            if (valeur < Zero) return -Asin(-valeur);

            //my optimize trick here

            // used a math formula to speed up :
            // asin(x)=0.5*(pi/2-asin(1-2*x*x)) 
            // if x>=0 is true

            var newX = One - 2 * valeur * valeur;

            //for calculating new value near to zero than current
            //because we gain more speed with values near to zero
            if (Abs(valeur) > Abs(newX))
            {
                var t = Asin(newX);
                return Half * (PIdiv2 - t);
            }
            var y = Zero;
            var result = valeur;
            decimal cachedResult;
            var i = 1;
            y += result;
            var xx = valeur * valeur;
            do
            {
                cachedResult = result;
                result *= xx * (One - Half / (i));
                y += result / (2 * i + 1);
                i++;
            } while (cachedResult != result);
            return y;
        }

        /// <summary>
        /// Analogy of Math.Atan
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal ATan(decimal valeur)
        {
            if (valeur == Zero) return Zero;
            if (valeur == One) return PIdiv4;
            return Asin(valeur / Sqrt(One + valeur * valeur));
        }
        /// <summary>
        /// Analogy of Math.Acos
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public static decimal Acos(decimal valeur)
        {
            if (valeur == Zero) return PIdiv2;
            if (valeur == One) return Zero;
            if (valeur < Zero) return Pi - Acos(-valeur);
            return PIdiv2 - Asin(valeur);
        }

        /// <summary>
        /// Analogy of Math.Atan2
        /// for more see this
        /// <seealso cref="http://i.imgur.com/TRLjs8R.png"/>
        /// </summary>
        /// <param name="valeury"></param>
        /// <param name="valeurx"></param>
        /// <returns></returns>
        public static decimal Atan2(decimal valeury, decimal valeurx)
        {
            if (valeurx > Zero)
            {
                return ATan(valeury / valeurx);
            }
            if (valeurx < Zero && valeury >= Zero)
            {
                return ATan(valeury / valeurx) + Pi;
            }
            if (valeurx < Zero && valeury < Zero)
            {
                return ATan(valeury / valeurx) - Pi;
            }
            if (valeurx == Zero && valeury > Zero)
            {
                return PIdiv2;
            }
            if (valeurx == Zero && valeury < Zero)
            {
                return -PIdiv2;
            }
            throw new ArgumentException("Atan invalide");
        }
    }
}
