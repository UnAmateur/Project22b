using LibCore.Parametrages.Definitions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LibCore.Formules
{
    internal class Operateurs : Core
    {
        public Operateurs() : base("Operateurs") { }

        public double CalculItem(List<DefToken> tokens, ItemVariable variables)
        {
            List<DefToken> liste = new List<DefToken>();
            liste.AddRange(tokens);
            if (variables != null)
            {
                for (int index = 0; index < liste.Count; index++)
                {
                    if (liste[index].IsVariable)
                    {
                        double k = variables[liste[index].Name];
                        liste[index] = new DefToken(k);
                    }
                }
            }
            int position = 0;

            while (liste.Count != 1)
            {
                if (liste[position].IsOperateur)
                {
                    double v;
                    DefToken itemOperateur = liste[position];
                    if (itemOperateur.NbParametre == 1)
                    {
                        v = Calc(itemOperateur.Name, liste[position - 1].Valeur);
                        liste.Insert(position + 1, new DefToken(v));
                        //liste.RemoveAt(index);
                        liste.RemoveRange(position - 1, 2);
                        position--;
                        //liste.RemoveAt(index);
                    }
                    else if (itemOperateur.NbParametre == 2)
                    {
                        v = Calc(itemOperateur.Name, liste[position - 1].Valeur, liste[position - 2].Valeur);
                        liste.Insert(position + 1, new DefToken(v));
                        position -= 2;
                        liste.RemoveRange(position, 3);
                    }
                    else if (itemOperateur.NbParametre == 3)
                    {
                        v = Calc(itemOperateur.Name, liste[position - 1].Valeur, liste[position - 2].Valeur, liste[position - 3].Valeur);
                        liste.Insert(position + 1, new DefToken(v));
                        position -= 3;
                        liste.RemoveRange(position, 4);
                    }
                    else if (itemOperateur.NbParametre == -1)
                    {
                        int k = position - 1;
                        List<double> l = new List<double>();
                        while (liste[k].IsNumber)
                        {
                            l.Add(liste[k].Valeur);
                            k--;
                        }
                        v = Calc(itemOperateur.Name, l.ToArray());

                        liste.Insert(position + 1, new DefToken(v));
                        position = k;
                        liste.RemoveRange(position, l.Count + 2);
                    }
                }
                else
                {
                    position++;
                    if (position == liste.Count) { position = 0; }
                }
            }
            if (liste.Count == 1)
            {
                return liste[0].Valeur;
            }
            else
            {
                return double.NaN;
            }

        }

        protected double Calc(string key, params object[] values)
        {
            MethodInfo methode = GetType().GetRuntimeMethods().First(m => m.Name == key);
            ParameterInfo[] q = methode.GetParameters();
            if (q.Length == values.Length)
            {
                object value = methode.Invoke(this, values);
                if (value != null)
                {
                    return (double)value;
                }
                else
                {
                    return double.NaN;
                }
            }
            else
            {
                return double.NaN;
            }
        }
        protected double SI(double value1, double value2, double value3)
        {
            if (value3 == -1) { return value2; } else { return value1; }
        }
        protected double INF(double value1, double value2)
        {
            return value1 < value2 ? 1 : -1;
        }
        protected double SUP(double value1, double value2)
        {
            return value1 > value2 ? 1 : -1;
        }
        protected double INFEG(double value1, double value2)
        {
            return value1 <= value2 ? 1 : -1;
        }
        protected double SUPEG(double value1, double value2)
        {
            return value1 >= value2 ? 1 : -1;
        }
        protected double EG(double value1, double value2)
        {
            return value1 == value2 ? 1 : -1;
        }
        protected double ENT(double value) { return Math.Truncate(value); }
        protected double ARH(double value) { return Math.Ceiling(value); }
        protected double ARB(double value) { return Math.Floor(value); }
        protected double NEG(double value) { return -value; }
        protected double ABS(double value) { return Math.Abs(value); }
        protected double COS(double value) { return Math.Cos(value); }
        protected double SIN(double value) { return Math.Sin(value); }
        protected double TAN(double value) { return Math.Tan(value); }
        protected double TANXY(double value1, double value2)
        {
            double result = Math.Atan2(value1, value2);
            if (result < 0) { return (2 * Math.PI) + result; } else { return result; }
        }
        protected double ACOS(double value) { return Math.Acos(value); }
        protected double ASIN(double value) { return Math.Asin(value); }
        protected double ATAN(double value) { return Math.Atan(value); }

        protected double COSH(double value) { return (Math.Pow(Math.E, value) + Math.Pow(Math.E, -value)) / 2.0; }
        protected double SINH(double value) { return (Math.Pow(Math.E, value) - Math.Pow(Math.E, -value)) / 2.0; }
        protected double TANH(double value) { return SINH(value) / COSH(value); }
        protected double EXP(double value) { return Math.Exp(value); }
        protected double LOG(double value) { return Math.Log10(value); }
        protected double LN(double value) { return Math.Log(value); }
        protected double FAC(double value)
        {
            if ((int)value > 1)
            {
                return (int)value * FAC((int)value - 1);
            }
            else { return 1; }
        }
        protected double SQR(double value) { return Math.Sqrt(value); }
        protected double ADD(double value1, double value2) { return value1 + value2; }

        protected double SUB(double value1, double value2) { return value2 - value1; }

        protected double MUL(double value1, double value2) { return value1 * value2; }

        protected double DIV(double value1, double value2) { if (value1 == 0) { return double.NaN; } else { return value2 / value1; } }

        protected double MOD(double value1, double value2) { return value2 % value1; }

        protected double POW(double value1, double value2) { return Math.Pow(value2, value1); }

        protected double MAX(double[] values) { return values.Max(); }

        protected double MIN(double[] values) { return values.Min(); }

        protected double SUM(double[] values) { return values.Sum(); }

        protected double MOY(double[] values) { return values.Average(); }
    }

}
