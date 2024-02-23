using System;

namespace LibCore.Formules
{
    public class ErreurEventArgs : EventArgs
    {
        public string Erreur { get; private set; }
        public ErreurEventArgs(string chaine) { Erreur = chaine; }
    }

}
