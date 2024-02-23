using System.Drawing;

namespace LibCore.Controles.Donnees
{
    internal interface IDonneesGradient : IDonneesCurseurs
    {
        Color CouleurMax { get; set; }
        Color CouleurMin { get; set; }
    }
}