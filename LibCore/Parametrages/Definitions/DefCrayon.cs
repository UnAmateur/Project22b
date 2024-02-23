using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal sealed class DefCrayon : DefPinceau
    {
        public static implicit operator Pen(DefCrayon defCrayon) { return defCrayon.ToPen(); }
        public static implicit operator DefCrayon(Pen pen) { return new DefCrayon(pen); }
        public float Taille { get { return GetValue<float>("Taille"); } set { this["Taille"] = value; } }
        public float[] Patern
        {
            get
            {
                if (AsPatern)
                {
                    DefArray<float> ret = new DefArray<float>((Noeud)this["Patern"]);

                    return ret.ToArray(Convert);
                }
                else { return null; }
            }
            set
            {
                if (AsPatern && value != null)
                {
                    if (Delete("Patern"))
                    {
                        AddPatern(value);
                    }
                }
                else
                {
                    AddPatern(value);
                }
            }
        }
        private float Convert(object value)
        {
            if (float.TryParse(value.ToString(), out float result))
            { return result; }
            else
            { return float.NaN; }

        }
        private bool AsPatern { get { return Keys.Contains("Patern"); } }

        #region CONSTRUCTEURS
        public DefCrayon() : this("Crayon") { }
        public DefCrayon(string name) : this(name, 0, 0, 0, 1f) { }
        public DefCrayon(Pen pen) : this(pen.Color, pen.Width)
        {
            if (pen.DashStyle == System.Drawing.Drawing2D.DashStyle.Custom)
            {
                Patern = pen.DashPattern;
            }
        }
        public DefCrayon(string name, Color couleur, float taille) : this(name, couleur.R, couleur.G, couleur.B, taille) { }
        public DefCrayon(Color couleur, float taille) : this("Crayon", couleur.R, couleur.G, couleur.B, taille) { }
        public DefCrayon(double rouge, double vert, double bleu) : this("Crayon", rouge, vert, bleu, 1f) { }
        public DefCrayon(double rouge, double vert, double bleu, float taille) : this("Crayon", rouge, vert, bleu, taille, null) { }
        public DefCrayon(double rouge, double vert, double bleu, float taille, float[] patern) : this("Crayon", rouge, vert, bleu, taille, patern) { }
        public DefCrayon(string name, double rouge, double vert, double bleu, float taille, float[] patern = null) : base(name, rouge, vert, bleu)
        {
            Add("Taille", taille);
            AddPatern(patern);
        }
        public DefCrayon(Noeud noeud) : base(noeud)
        {
            if (!noeud.IsValid("Taille")) { Create(); }
        }
        #endregion

        public Pen ToPen()
        {
            Pen result = new Pen(ToColor(), Taille);
            if (AsPatern) { result.DashPattern = Patern; }
            return result;
        }
        private void AddPatern(float[] patern)
        {
            if (patern != null)
            {
                Add(new DefArray<float>("Patern", patern));
            }
        }
        protected override void Create()
        {
            base.Create();
            Add("Taille", 1f);
        }
    }

}
