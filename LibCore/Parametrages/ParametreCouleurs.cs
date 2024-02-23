using LibCore.Couleurs;
using LibCore.Parametrages.Definitions;

using LibMath;

using System.Collections.Generic;

namespace LibCore.Parametrages
{
    public class ParametreCouleurs : ParametreBase
    {
        public double CoefCieRouge { get { return ((Noeud)this["General"]).GetValue<double>("CoefCieRouge"); } }
        public double CoefCieVert { get { return ((Noeud)this["General"]).GetValue<double>("CoefCieVert"); } }
        public double CoefCieBleu { get { return ((Noeud)this["General"]).GetValue<double>("CoefCieBleu"); } }
        internal WorkingSpace WorkingSpaceReference { get { return WorkingSpace(((Noeud)this["General"]).GetValue<string>("WorkingSpaceReference")); } }
        public double Epsilon { get { return ((Noeud)this["General"]).GetValue<double>("IntentCie1") / ((Noeud)this["General"]).GetValue<double>("IntentCie3"); } }
        public double Kappa { get { return ((Noeud)this["General"]).GetValue<double>("IntentCie3") / ((Noeud)this["General"]).GetValue<double>("IntentCie2"); } }
        public List<string> WorkingSpacesKeys
        {
            get
            {
                if (IsNullOrEmpty) { return null; }
                else
                {
                    if (Keys.Contains("WorkingSpaces"))
                    {
                        return ((Noeud)this["WorkingSpaces"]).Keys;
                    }
                    else { return null; }
                }
            }
        }
        public List<string> ReferenceBlancKeys
        {
            get
            {
                if (IsNullOrEmpty) { return null; }
                else
                {
                    if (Keys.Contains("BlancRef"))
                    {
                        return ((Noeud)(this["BlancRef"])).Keys;
                    }
                    else { return null; }
                }
            }
        }
        public List<string> MatriceTransformationKeys
        {
            get
            {
                if (IsNullOrEmpty) { return null; }
                else
                {
                    if (Keys.Contains("MatriceTransformation"))
                    {
                        return ((Noeud)(this["MatriceTransformation"])).Keys;
                    }
                    else { return null; }
                }
            }
        }
        internal WorkingSpace WorkingSpace(string key)
        {
            if (IsNullOrEmpty) { return null; }
            if (Keys.Contains("WorkingSpaces"))
            {
                if (((Noeud)this["WorkingSpaces"]).Keys.Contains(key))
                {
                    return new WorkingSpace((Noeud)((Noeud)this["WorkingSpaces"])[key]);
                }
                else { return null; }
            }
            else { return null; }
        }
        internal XYZ BlancRef(string name)
        {
            if (IsNullOrEmpty) { return null; }
            if (Keys.Contains("BlancRef"))
            {
                if (((Noeud)this["BlancRef"]).Keys.Contains(name))
                {
                    return new XYZ((Noeud)((Noeud)this["BlancRef"])[name]);
                }
                else { return null; }
            }
            else { return null; }
        }
        internal Matrice MatriceTransformation(string name)
        {
            if (IsNullOrEmpty) { return null; }
            if (Keys.Contains("MatriceTransformation"))
            {
                if (((Noeud)this["MatriceTransformation"]).Keys.Contains(name))
                {
                    return new DefMatrice((Noeud)((Noeud)this["MatriceTransformation"])[name]);
                }
                else { return null; }
            }
            else { return null; }
        }
        internal WorkingSpace Luminance
        {
            get
            {
                if (((Noeud)this["General"]).Keys.Contains("Luminance"))
                {
                    return WorkingSpace(((Noeud)this["General"]).GetValue<string>("Luminance"));
                }
                else { return null; }
            }
        }
        internal ParametreCouleurs(string namepath, string filename, bool setup = false) : base("Couleurs", namepath, filename, setup) { }
        protected override void DefaultValues()
        {
            Add("General");
            ((Noeud)this["General"]).Add("CoefCieRouge", 0.2126);
            ((Noeud)this["General"]).Add("CoefCieVert", 0.7152);
            ((Noeud)this["General"]).Add("CoefCieBleu", 0.0722);
            Rgb sepia = new Rgb(118, 98, 38) { Name = "Sepia" };
            ((Noeud)this["General"]).Add(sepia.ToNoeud());
            ((Noeud)this["General"]).Add("IntentCie1", 216);
            ((Noeud)this["General"]).Add("IntentCie2", 27);
            ((Noeud)this["General"]).Add("IntentCie3", 24389);
            ((Noeud)this["General"]).Add("WorkingSpaceReference", "sRGB");
            Add("MatriceTransformation");
            Matrice matrice;
            DefMatrice dmatrice;
            matrice = new Matrice(3, 3);
            matrice.SetLigne(0, 1, 0, 0);
            matrice.SetLigne(1, 0, 1, 0);
            matrice.SetLigne(2, 0, 0, 1);
            dmatrice = new DefMatrice("XyzScaling", matrice);
            ((Noeud)this["MatriceTransformation"]).Add(dmatrice);
            matrice = new Matrice(3, 3);
            matrice.SetLigne(0, 0.8951000, 0.2664000, -0.1614000);
            matrice.SetLigne(1, -0.7502000, 1.7135000, 0.0367000);
            matrice.SetLigne(2, 0.0389000, -0.0685000, 1.0296000);
            dmatrice = new DefMatrice("Bradford", matrice);
            ((Noeud)this["MatriceTransformation"]).Add(dmatrice);
            matrice = new Matrice(3, 3);
            matrice.SetLigne(0, 0.4002400, 0.7076000, -0.0808100);
            matrice.SetLigne(1, -0.2263000, 1.1653200, 0.0457000);
            matrice.SetLigne(2, 0.0000000, 0.0000000, 0.9182200);
            dmatrice = new DefMatrice("Von Kries", matrice);
            ((Noeud)this["MatriceTransformation"]).Add(dmatrice);
            matrice = new Matrice(3, 3);
            matrice.SetLigne(0, 1.2694000, -0.0988, -0.1706000);
            matrice.SetLigne(1, -0.8364000, 1.8006, 0.0357000);
            matrice.SetLigne(2, 0.0297000, -0.0315, 1.0018000);
            dmatrice = new DefMatrice("Sharp", matrice);
            ((Noeud)this["MatriceTransformation"]).Add(dmatrice);
            matrice = new Matrice(3, 3);
            matrice.SetLigne(0, 0.7982000, 0.3389000, -0.1371000);
            matrice.SetLigne(1, -0.5918000, 1.5512000, 0.0406000);
            matrice.SetLigne(2, 0.0008000, 0.2390000, 0.9753000);
            dmatrice = new DefMatrice("CMCCAT2000", matrice);
            ((Noeud)this["MatriceTransformation"]).Add(dmatrice);
            Add("BlancRef");
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("A", 1.098466069, 1, 0.35582280));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("B", 0.990927448, 1, 0.853132732));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("C", 0.980705972, 1, 1.182249494));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("D50", 0.964211994, 1, 0.825188285));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("D55", 0.956797053, 1, 0.921480586));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("D65", 0.950428545, 1, 1.088900371));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("D75", 0.950171560, 1, 1.226393521));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("E", 1, 1, 1));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F01", 0.928336348, 1, 1.036647197));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F02", 0.991446615, 1, 0.673159423));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F03", 1.037534872, 1, 0.498605123));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F04", 1.091472638, 1, 0.388132609));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F05", 0.908719701, 1, 0.987228867));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F06", 0.973091284, 1, 0.601905498));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F07", 0.950171560, 1, 1.086296420));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F08", 0.964125436, 1, 0.823331010));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F09", 1.003647971, 1, 0.678683512));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F10", 0.961735119, 1, 0.817123326));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F11", 1.008988943, 1, 0.642616604));
            ((Noeud)this["BlancRef"]).Add((Noeud)new XYZ("F12", 1.080462897, 1, 0.392275166));
            Add("WorkingSpaces");
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("Adobe RGB 1998",
                    new Yxy(0.6400, 0.3300, 0.297361),
                    new Yxy(0.2100, 0.7100, 0.627355),
                    new Yxy(0.1500, 0.0600, 0.075285),
                    "D65",

                    TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("Apple RGB",
                    new Yxy(0.6250, 0.3400, 0.24634),
                    new Yxy(0.2800, 0.5950, 0.672034),
                    new Yxy(0.1550, 0.0700, 0.083332),
                    "D65",
                    TypeGamma.Valeur, 1.8));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("Best RGB",
                    new Yxy(0.7347, 0.2653, 0.228457),
                    new Yxy(0.2150, 0.7750, 0.737352),
                    new Yxy(0.1300, 0.0350, 0.034191),
                    "D50",
                    TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("Beta RGB",
                    new Yxy(0.6888, 0.3112, 0.303273),
                    new Yxy(0.1986, 0.7551, 0.663786),
                    new Yxy(0.1265, 0.0352, 0.032941),
                    "D50",
                    TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("Cie RGB",
                    new Yxy(0.7350, 0.2650, 0.176204),
                    new Yxy(0.2740, 0.7170, 0.812985),
                    new Yxy(0.1670, 0.0090, 0.010811),
                    "E",
                    TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("ColorMatch RGB",
                    new Yxy(0.6300, 0.3400, 0.274884),
                    new Yxy(0.2950, 0.6050, 0.658132),
                    new Yxy(0.1500, 0.0750, 0.066985),
                    "D50",
                    TypeGamma.Valeur, 1.8));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("Don RGB 4",
                    new Yxy(0.6960, 0.3000, 0.278350),
                    new Yxy(0.2150, 0.7650, 0.687970),
                    new Yxy(0.1300, 0.0350, 0.033680),
                    "D50",
                    TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("ECI RGB V2",
                    new Yxy(0.6700, 0.3300, 0.320250),
                    new Yxy(0.2100, 0.7100, 0.602071),
                    new Yxy(0.1400, 0.0800, 0.077679),
                    "D50",
                    TypeGamma.L));
            ((Noeud)this["WorkingSpaces"]).Add(
                new WorkingSpace("EKTA SPACE PS5",
                    new Yxy(0.6950, 0.3050, 0.260629),
                    new Yxy(0.2600, 0.7000, 0.734946),
                    new Yxy(0.1100, 0.0050, 0.004425),
                    "D50",
                    TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
               new WorkingSpace("NTSC RGB",
                   new Yxy(0.6700, 0.3300, 0.298839),
                   new Yxy(0.2100, 0.7100, 0.586811),
                   new Yxy(0.1400, 0.0800, 0.114350),
                   "C",
                   TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
              new WorkingSpace("PAL/SECAM RGB",
                  new Yxy(0.6400, 0.3300, 0.222021),
                  new Yxy(0.2900, 0.6000, 0.706645),
                  new Yxy(0.1500, 0.0600, 0.071334),
                  "D65",
                  TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
              new WorkingSpace("PROPHOTO RGB",
                  new Yxy(0.7347, 0.2653, 0.288040),
                  new Yxy(0.1596, 0.8404, 0.711874),
                  new Yxy(0.0366, 0.0001, 0.000086),
                  "D50",
                  TypeGamma.Valeur, 1.8));
            ((Noeud)this["WorkingSpaces"]).Add(
              new WorkingSpace("SMPTE-C RGB",
                  new Yxy(0.6300, 0.3400, 0.212395),
                  new Yxy(0.3100, 0.5950, 0.701049),
                  new Yxy(0.1550, 0.0700, 0.086556),
                  "D65",
                  TypeGamma.Valeur, 2.2));
            ((Noeud)this["WorkingSpaces"]).Add(
              new WorkingSpace("sRGB",
                  new Yxy(0.6400, 0.3300, 0.212656),
                  new Yxy(0.3000, 0.6000, 0.715158),
                  new Yxy(0.1500, 0.0600, 0.072188),
                  "D65",
                  TypeGamma.sRGB));
            ((Noeud)this["WorkingSpaces"]).Add(
              new WorkingSpace("WIDE GAMUT RGB",
                  new Yxy(0.7350, 0.2650, 0.258187),
                  new Yxy(0.1150, 0.8260, 0.724938),
                  new Yxy(0.1570, 0.0180, 0.016875),
                  "D50",
                  TypeGamma.Valeur, 2.2));
        }

    }
}
