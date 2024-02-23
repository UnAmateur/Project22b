

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace LibCore.Controles.Donnees
{
    internal class DonneesRgb : DonneesCurseurs, IDonneesRgb
    {

        private Rectangle _rect = new Rectangle(0, 0, 256, 256);
        private Bitmap _bitmap;
        private float valeurZ = 128;

        public float ValeurZ { get { return valeurZ; } set { OnValeurZChanged(value); } }

        public DonneesRgb(CoreControle parent) : base(parent)
        {
            CreateNew();
        }
        private void OnValeurZChanged(float value)
        {
            if (value < valeurZ - 0.5f | value > valeurZ + 0.5f)
            {
                valeurZ = value;
                CreateNew();
                OnDonneesChanged(new ValeurEventArgs(GetPosition(), valeurZ));
            }
        }
        private void CreateNew()
        {
            if (_bitmap != null & valeurZ != -1)
            {
                unsafe
                {
                    BitmapData data = _bitmap.LockBits(_rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    byte* ptr = (byte*)data.Scan0;
                    int len = Math.Abs(data.Stride) * 256;
                    for (int index = 0; index < len; index += 3)
                    {
                        *(ptr + index) = (byte)valeurZ;
                    }
                    _bitmap.UnlockBits(data);

                }
            }
        }
        protected override void Create(Graphics g)
        {
            base.Create(g);
            _bitmap?.Dispose();
            if (Parent.Size.Width != (int)(256 + 2 * Marge + Parent.GetBordure + 1) | Parent.Size.Height != (int)(256 + 2 * Marge + Parent.GetBordure + 1))
            {
                Parent.Size = new Size((int)(256 + 2 * Marge + Parent.GetBordure + 1), (int)(256 + 2 * Marge + Parent.GetBordure + 1));

            }

            _bitmap = new Bitmap(256, 256, PixelFormat.Format24bppRgb);

            for (int indexX = 0; indexX < 256; indexX++)
            {
                for (int indexY = 255; indexY > -1; indexY--)
                {
                    _bitmap.SetPixel(indexX, 255 - indexY, Color.FromArgb(indexX, indexY, 0));
                }
            }
            CreateNew();
        }

        public override void Draw(Graphics e)
        {
            base.Draw(e);
            if (_bitmap != null) { e.DrawImage(_bitmap, Marge, ZoneGraphique.Y); }
            DrawCurseur(e);
        }
        protected override void OnPositionChanged(ValeurEventArgs e)
        {
            OnDonneesChanged(new ValeurEventArgs(e.X, e.Y, valeurZ));
        }
    }
}
