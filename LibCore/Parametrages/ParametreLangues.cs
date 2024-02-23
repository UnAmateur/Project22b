namespace LibCore.Parametrages
{
    public class ParametreLangues : ParametreBase
    {
        public string Traduction(params string[] keys) { return (string)base[keys]; }
        internal ParametreLangues(string namepath, string filename, bool setup = false) : base("Langues", namepath, filename, setup) { }

        protected override void DefaultValues()
        {
            Add("General");
            ((Noeud)this["General"]).Add("Oui", "Oui");
            ((Noeud)this["General"]).Add("Non", "Non");
            ((Noeud)this["General"]).Add("Valide", "Valide");
            ((Noeud)this["General"]).Add("Annule", "Annule");
            ((Noeud)this["General"]).Add("Quitte", "Quitte");
            Add("Formulaires");
            ((Noeud)this["Formulaires"]).Add("Choix couleurs", "Choix couleurs");
            ((Noeud)this["Formulaires"]).Add("Choix workingspace", "Choix espace de couleur");
            Add("Mathematique");
            ((Noeud)this["Mathematique"]).Add("PO", " Parenthese ouvrante hierrachise les operations ");
            ((Noeud)this["Mathematique"]).Add("PF", " Parenthese fermante hierarchise les operations ");
            ((Noeud)this["Mathematique"]).Add("CO", " Crochet ouvrant: debut d'une liste ");
            ((Noeud)this["Mathematique"]).Add("CF", " Crochet fermant: fin d'une liste ");
            ((Noeud)this["Mathematique"]).Add("AO", " Accolade ouvante : debut de definition d'une variable ");
            ((Noeud)this["Mathematique"]).Add("AF", " Accolade fermante : fin de definition d'une variable ");
            ((Noeud)this["Mathematique"]).Add("SL", " Separateur des valeurs dans une liste ");
            ((Noeud)this["Mathematique"]).Add("VAR", " Variable generale defini automatiquement ne doit pas etre mise entre accolade (provoque une errreur) ");
            ((Noeud)this["Mathematique"]).Add("ENT", " Tronque la valeur entiere ");
            ((Noeud)this["Mathematique"]).Add("ARH", " Arrondi à la valeur la plus grande ");
            ((Noeud)this["Mathematique"]).Add("ARB", " Arrondi à la valeur la plus basse ");
            ((Noeud)this["Mathematique"]).Add("NEG", " Negation ");
            ((Noeud)this["Mathematique"]).Add("INV", " Inverse ");
            ((Noeud)this["Mathematique"]).Add("ABS", " Valeur absolue ");
            ((Noeud)this["Mathematique"]).Add("COS", " Cosinus trigonometrique ");
            ((Noeud)this["Mathematique"]).Add("SIN", " Sinus trigonometrique ");
            ((Noeud)this["Mathematique"]).Add("TAN", " Tangente trigonometrique ");
            ((Noeud)this["Mathematique"]).Add("TANXY", " Retourne l'angle formé par la tangente trigonometrique de {x;y}");
            ((Noeud)this["Mathematique"]).Add("ACOS", " Retourne l'angle du cosinus trigonometrique ");
            ((Noeud)this["Mathematique"]).Add("ASIN", " Retourne l'angle du sinus trigonometrique ");
            ((Noeud)this["Mathematique"]).Add("ATAN", " Retourne l'angle de la tangente trigonometrique ");
            ((Noeud)this["Mathematique"]).Add("COSH", " Cosinus hyperbolique ");
            ((Noeud)this["Mathematique"]).Add("SINH", " Sinus hyperbolique ");
            ((Noeud)this["Mathematique"]).Add("TANH", " Tangente hyperbolique ");
            ((Noeud)this["Mathematique"]).Add("EXP", " Exponentielle ");
            ((Noeud)this["Mathematique"]).Add("LOG", " Logarithme de base 10 ");
            ((Noeud)this["Mathematique"]).Add("LN", " Logarithme neperien ");
            ((Noeud)this["Mathematique"]).Add("FAC", " Factorielle ");
            ((Noeud)this["Mathematique"]).Add("SQR", " Racine carrée ");
            ((Noeud)this["Mathematique"]).Add("ADD", " Addition ");
            ((Noeud)this["Mathematique"]).Add("SUB", " Soustraction ");
            ((Noeud)this["Mathematique"]).Add("MUL", " Multiplication ");
            ((Noeud)this["Mathematique"]).Add("DIV", " Division ");
            ((Noeud)this["Mathematique"]).Add("MOD", " Reste de la division ");
            ((Noeud)this["Mathematique"]).Add("POW", " Puissance ");
            ((Noeud)this["Mathematique"]).Add("MAX", " Maximum ");
            ((Noeud)this["Mathematique"]).Add("MIN", " Minimum ");
            ((Noeud)this["Mathematique"]).Add("MOY", " Moyenne ");
            ((Noeud)this["Mathematique"]).Add("SUM", " Somme ");
            ((Noeud)this["Mathematique"]).Add("INF", " Inferieur à ");
            ((Noeud)this["Mathematique"]).Add("SUP", " Superieur à ");
            ((Noeud)this["Mathematique"]).Add("INFEG", " Inferieur ou egal à ");
            ((Noeud)this["Mathematique"]).Add("SUPEG", " Superieur ou egal à ");
            ((Noeud)this["Mathematique"]).Add("EG", "  Egal à ");
            ((Noeud)this["Mathematique"]).Add("SI", " Condition ; Vrai ; Faux");
            ((Noeud)this["Mathematique"]).Add("E", " La constante e ");
            ((Noeud)this["Mathematique"]).Add("PI", " La constante PI ");

            Add("Couleurs");
            ((Noeud)this["Couleurs"]).Add("Rouge", "Rouge");
            ((Noeud)this["Couleurs"]).Add("Vert", "Vert");
            ((Noeud)this["Couleurs"]).Add("Bleu", "Bleu");
            ((Noeud)this["Couleurs"]).Add("Gamma", "Gamma");
            ((Noeud)this["Couleurs"]).Add("Illuminant", "Illuminant");
            ((Noeud)this["Couleurs"]).Add("Reference", "Reference");
            Add("BlancRef");
            ((Noeud)this["BlancRef"]).Add("A", "Incandescent / Tungstène");
            ((Noeud)this["BlancRef"]).Add("B", "Ensoleillement à midi, solaire directe");
            ((Noeud)this["BlancRef"]).Add("C", "Feu de jour du ciel septentrional");
            ((Noeud)this["BlancRef"]).Add("D50", "Lumière d'horizon");
            ((Noeud)this["BlancRef"]).Add("D55", "Milieu de matinée / à la mi-annonce");
            ((Noeud)this["BlancRef"]).Add("D65", "Midi à la lumière du jour");
            ((Noeud)this["BlancRef"]).Add("D75", "Le ciel du nord");
            ((Noeud)this["BlancRef"]).Add("D93", "Moniteurs à luminophores bleu à haute efficacité");
            ((Noeud)this["BlancRef"]).Add("E", "Energie égale");
            ((Noeud)this["BlancRef"]).Add("F1", "Fluorescence de la lumière du jour");
            ((Noeud)this["BlancRef"]).Add("F2", "Fluorescent blanc froid");
            ((Noeud)this["BlancRef"]).Add("F3", "Fluorescent blanc fluorescent");
            ((Noeud)this["BlancRef"]).Add("F4", "Fluorescent blanc chaud");
            ((Noeud)this["BlancRef"]).Add("F5", "Fluorescence de la lumière du jour");
            ((Noeud)this["BlancRef"]).Add("F6", "Fluorescent blanc clair");
            ((Noeud)this["BlancRef"]).Add("F7", "Simulateur D65, simulateur de lumière du jour");
            ((Noeud)this["BlancRef"]).Add("F8", "Simulateur D50, Sylvania F40 Design 50");
            ((Noeud)this["BlancRef"]).Add("F9", "Fluorescence deluxe blanche froide");
            ((Noeud)this["BlancRef"]).Add("F10", "Philips TL85, Ultralume 50(Éclairage du jour à l'horizon)");
            ((Noeud)this["BlancRef"]).Add("F11", "Philips TL84, Ultralume 40(soleil à l'elevation)");
            ((Noeud)this["BlancRef"]).Add("F12", "Philips TL83, Ultralume 30(blanc chaud)");
            Add("WorkingSpace");
            ((Noeud)this["WorkingSpace"]).Add("Rouge", "Rouge");
            ((Noeud)this["WorkingSpace"]).Add("Vert", "Vert");
            ((Noeud)this["WorkingSpace"]).Add("Bleu", "Bleu");
            Add("Erreurs");
            ((Noeud)this["Erreurs"]).Add("E10", "Erreur => probleme de transformation de \"{0}\" dans {1}");
            ((Noeud)this["Erreurs"]).Add("E12", "Erreur => difference de [{0}] parenthese(s) dans la formule : {1}");
            ((Noeud)this["Erreurs"]).Add("E13", "Erreur => difference de [{0}] crochet(s) dans la formule : {1}");
            ((Noeud)this["Erreurs"]).Add("E14", "Erreur => difference de [{0}] d'accolade(s) dans la formule : {1}");
            ((Noeud)this["Erreurs"]).Add("E15", "Erreur => Il n'y a pas de formule valide");
            ((Noeud)this["Erreurs"]).Add("E16", "Erreur => Il y a plusieurs variables : {0}");
            ((Noeud)this["Erreurs"]).Add("E17", "Erreur => Probleme de variable \"{0}\" dans {1}");
            ((Noeud)this["Erreurs"]).Add("E18", "Erreur => Probleme \"{0}\" dans {1}");
            ((Noeud)this["Erreurs"]).Add("E19", "Erreur => Il n'y a pas de variables : {0}");
        }




    }
}
