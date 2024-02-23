namespace LibCore.Couleurs
{
    public abstract class CouleurSimple : CouleurBase
    {
        internal CouleurSimple(int nb) : base(nb)
        {
        }

        internal CouleurSimple(string name, int nb) : base(name, nb)
        {
        }

        protected abstract Cmjk ToCmjk();
        protected abstract Rgb ToRgb();
        protected abstract Tsl ToTsl();
    }
}
