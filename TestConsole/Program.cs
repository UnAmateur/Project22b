using LibCore.Formules;
using LibCore.Parametrages;

using System;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parametres.Setup();
            Calculatrice calculatrice = new Calculatrice();
            calculatrice.Erreur += Calculatrice_Erreur;
            calculatrice.Formule = Parametres.Config.Formules.GetValue<string>("Essais");
            double[] k = new double[] { 1, 22, 300, 4, 5 };
            double[] m = calculatrice.Calcul(k);
            if (m == null)
            {
                Console.WriteLine("m is null");
            }
            else
            {
                if (m.Length != 1)
                {
                    Console.WriteLine(calculatrice.Formule);
                    for (int index = 0; index < m.Length; index++)
                    {
                        Console.WriteLine(k[index] + " " + m[index]);
                    }
                }
                else
                {
                    Console.WriteLine(calculatrice.Formule);
                    Console.WriteLine(m[0]);
                }
            }
            FIN();
        }

        private static void Calculatrice_Erreur(object sender, ErreurEventArgs e)
        {
            Console.WriteLine(e.Erreur);
        }

        private static void FIN()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("---------------FIN----------------------");
            Console.WriteLine("----------------------------------------");
            Console.ReadKey();
        }
    }
}
