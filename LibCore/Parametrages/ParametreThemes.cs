using LibCore.Parametrages.Definitions;

using System.Drawing;

namespace LibCore.Parametrages
{

    public class ParametreThemes : ParametreBase
    {
        public Color Fond { get { return new DefCouleur((Noeud)this["General", "Fond"]); } }
        public Color Texte { get { return new DefCouleur((Noeud)this["General", "Texte"]); } }
        public Font Police { get { return new DefPolice((Noeud)this["General", "Police"]); } }
        internal DefGraphique Graphique(string graphique) { return new DefGraphique((Noeud)this["Graphiques", graphique]); }
        internal Noeud ChoixCouleurRgb { get { return (Noeud)this["ChoixCouleurs", "Rgb"]; } }
        internal Noeud ChoixCouleurTsl { get { return (Noeud)this["ChoixCouleurs", "Tsl"]; } }
        internal Noeud ChoixCouleurCmjk { get { return (Noeud)this["ChoixCouleurs", "Cmjk"]; } }
        internal ParametreThemes(string namepath, string filename, bool setup = false) : base("Themes", namepath, filename, setup) { }

        protected override void DefaultValues()
        {
            Add("General");
            ((Noeud)this["General"]).Add(new DefCouleur("Fond", 0, 0, 0));
            ((Noeud)this["General"]).Add(new DefCouleur("Texte", 224, 224, 224));
            ((Noeud)this["General"]).Add(new DefPolice("Police", "Times New Romans", 10f, FontStyle.Regular));

            Add("ChoixCouleurs");

            ((Noeud)this["ChoixCouleurs"]).Add("Rgb");
            ((Noeud)this["ChoixCouleurs", "Rgb"]).Add("Graph");
            ((Noeud)this["ChoixCouleurs", "Rgb", "Graph"]).Add(new DefCouleur("Curseur", 255, 255, 255));
            ((Noeud)this["ChoixCouleurs", "Rgb"]).Add("Grad");
            ((Noeud)this["ChoixCouleurs", "Rgb", "Grad"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Rgb", "Grad"]).Add(new DefCouleur("Debut", 0, 0, 255));
            ((Noeud)this["ChoixCouleurs", "Rgb", "Grad"]).Add(new DefCouleur("Fin", 255, 255, 255));

            ((Noeud)this["ChoixCouleurs"]).Add("Tsl");
            ((Noeud)this["ChoixCouleurs", "Tsl"]).Add("Graph");
            ((Noeud)this["ChoixCouleurs", "Tsl", "Graph"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Tsl"]).Add("Grad-1");
            ((Noeud)this["ChoixCouleurs", "Tsl", "Grad-1"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Tsl", "Grad-1"]).Add(new DefCouleur("Debut", 224, 224, 224));
            ((Noeud)this["ChoixCouleurs", "Tsl", "Grad-1"]).Add(new DefCouleur("Fin", 32, 32, 32));
            ((Noeud)this["ChoixCouleurs", "Tsl"]).Add("Grad-2");
            ((Noeud)this["ChoixCouleurs", "Tsl", "Grad-2"]).Add(new DefCouleur("Curseur", 255, 255, 255));
            ((Noeud)this["ChoixCouleurs", "Tsl", "Grad-2"]).Add(new DefCouleur("Debut", 224, 224, 224));
            ((Noeud)this["ChoixCouleurs", "Tsl", "Grad-2"]).Add(new DefCouleur("Fin", 32, 32, 32));

            ((Noeud)this["ChoixCouleurs"]).Add("Cmjk");
            ((Noeud)this["ChoixCouleurs", "Cmjk"]).Add("Grad-1");
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-1"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-1"]).Add(new DefCouleur("Debut", 224, 224, 224));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-1"]).Add(new DefCouleur("Fin", 0, 255, 255));
            ((Noeud)this["ChoixCouleurs", "Cmjk"]).Add("Grad-2");
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-2"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-2"]).Add(new DefCouleur("Debut", 224, 224, 244));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-2"]).Add(new DefCouleur("Fin", 255, 0, 255));
            ((Noeud)this["ChoixCouleurs", "Cmjk"]).Add("Grad-3");
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-3"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-3"]).Add(new DefCouleur("Debut", 224, 224, 224));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-3"]).Add(new DefCouleur("Fin", 255, 255, 0));
            ((Noeud)this["ChoixCouleurs", "Cmjk"]).Add("Grad-4");
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-4"]).Add(new DefCouleur("Curseur", 0, 0, 0));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-4"]).Add(new DefCouleur("Debut", 224, 224, 224));
            ((Noeud)this["ChoixCouleurs", "Cmjk", "Grad-4"]).Add(new DefCouleur("Fin", 32, 32, 32));

            Add("Graphiques");

            ((Noeud)this["Graphiques"]).Add(
                new DefGraphique("Default",
                    new DefPinceau("Zone", 224, 224, 224),
                    new DefCrayon("Cadre", 0, 0, 0, 3f, null),
                    new DefAxe("Axe",
                        new DefCrayon(0, 0, 0, 3f),
                        new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Times New Romans", 10f, FontStyle.Bold))),
                    new DefAxe("Primaire",
                        new DefCrayon(0, 0, 0, 1f),
                        new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bell MT", 10f, FontStyle.Bold))),
                    new DefAxe("Secondaire",
                        new DefCrayon(0, 0, 0, 1f, new float[] { 5, 5 }),
                        new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bell MT", 9f, FontStyle.Regular))),
                    new DefAxe("Tertiaire",
                        new DefCrayon(0, 0, 0, 1f, new float[] { 2, 2 }),
                        new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bell MT", 8f, FontStyle.Regular | FontStyle.Italic)))));

            ((Noeud)this["Graphiques"]).Add(
                new DefGraphique("Histogramme",
                    new DefPinceau("Zone", 0, 0, 0),
                    new DefCrayon("Cadre", 255, 255, 255, 1f, null),
                    new DefAxe("Axe",
                        new DefCrayon(255, 255, 128, 3f),
                        new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bodoni MT", 10f, FontStyle.Bold))),
                    new DefAxe("Primaire",
                        new DefCrayon(255, 224, 224, 1f),
                         new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bodoni MT", 10f, FontStyle.Regular))),
                    new DefAxe("Secondaire",
                        new DefCrayon(255, 128, 32, 1f, new float[] { 5, 5 }),
                         new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bodoni MT", 9f, FontStyle.Regular))),
                    new DefAxe("Tertiaire",
                        new DefCrayon(32, 128, 255, 1f, new float[] { 2, 2 }),
                        new DefGraduation(new DefCrayon(0, 0, 0, 1f), new DefPolice("Bodoni MT", 8f, FontStyle.Regular | FontStyle.Italic)))));

            ((Noeud)this["Graphiques"]).Add(
               new DefGraphique("WorkingSpace",
                   new DefPinceau("Zone", 0, 0, 0),
                   new DefCrayon("Cadre", 255, 0, 255, 1f, null),
                   new DefAxe("Axe",
                       new DefCrayon(255, 255, 128, 3f),
                       new DefGraduation(new DefCrayon(255, 255, 255, 1f), new DefPolice("Times New Romans", 10f, FontStyle.Bold))),
                   new DefAxe("Primaire",
                       new DefCrayon(96, 96, 96, 1f),
                       new DefGraduation(new DefCrayon(96, 96, 96, 1f), new DefPolice("Times New Romans", 10f, FontStyle.Regular))),
                   new DefAxe("Secondaire",
                       new DefCrayon(64, 64, 64, 1f, new float[] { 5, 5 }),
                       new DefGraduation(new DefCrayon(64, 64, 64, 1f), new DefPolice("Times New Romans", 9f, FontStyle.Regular))),
                   new DefAxe("Tertiaire",
                       new DefCrayon(32, 128, 255, 1f, new float[] { 2, 2 }),
                       new DefGraduation(new DefCrayon(32, 32, 32, 1f), new DefPolice("Times New Romans", 8f, FontStyle.Regular | FontStyle.Italic)))));

        }
    }
}
