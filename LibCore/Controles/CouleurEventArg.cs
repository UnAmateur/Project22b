using System;

namespace LibCore.Controles
{
    public class CouleurEventArg<T> : EventArgs
    {
        public T Couleur { get; private set; }
        public CouleurEventArg(T couleur)
        {
            Couleur = couleur;
        }
        public CouleurEventArg() { }
    }

}
