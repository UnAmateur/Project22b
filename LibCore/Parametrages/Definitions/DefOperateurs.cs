using System;

namespace LibCore.Parametrages.Definitions
{
    internal class DefOperateurs : Definition
    {
        public string Caractere { get { return GetValue<string>("Caractere"); } set { this["Caractere"] = value; } }
        public TypeAssociation Association
        {
            get { return GetValue(ConvertTypeAsso, "Association"); }
            set
            {
                this["Association"] = value.ToString();
            }
        }
        public TypeItemTokens TypeTokens
        {
            get { return GetValue(ConvertTypeTokens, "Type"); }
            set
            {
                this["Type"] = value.ToString();
            }
        }
        public int Priorite { get { return GetValue<int>("Priorite"); } set { this["Priorite"] = value; } }
        public int NbParametre { get { return GetValue<int>("Nbr Parametre"); } set { this["Nbr Parametre"] = value; } }
        public double Valeur { get { return GetValue<double>("Valeur"); } set { this["Valeur"] = value; } }

        public DefOperateurs() : this("Null", TypeItemTokens.None, "", TypeAssociation.None, 0, 0, 0) { }

        internal DefOperateurs(string name, TypeItemTokens type, string caractere, TypeAssociation asso, int priorite, int nbParams, double valeur) : base(name)
        {
            Add("Type", type);
            Add("Caractere", caractere);
            Add("Association", asso);
            Add("Priorite", priorite);
            Add("Nbr Parametre", nbParams);
            Add("Valeur", valeur);
        }
        /// <summary>
        /// Declare un operateur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caractere"></param>
        /// <param name="asso"></param>
        /// <param name="priorite"></param>
        /// <param name="nbParams"></param>
        public DefOperateurs(string name, string caractere, TypeAssociation asso, int priorite, int nbParams) : this(name, TypeItemTokens.Operateur, caractere, asso, priorite, nbParams, 0) { }
        /// <summary>
        /// Declare un operateur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caractere"></param>
        /// <param name="asso"></param>
        /// <param name="priorite"></param>
        /// <param name="nbParams"></param>
        public DefOperateurs(string name, TypeAssociation asso, int priorite, int nbParams) : this(name, TypeItemTokens.Operateur, string.Empty, asso, priorite, nbParams, 0) { }
        /// <summary>
        /// Declare une Ponctuation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caractere"></param>
        /// <summary>
        /// Declare une Ponctuation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caractere"></param>
        public DefOperateurs(string name, string caractere) : this(name, TypeItemTokens.Ponctuation, caractere, TypeAssociation.Ponctuation, 1000, 0, 0) { }
        /// <summary>
        /// Declare une constante
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caractere"></param>        
        /// <param name="valeur"></param>
        public DefOperateurs(string name, double valeur) : this(name, TypeItemTokens.Constante, string.Empty, TypeAssociation.None, 0, 0, valeur) { }

        protected override void Create()
        {
            Clear();
            Add("Type", TypeItemTokens.None);
            Add("Caractere", "");
            Add("Association", TypeAssociation.None);
            Add("Priorite", 0);
            Add("Nbr Parametre", 0);
            Add("Valeur", 0);
        }
        private TypeAssociation ConvertTypeAsso(object value)
        {
            if (Enum.TryParse(value.ToString(), out TypeAssociation result))
            {
                return result;
            }
            else { throw new ArgumentException("Erreur"); }
        }
        private TypeItemTokens ConvertTypeTokens(object value)
        {
            if (Enum.TryParse(value.ToString(), out TypeItemTokens result))
            {
                return result;
            }
            else { throw new ArgumentException("Erreur"); }
        }
    }

    internal class DefToken : Definition
    {
        /// <summary>
        /// Symbole du Token sinon chaine vide
        /// </summary>
        public string Symbole { get { if (Keys.Contains("Symbole")) { return GetValue<string>("Symbole"); } else { return string.Empty; } } set { this["Symbole"] = value; } }
        /// <summary>
        /// Priorité du Token sinon 0
        /// </summary>
        public int Priorite { get { if (Keys.Contains("Priorite")) { return GetValue<int>("Priorite"); } else { return 0; } } set { this["Priorite"] = value; } }
        /// <summary>
        /// Nombre de parametre pour l'operation sinon 0
        /// </summary>
        public int NbParametre { get { if (Keys.Contains("Nbr Parametre")) { return GetValue<int>("Nbr Parametre"); } else { return 0; } } set { this["Nbr Parametre"] = value; } }
        public TypeAssociation Association
        {
            get
            {
                if (Keys.Contains("Association")) { return GetValue(ConvertTypeAsso, "Association"); } else { return TypeAssociation.None; }
            }
            set { this["Association"] = value.ToString(); }
        }
        public double Valeur { get { if (Keys.Contains("Valeur")) { return GetValue<double>("Valeur"); } else { return 0; } } set { this["Valeur"] = value; } }
        public bool IsNumber { get { return IsValid("Valeur") & Name == "Number"; } }
        public bool IsConstante { get { return IsValid("Valeur") & Name != "Special"; } }
        public bool IsPonctuation { get { return IsValid("Symbole", "Priorite") & !IsValid("Nbr Parametre"); } }
        public bool IsOperateur { get { return IsValid("Association", "Priorite", "Nbr Parametre"); } }
        public bool IsSymbolique { get { return IsValid("Symbole") & Name != "Special"; } }
        public bool IsSpecial { get { return IsValid("Symbole") & Name == "Special"; } }
        public bool IsVariable { get { return Keys.Count == 0; } }
        internal DefToken() : this(("Token")) { }
        /// <summary>
        /// Declaration d'une variable
        /// </summary>
        /// <param name="name">nom de la variable</param>
        internal DefToken(string name) : base(name) { }
        /// <summary>
        /// Declaration d'un Token Speical pour le calcul
        /// </summary>
        /// <param name="special">caratere special</param>
        internal DefToken(char special) : this("Special", special) { }
        /// <summary>
        /// Declaratino d'un nombre
        /// </summary>
        /// <param name="valeur">Valeur du nombre</param>
        public DefToken(double valeur) : this("Number")
        {
            Add("Valeur", valeur);
        }
        /// <summary>
        /// Declaratino d'une constante
        /// </summary>
        /// <param name="name">Nom de la constante</param>
        /// <param name="valeur">Valeur de la constante</param>
        public DefToken(string name, double valeur) : this(name)
        {
            Add("Valeur", valeur);
        }
        /// <summary>
        /// Declaration d'une ponctuation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbole"></param>
        public DefToken(string name, string symbole) : this(name)
        {
            Add("Symbole", symbole);
            Add("Priorite", 1000);
        }
        /// <summary>
        /// Declaration d'un operateur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="asso"></param>
        /// <param name="priorite"></param>
        /// <param name="nbparametre"></param>
        public DefToken(string name, TypeAssociation asso, int priorite, int nbparametre) : this(name)
        {
            Add("Association", asso);
            Add("Priorite", priorite);
            Add("Nbr Parametre", nbparametre);
        }
        /// <summary>
        /// Declaration d'un operateur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbole"></param>
        /// <param name="asso"></param>
        /// <param name="priorite"></param>
        /// <param name="nbparametre"></param>
        public DefToken(string name, string symbole, TypeAssociation asso, int priorite, int nbparametre) : this(name)
        {
            Add("Symbole", symbole);
            Add("Association", asso);
            Add("Priorite", priorite);
            Add("Nbr Parametre", nbparametre);
        }
        /// <summary>
        /// Declaration à partir d'un noeud ( nous ne validons le noeud qu'a l'execution )
        /// </summary>
        /// <param name="noeud"></param>
        /// <exception cref="ArgumentException"></exception>
        public DefToken(Noeud noeud) : base(noeud) { if (noeud is null) { throw new ArgumentException("Noeud null"); } }
        protected override void Create() { Name = "Token"; }
        private TypeAssociation ConvertTypeAsso(object value)
        {
            if (Enum.TryParse(value.ToString(), out TypeAssociation result))
            {
                return result;
            }
            else { throw new ArgumentException("Erreur"); }
        }
    }
}
