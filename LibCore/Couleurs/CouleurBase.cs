using LibCore.Parametrages;

using LibMath;

using System;
using System.Linq;

namespace LibCore.Couleurs
{
    public abstract class CouleurBase : Core
    {
        public static implicit operator Matrice(CouleurBase value) { return value.ToMatrice(); }
        public static implicit operator Noeud(CouleurBase value) { return value.ToNoeud(); }
        protected double[] valeurs;
        internal CouleurBase(int nb) : base("CouleurBase")
        {
            valeurs = new double[nb];
        }
        internal CouleurBase(string name, int nb) : base(name)
        {
            valeurs = new double[nb];
        }
        protected virtual byte[] ToBytes()
        {
            byte[] k = new byte[4 * valeurs.Count()];

            for (int index = 0; index < k.Length; index++)
            {
                Array.Copy(BitConverter.GetBytes(valeurs[index]), 0, k, index * 4, 4);
            }
            return k;
        }
        public double[] ToArray() { return valeurs; }
        public Matrice ToMatrice()
        {
            Matrice p = new Matrice(valeurs.Length, valeurs.Length);
            p.SetColonne(0, valeurs);
            return p;
        }
        public abstract Noeud ToNoeud();


    }
}
