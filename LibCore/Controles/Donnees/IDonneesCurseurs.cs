using System.Drawing;
using System.Windows.Forms;

namespace LibCore.Controles.Donnees
{
    internal interface IDonneesCurseurs : IDonneesBase
    {
        Color Couleur { get; set; }
        TypeCurseur Curseur { get; set; }
        SizeF DefaultTaille { get; set; }
        TypeSens Sens { get; set; }
        float ValeurX { get; set; }
        float ValeurY { get; set; }

        void DownMouse(MouseEventArgs e);
        void MoveMouse(MouseEventArgs e);
        void UpMouse(MouseEventArgs e);
    }
}