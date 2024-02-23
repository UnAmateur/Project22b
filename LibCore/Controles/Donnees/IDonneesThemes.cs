
namespace LibCore.Controles.Donnees
{
    internal interface IDonneesThemes : IDonneesBase
    {
        TypeGraphTheme Theme { get; set; }
        string Format { get; set; }
        bool AxeX { get; set; }
        bool AxeY { get; set; }
        bool Cadre { get; set; }
        TypePosition PositionX { get; set; }
        TypePosition PositionY { get; set; }
        bool PrimaireX { get; set; }
        bool PrimaireY { get; set; }
        bool SecondaireX { get; set; }
        bool SecondaireY { get; set; }
        bool TertiaireX { get; set; }
        bool TertiaireY { get; set; }
        bool TexteX { get; set; }
        bool TexteY { get; set; }
    }
}
