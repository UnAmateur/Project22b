using System;
using System.Drawing;


namespace LibCore.Controles.Donnees
{
    internal interface IDonneesBase
    {
        float MaxX { get; set; }
        float MaxY { get; set; }
        float MinX { get; set; }
        float MinY { get; set; }
        float Marge { get; set; }
        event EventHandler<ValeurEventArgs> Changed;

        void Dispose();
        void Draw(Graphics g);
        PointF GraphToValeur(PointF value);
        float GraphToValeurX(float value);
        float GraphToValeurY(float value);
        PointF ValeurToGraph(PointF value);
        float ValeurToGraphX(float value);
        float ValeurToGraphY(float value);
    }
}
