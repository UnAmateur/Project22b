using LibCore.Parametrages.Definitions;

using System;

namespace LibCore.Parametrages
{
    public class ParametreConfig : ParametreBase
    {
        public Noeud Path { get { return (Noeud)this["Path"]; } }
        public Noeud Files { get { return (Noeud)this["Files"]; } }
        public Noeud Formules { get { return (Noeud)this["Formules"]; } }
        public Noeud Operateurs { get { return (Noeud)this["Operateurs"]; } }
        internal ParametreConfig(bool setup = false) : base("Config", "", "Config", setup) { }
        protected override void DefaultValues()
        {
            Add("Path");
            ((Noeud)this["Path"]).Add("Couleurs", "Couleurs");
            ((Noeud)this["Path"]).Add("Themes", "Themes");
            ((Noeud)this["Path"]).Add("Langues", "Lang");
            Add("Files");
            ((Noeud)this["Files"]).Add("Couleurs", "Default");
            ((Noeud)this["Files"]).Add("Themes", "Default");
            ((Noeud)this["Files"]).Add("Langues", "Default");
            Add("Formules");
            ((Noeud)this["Formules"]).Add("Essais", "2+3");
            Add("Operateurs");
            ((Noeud)this["Operateurs"]).Add(new DefToken("PO", "("));
            ((Noeud)this["Operateurs"]).Add(new DefToken("PF", ")"));
            ((Noeud)this["Operateurs"]).Add(new DefToken("CO", "["));
            ((Noeud)this["Operateurs"]).Add(new DefToken("CF", "]"));
            ((Noeud)this["Operateurs"]).Add(new DefToken("AO", "{"));
            ((Noeud)this["Operateurs"]).Add(new DefToken("AF", "}"));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SL", ";"));
            ((Noeud)this["Operateurs"]).Add(new DefToken("VAR"));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ENT", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ARH", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ARB", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("NEG", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("INV", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ABS", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("COS", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SIN", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("TAN", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("TANXY", TypeAssociation.Droite, 7, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ACOS", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ASIN", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ATAN", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("COSH", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SINH", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("TANH", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("EXP", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("LOG", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("LN", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("FAC", "!", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SQR", TypeAssociation.Droite, 7, 1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("ADD", "+", TypeAssociation.Gauche, 1, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SUB", "-", TypeAssociation.Gauche, 1, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("MUL", "*", TypeAssociation.Gauche, 2, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("DIV", "/", TypeAssociation.Gauche, 2, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("MOD", "%", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("POW", "^", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("INF", "<", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SUP", ">", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("INFEG", "<=", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SUPEG", ">=", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("EG", "=", TypeAssociation.Gauche, 5, 2));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SI", "", TypeAssociation.Droite, 100, 3));
            ((Noeud)this["Operateurs"]).Add(new DefToken("MAX", TypeAssociation.Droite, 100, -1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("MIN", TypeAssociation.Droite, 100, -1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("MOY", TypeAssociation.Droite, 100, -1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("SUM", TypeAssociation.Droite, 100, -1));
            ((Noeud)this["Operateurs"]).Add(new DefToken("E", Math.E));
            ((Noeud)this["Operateurs"]).Add(new DefToken("PI", Math.PI));
        }

    }
}
