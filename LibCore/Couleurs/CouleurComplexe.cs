namespace LibCore.Couleurs
{
    internal abstract class CouleurComplexe : CouleurBase
    {
        internal CouleurComplexe(int nb) : this("CouleurComplexe", nb) { }
        internal CouleurComplexe(string name, int nb) : base(name, nb) { }
    }
}
