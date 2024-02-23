using LibCore.Parametrages;

using System;
using System.ComponentModel;
using System.Drawing;


namespace LibCore.Controles.Donnees
{
    internal class DonneesBase : Core, IDisposable, IDonneesBase
    {
        public event EventHandler<ValeurEventArgs> Changed;
        private Bitmap _image;
        private float marge = 10;
        private float minx = 0;
        private float miny = 0;
        private float maxx = 100;
        private float maxy = 100;

        protected float DeltaX { get { return (maxx - minx); } }
        protected float DeltaY { get { return (maxy - miny); } }
        protected float RapportX { get { return DeltaX / ZoneGraphique.Width; } }
        protected float RapportY { get { return DeltaY / ZoneGraphique.Height; } }
        protected RectangleF ZoneGraphique { get; private set; }
        protected CoreControle Parent = null;
        [Category("Donnees Graphiques")]
        public float MinX { get { return minx; } set { OnMinXChanged(value); } }
        [Category("Donnees Graphiques")]
        public float MinY { get { return miny; } set { OnMinYChanged(value); } }
        [Category("Donnees Graphiques")]
        public float MaxX { get { return maxx; } set { OnMaxXChanged(value); } }
        [Category("Donnees Graphiques")]
        public float MaxY { get { return maxy; } set { OnMaxYChanged(value); } }

        [Category("Donnees Graphiques")]
        public float Marge { get { return marge; } set { OnMargeChanged(value); } }
        public DonneesBase(CoreControle parent) : this("DonneesBase", parent) { }
        public DonneesBase(string name, CoreControle parent) : base(name)
        {
            Parent = parent;
            Parent.SizeChanged += Parent_SizeChanged;
            CreateImage();

        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            CreateImage();

        }


        private void OnMargeChanged(float value)
        {
            if (value != marge)
            {
                marge = value;
                OnConstructionChanged();
            }
        }

        private void OnMinXChanged(float value)
        {
            if (value != minx)
            {
                if (value < maxx)
                {
                    minx = value;
                    OnConstructionChanged();
                }
            }
        }
        private void OnMinYChanged(float value)
        {
            if (value != miny)
            {
                if (value < maxy)
                {
                    miny = value;
                    OnConstructionChanged();
                }
            }
        }
        private void OnMaxXChanged(float value)
        {
            if (value != maxx)
            {
                if (value > minx)
                {
                    maxx = value;
                    OnConstructionChanged();
                }
            }
        }
        private void OnMaxYChanged(float value)
        {
            if (value != maxy)
            {
                if (value > miny)
                {
                    maxy = value;
                    OnConstructionChanged();
                }
            }
        }
        public float GraphToValeurX(float value) { return LibMath.Fonctions.Clamp((value - ZoneGraphique.X) * RapportX + minx, MinX, MaxX); }
        public float GraphToValeurY(float value) { return LibMath.Fonctions.Clamp(miny + ((ZoneGraphique.Bottom - value) * RapportY), MinY, MaxY); }
        public PointF GraphToValeur(PointF value) { return new PointF(GraphToValeurX(value.X), GraphToValeurY(value.Y)); }
        public PointF GraphToValeur(float X, float Y) { return new PointF(GraphToValeurX(X), GraphToValeurY(Y)); }
        public float ValeurToGraphX(float value) { return ZoneGraphique.X + ((value - minx) / RapportX); }
        public float ValeurToGraphY(float value) { return ZoneGraphique.Bottom - ((value - miny) / RapportY); }
        public PointF ValeurToGraph(PointF value) { return new PointF(ValeurToGraphX(value.X), ValeurToGraphY(value.Y)); }
        public PointF ValeurToGraph(float X, float Y) { return new PointF(ValeurToGraphX(X), ValeurToGraphY(Y)); }
        public virtual void Draw(Graphics g) { g.DrawImage(_image, 0, 0); }
        public void Dispose()
        {
            _image?.Dispose();
        }
        private void CreateImage()
        {
            if (Parent.Width > 0 & Parent.Height > 0)
            {
                _image?.Dispose();
                _image = new Bitmap(Parent.Width, Parent.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                OnConstructionChanged();
            }
        }
        protected virtual void Create(Graphics g)
        {
            ZoneGraphique = CalculZoneGraphique(g);
            g.Clear(Parametres.Themes.Fond);
        }

        protected virtual RectangleF CalculZoneGraphique(Graphics g) { return new RectangleF(marge, marge, Parent.Width - Parent.GetBordure - 2 * marge, Parent.Height - Parent.GetBordure - 2 * marge); }

        protected void OnConstructionChanged()
        {
            using (Graphics GraphicImage = Graphics.FromImage(_image))
            {
                GraphicImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                GraphicImage.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                GraphicImage.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                Create(GraphicImage);
            }
            OnDonneesChanged(null);


        }
        protected void OnDonneesChanged(ValeurEventArgs e)
        {
            Parent.Refresh();
            Changed?.Invoke(this, e);
        }
    }
}
