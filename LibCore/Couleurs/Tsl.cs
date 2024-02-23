using LibCore.Parametrages;

namespace LibCore.Couleurs
{
    public class Tsl : CouleurSimple
    {
        public static implicit operator Rgb(Tsl tsl) { return tsl.ToRgb(); }
        public static implicit operator byte[](Tsl tsl) { return tsl.ToBytes(); }
        public double Teinte
        {
            get { return valeurs[0]; }
            set { valeurs[0] = value; }
        }
        public double Saturation
        {
            get { return valeurs[1]; }
            set { valeurs[1] = value; }
        }
        public double Lumiere
        {
            get { return valeurs[2]; }
            set { valeurs[2] = value; }
        }
        internal Tsl() : base("Tsl", 3) { }
        public Tsl(double teinte, double saturation, double lumiere) : this()
        {
            Teinte = teinte;
            Saturation = saturation;
            Lumiere = lumiere;
        }
        internal Tsl(Noeud noeud) : this()
        {
            if (noeud.IsValid("Rouge", "Vert", "Bleu"))
            {
                Name = noeud.Name;
                Teinte = noeud.GetValue<double>("Teinte");
                Saturation = noeud.GetValue<double>("Saturation");
                Lumiere = noeud.GetValue<double>("Lumiere");
            }
        }
        internal Tsl(Rgb value) : this()
        {
            double R = value.Rouge / 255.0;
            double V = value.Vert / 255.0;
            double B = value.Bleu / 255.0;
            double max = LibMath.Fonctions.Max(R, V, B);
            double min = LibMath.Fonctions.Min(R, V, B);
            double delta = max - min;
            Lumiere = (max + min) / 2.0; ;
            if (delta == 0) { Saturation = 0; }
            else { Saturation = delta / (1.0 - System.Math.Abs(2.0 * Lumiere - 1.0)); }
            if (delta == 0) { Teinte = 0; }
            else if (max == R) { Teinte = LibMath.Fonctions.Modulo(((V - B) / delta), 6.0); }
            else if (max == V) { Teinte = (((B - R) / delta) + 2.0); }
            else if (max == B) { Teinte = (((R - V) / delta) + 4.0); }
            else { Teinte = 0; }
            Teinte *= 60;
            Teinte = LibMath.Fonctions.Rotate(Teinte, 360);
        }
        /// <summary>
        /// Retourne la couleur complementaire
        /// </summary>
        /// <returns></returns>
        public Tsl Complementaire()
        {
            return new Tsl(Teinte + 180 > 360 ? Teinte - 180 : Teinte + 180, Saturation, Lumiere);
        }
        /// <summary>
        /// Ajoute une valeur à la Teinte
        /// </summary>
        /// <param name="angle">valeur comprise entre -360 et 360</param>
        public void Rotate(double angle)
        {
            if (angle < -360) { return; }
            if (angle > 360) { return; }
            Teinte = (Teinte + angle) % 360;
        }
        /// <summary>
        /// Ajoute la valeur à la saturation
        /// </summary>
        /// <param name="s">valeur comprise entre -1 et 1</param>
        public void Sature(double s)
        {
            if (s < -1) { s = -1; }
            if (s > 1) { s = 1; }
            Saturation += s;
            if (Saturation < 0) { Saturation = 0; }
            if (Saturation > 1) { Saturation = 1; }
        }
        /// <summary>
        /// Ajoute la valeur à la Lumière
        /// </summary>
        /// <param name="lumiere">valeur comprise entre -1 et 1</param>
        public void Lumineux(double l)
        {
            if (l < -1) { l = -1; }
            if (l > 1) { l = 1; }
            Lumiere += l;
            if (Lumiere < 0) { Lumiere = 0; }
            if (Lumiere > 1) { Lumiere = 1; }
        }
        protected override Tsl ToTsl()
        {
            return this;
        }
        protected override Cmjk ToCmjk()
        {
            return ToRgb();
        }
        protected override Rgb ToRgb()
        {
            return new Rgb(this);
        }
        public override string ToString()
        {
            return string.Format("Tsl[{0:000}-{1:000}-{2:000}]", (int)Teinte, (int)(Saturation * 100), (int)(Lumiere * 100));
        }
        public override Noeud ToNoeud()
        {
            Noeud result = new Noeud
            {
                Name = Name
            };
            result.Add("Teinte", Teinte);
            result.Add("Saturation", Saturation);
            result.Add("Lumiere", Lumiere);
            return result;
        }
    }
}
