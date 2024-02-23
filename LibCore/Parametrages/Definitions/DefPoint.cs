using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefPoint : Definition
    {
        public static implicit operator Size(DefPoint value)
        {
            if (value is null) { return Size.Empty; }
            return new Size((int)value.X, (int)value.Y);
        }
        public static implicit operator SizeF(DefPoint value)
        {
            if (value is null) { return SizeF.Empty; }
            return new SizeF(value.X, value.Y);
        }
        public static implicit operator DefPoint(Size value) { return new DefPoint(value); }
        public static implicit operator DefPoint(SizeF value) { return new DefPoint(value); }

        public float X { get { return GetValue<float>("X"); } set { this["X"] = value; } }
        public float Y { get { return GetValue<float>("Y"); } set { this["Y"] = value; } }
        public DefPoint() : this("Point") { }
        public DefPoint(string name) : this(name, 0, 0) { }
        public DefPoint(Size value) : this("Point", value.Width, value.Height) { }
        public DefPoint(SizeF value) : this("Point", value.Width, value.Height) { }
        public DefPoint(string name, float x, float y) : base(name)
        {
            Add("X", x);
            Add("Y", y);
        }

        public DefPoint(Noeud noeud) : base(noeud?.Name)
        {
            if (!noeud.IsValid("X", "Y")) { Create(); }
        }
        public SizeF ToSize() { return new SizeF(X, Y); }
        protected override void Create()
        {
            Clear();
            Add("X", 0);
            Add("Y", 0);
        }
    }
}
