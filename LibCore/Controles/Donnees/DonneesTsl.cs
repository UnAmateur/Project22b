using LibCore.Couleurs;

using System.Drawing;
using System.Drawing.Imaging;

namespace LibCore.Controles.Donnees
{
    internal interface IDonneesTsl
    {
        void Draw(Graphics e);
    }

    internal class DonneesTsl : DonneesCurseurs, IDonneesTsl
    {

        private Bitmap _bitmap;


        public DonneesTsl(CoreControle parent) : base(parent) { }

        public override void Draw(Graphics e)
        {
            base.Draw(e);
            e.DrawImage(_bitmap, Marge, ZoneGraphique.Y);
            DrawCurseur(e);
        }

        protected override void Create(Graphics g)
        {
            base.Create(g);
            _bitmap?.Dispose();
            if (Parent.Size.Width != (int)(360 + 2 * Marge + Parent.GetBordure + 1) | Parent.Size.Height != (int)(100 + 2 * Marge + Parent.GetBordure + 1))
            {
                Parent.Size = new Size((int)(360 + 2 * Marge + Parent.GetBordure + 1), (int)(15 + 2 * Marge + Parent.GetBordure + 1));

            }

            _bitmap = new Bitmap(360, 15, PixelFormat.Format24bppRgb);

            for (int indexX = 0; indexX < 360; indexX++)
            {
                for (int indexY = 0; indexY < 15; indexY++)
                {
                    Tsl p = new Tsl(indexX, 0.5, 0.5);
                    Color k = (Rgb)p;

                    _bitmap.SetPixel(indexX, indexY, k);

                }

            }

        }
    }
}
