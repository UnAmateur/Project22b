namespace LibCore
{
    internal enum TypeSelecteur { None, Horizontal, Vertical }
    internal enum TypeSelectTheme { Default }
    public enum TypeGraphTheme { Default, Histogramme, WorkingSpace }
    public enum TypeCurseur { Carre, Rond, None }
    internal enum TypePoint { Cercle, Carre, FlecheB, FlecheG, FlecheD, FlecheH, Losange, None }
    internal enum TypeGamma { Valeur, sRGB, L }
    public enum TypeSens { Verticale, Horizontale, None }
    public enum TypeGradient { Vertical, Horizontal }
    public enum TypePosition { Gauche, Centre, Droite, Haut, Bas }
    internal enum TypeItemTokens { Operateur, Ponctuation, Constante, Formule, None }
    internal enum TypeAssociation { Ponctuation, Gauche, Droite, None }
    /// <summary>
    /// Type de courbes pour le traçage (None correspond à un tracé par points
    /// </summary>
    internal enum TypeCourbes { None, LigneOuverte, LigneFermer, Spline, Colonne }
    internal enum TypeGraduation { Primaire = 0, Secondaire = 1, Tertiaire = 2 }
    public enum TypeGris { Moyen, Max, Min, Cie, Median }
}
