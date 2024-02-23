using System;
using System.Drawing;

namespace LibCore.Controles.Donnees
{
    public class ValeurEventArgs : EventArgs
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        internal ValeurEventArgs() { X = float.NaN; Y = float.NaN; Z = float.NaN; }
        public ValeurEventArgs(float x, float y, float z) { X = x; Y = y; Z = z; }
        public ValeurEventArgs(PointF point, float z) { X = point.X; Y = point.Y; Z = z; }
    }

}
