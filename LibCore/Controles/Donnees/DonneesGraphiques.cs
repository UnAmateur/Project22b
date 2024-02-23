
namespace LibCore.Controles.Donnees
{
    internal class DonneesGraphiques : DonneesThemes
    {
        public DonneesGraphiques(TypeGraphTheme theme, CoreControle parent) : base(theme, parent) { }
        public DonneesGraphiques(CoreControle parent) : this(TypeGraphTheme.Default, parent) { }
    }
}
