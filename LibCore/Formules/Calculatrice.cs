using LibCore.Parametrages;
using LibCore.Parametrages.Definitions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace LibCore.Formules
{
    public class Calculatrice : Core
    {
        public event EventHandler<ErreurEventArgs> Erreur;
        private const string NumbersList = "0123456789,";
        private const string PonctuationList = "{([;:])}+-/*%!^";
        private const string ComparaisonList = "<>=";
        private bool contient_des_variables = false;
        private Dictionary<string, DefToken> dictionaire = null;
        private Dictionary<string, DefToken> Symboles = null;
        private List<DefToken> Polonaise = null;
        private ItemVariable ItemVariables;
        public ItemVariable Variables { get { return ItemVariables; } }
        public double Variable { get { return ItemVariables["VAR"]; } set { ItemVariables["VAR"] = value; } }
        private string formule = string.Empty;
        private bool isErreur = false;
        public bool IsVariable { get { return contient_des_variables; } }
        public string Formule { get { return formule; } set { OnFormuleChanged(value); } }
        public bool IsErreur { get { return isErreur; } }

        public Calculatrice() : base("Calculatrice")
        {
            dictionaire = new Dictionary<string, DefToken>();
            Symboles = new Dictionary<string, DefToken>();
            ItemVariables = new ItemVariable();
            ItemVariables.ItemVariableErreur += Variables_ItemVariableErreur;
            foreach (string key in Parametres.Config.Operateurs.Keys)
            {
                dictionaire.Add(key, (DefToken)Parametres.Config.Operateurs[key]);
                if (dictionaire[key].IsSymbolique)
                {
                    Symboles.Add(dictionaire[key].Symbole, dictionaire[key]);
                }
            }
        }

        private void Variables_ItemVariableErreur(object sender, string e)
        {
            OnErreur(e);
        }

        public double Calcul()
        {
            if (Polonaise is null)
            {
                OnErreur(Parametres.Langues.Traduction("Erreurs", "E15"));
                return double.NaN;
            }
            else
            {
                Operateurs oper = new Operateurs();
                if (IsVariable)
                {
                    return oper.CalculItem(Polonaise, Variables);
                }
                else
                {
                    return oper.CalculItem(Polonaise, null);
                }
            }
        }

        public double[] Calcul(double[] values)
        {
            if (Polonaise is null)
            {
                OnErreur(string.Format(Parametres.Langues.Traduction("Erreurs", "E15"), formule));
                return null;
            }
            else
            {
                Operateurs oper = new Operateurs();
                if (IsVariable)
                {
                    double[] result = new double[values.Length];
                    for (int index = 0; index < result.Length; index++)
                    {
                        Variable = values[index];
                        result[index] = oper.CalculItem(Polonaise, Variables);
                    }
                    return result;
                }
                else
                {
                    OnErreur(string.Format(Parametres.Langues.Traduction("Erreurs", "E19"), formule));
                    return new double[] { oper.CalculItem(Polonaise, null) };
                }
            }
        }
        private void AfficheDect(List<DefToken> ItemList)
        {
            Console.WriteLine(formule);
            foreach (DefToken item in ItemList)
            {
                if (item.IsNumber) { Console.WriteLine(string.Format("Nombre      => {0,-10} {1,-10} ", item.Name, item.Valeur)); }
                else if (item.IsConstante) { Console.WriteLine(string.Format("Constante   => {0,-10} {1,-10}", item.Name, item.Valeur)); }
                else if (item.IsOperateur) { Console.WriteLine(string.Format("Operateur   => {0,-10}", item.Name)); }
                else if (item.IsPonctuation) { Console.WriteLine(string.Format("Ponctuation => {0,-10}", item.Symbole)); }
                else if (item.IsSpecial) { Console.WriteLine(string.Format("Special     => {0,-10}", item.Symbole)); }
                else if (item.IsVariable) { Console.WriteLine(string.Format("Variable    => {0,-10}", item.Name)); }
                else { Console.WriteLine(string.Format("{0,-10} {1,-10} ", item.Name, item.Symbole)); }
            }
        }

        protected void OnErreur(string value)
        {
            Erreur?.Invoke(this, new ErreurEventArgs(value));
        }
        private void OnFormuleChanged(string value)
        {
            contient_des_variables = false;
            if (string.IsNullOrEmpty(value)) { return; }
            if (value != formule)
            {
                if (!Convert(value, out List<DefToken> result, out string erreur))
                {
                    formule = string.Empty;
                    Polonaise = null;
                    isErreur = true;
                    OnErreur(erreur);

                }
                else
                {
                    formule = value;
                    isErreur = false;
                    if (result is null)
                    {
                        OnErreur(string.Format(Parametres.Langues.Traduction("Erreurs", "E15"), formule));
                        Polonaise = null;
                    }
                    else
                    {
                        Polonaise = result;
                        // AfficheDect(result);
                    }
                }
            }
        }
        /// <summary>
        /// Veficiation du nombre de caractere dans une chaine
        /// </summary>
        /// <param name="formule">chaine à verifier</param>
        /// <param name="c1">1° caractere à verifier</param>
        /// <param name="c2">2° caractere à verifier</param>
        /// <param name="nb">nombre de caractere manquant (c1 ou c2)</param>
        /// <returns>true si valide sinon false</returns>
        private bool Verification(string formule, char c1, char c2, out int nb)
        {
            int result = 0;
            foreach (char c in formule)
            {
                if (c == c1) { result++; }
                if (c == c2) { result--; }
            }
            nb = result;
            return result == 0;
        }
        /// <summary>
        /// Convertion d'une formule chaine en liste de DefToken
        /// </summary>
        /// <param name="chaine">formule à convertir</param>
        /// <param name="result">liste resultat si valide sinon null</param>
        /// <param name="erreur">chaine d'erreur</param>
        /// <returns>true si convertit sinon false</returns>
        private bool Convert(string chaine, out List<DefToken> result, out string erreur)
        {
            chaine = chaine.ToUpper();
            chaine = chaine.Replace('.', ',');
            erreur = string.Empty;
            bool IsErreur = false;
            int Nb;
            /// Verification 
            if (!Verification(chaine, '(', ')', out Nb))
            {
                result = null;
                if (Nb != 0)
                {
                    result = null;
                    erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E12"), Math.Abs(Nb), chaine);
                    return false;
                }
            }
            else if (!Verification(chaine, '[', ']', out Nb))
            {
                result = null;
                if (Nb != 0)
                {
                    result = null;
                    erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E13"), Math.Abs(Nb), chaine);
                    return false;
                }
            }
            else if (!Verification(chaine, '{', '}', out Nb))
            {
                result = null;
                if (Nb != 0)
                {
                    result = null;
                    erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E14"), Math.Abs(Nb), chaine);
                    return false;
                }
            }
            else { }
            /// Transformation
            bool LastIsComparaison = false;
            bool LastIsNumber = false;
            bool LastIsChar = false;
            string m = string.Empty;
            result = new List<DefToken>();
            /// Separe les divers elements
            for (int index = 0; index < chaine.Length; index++)
            {
                if (IsNumber(chaine[index]))
                {
                    if (!LastIsNumber)
                    {
                        LastIsChar = false;
                        LastIsComparaison = false;
                        LastIsNumber = true;
                        m += "_" + chaine[index];
                    }
                    else
                    {
                        m += chaine[index];
                    }
                }
                else if (IsPonctuation(chaine[index]))
                {
                    LastIsComparaison = false;
                    LastIsChar = false;
                    LastIsNumber = false;

                    m += "_" + chaine[index];

                }
                else if (IsComparaison(chaine[index]))
                {
                    if (!LastIsComparaison)
                    {
                        LastIsChar = false;
                        LastIsNumber = false;
                        LastIsComparaison = true;
                        m += "_" + chaine[index];
                    }
                    else { m += chaine[index]; }
                }
                else
                {
                    if (!LastIsChar)
                    {
                        LastIsChar = true;
                        LastIsNumber = false;
                        LastIsComparaison = false;
                        m += "_" + chaine[index];
                    }
                    else
                    {
                        m += chaine[index];
                    }
                }
            }
            string[] tabFormule = m.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            /// Transforme en List<DefToken>
            List<DefToken> decoupage = new List<DefToken>();
            bool variable = false;
            string provisoire = string.Empty;
            bool unaire = false;
            for (int index = 0; index < tabFormule.Length; index++)
            {
                if (variable & tabFormule[index] != "}")
                {
                    provisoire += tabFormule[index];
                }
                else if (tabFormule[index] == "{")
                {
                    variable = true;
                }
                else if (tabFormule[index] == "}")
                {
                    variable = false;
                    decoupage.Add(new DefToken(provisoire));
                    provisoire = string.Empty;
                }
                else if (tabFormule[index] == "-" && index == 0)
                {
                    unaire = true;
                }
                else if (tabFormule[index] == "-" && decoupage.Count == 0)
                {
                    unaire = true;
                }
                else if (tabFormule[index] == "-" && !decoupage[decoupage.Count - 1].IsNumber)
                {
                    unaire = true;
                }
                else if (Find(tabFormule[index], out DefToken value)) { decoupage.Add(value); }
                else if (tabFormule[index].Length == 1)
                {
                    if (char.IsLetter(tabFormule[index][0]) & !char.IsDigit(tabFormule[index][0]))
                    {
                        if (variable)
                        {
                            decoupage.Add(new DefToken(tabFormule[index]));
                        }
                        else
                        {
                            result = null;
                            erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E17"), tabFormule[index], chaine);
                            IsErreur = true;
                            break;
                        }
                    }
                    else if (double.TryParse(tabFormule[index], out double numbers))
                    {
                        if (unaire)
                        {
                            decoupage.Add(new DefToken(-numbers));
                            unaire = false;
                        }
                        else
                        {
                            decoupage.Add(new DefToken(numbers));
                        }
                    }
                    else
                    {
                        result = null;
                        erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E18"), tabFormule[index], chaine);
                        IsErreur = true;
                        break;
                    }

                }
                else if (double.TryParse(tabFormule[index], out double numbers))
                {
                    if (unaire)
                    {
                        decoupage.Add(new DefToken(-numbers));
                        unaire = false;
                    }
                    else
                    {
                        decoupage.Add(new DefToken(numbers));
                    }
                }
                else
                {
                    result = null;
                    erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E10"), tabFormule[index], chaine);
                    IsErreur = true;
                    break;
                }
            }
            if (IsErreur) { return false; }
            /// Transforme en List<DefToken> en systeme polonaise
            List<DefToken> polonaise = new List<DefToken>();
            Stack<DefToken> pile = new Stack<DefToken>();
            Variables.Clear();
            foreach (DefToken dt in decoupage)
            {
                if (dt != null)
                {
                    if (dt.IsVariable)
                    {
                        contient_des_variables = true;
                        Variables.Add(dt.Name);
                        polonaise.Add(dt);
                    }
                    else if (dt.IsNumber)
                    {
                        polonaise.Add(dt);
                    }
                    else if (dt.IsConstante)
                    {
                        polonaise.Add(new DefToken(dt.Valeur));
                    }
                    else if (dt.IsPonctuation)
                    {
                        if (dt.Symbole == "{")
                        {
                            polonaise.Add(new DefToken('@'));
                            pile.Push(dt);
                        }
                        else if (dt.Symbole == "}")
                        {
                            if (pile.Count > 0)
                            {
                                while (pile.Peek().IsOperateur)
                                {
                                    polonaise.Add(pile.Pop());
                                    if (pile.Count == 0) { break; }
                                }
                                if (pile.Count > 0) { pile.Pop(); }
                            }
                        }
                        else if (dt.Symbole == "[")
                        {
                            polonaise.Add(new DefToken('@'));
                            pile.Push(dt);
                        }
                        else if (dt.Symbole == "]")
                        {
                            while (pile.Peek().IsOperateur)
                            {
                                polonaise.Add(pile.Pop());
                                if (pile.Count == 0) { break; }
                            }
                            if (pile.Count > 0) { pile.Pop(); }
                        }
                        else if (dt.Symbole == ";")
                        {
                            if (pile.Count != 0)
                            {
                                while (!pile.Peek().IsPonctuation)
                                {
                                    polonaise.Add(pile.Pop());
                                    if (pile.Count == 0) { break; }
                                }
                            }
                        }
                        else if (dt.Symbole == "(")
                        {
                            pile.Push(dt);
                        }
                        else if (dt.Symbole == ")")
                        {
                            while (pile.Peek().IsOperateur)
                            {
                                polonaise.Add(pile.Pop());
                                if (pile.Count == 0) { break; }
                            }
                            if (pile.Count > 0) { pile.Pop(); }
                        }
                        else if (dt.Symbole == ":")
                        {
                            polonaise.Add(new DefToken('@'));
                            while (!pile.Peek().IsPonctuation)
                            {
                                polonaise.Add(pile.Pop());
                                if (pile.Count == 0) { break; }
                            }
                        }
                        else
                        {
                            result = null;
                            erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E10"), dt.Name, chaine);
                            IsErreur = false;
                            break;
                        }
                    }
                    else if (dt.IsOperateur)
                    {
                        if (pile.Count > 0)
                        {
                            DefToken q1 = dt;
                            while (pile.Peek().IsOperateur)
                            {
                                DefToken q2 = pile.Peek();
                                if (q1.Association == TypeAssociation.Gauche && q1.Priorite <= q2.Priorite)
                                {
                                    polonaise.Add(pile.Pop());
                                }
                                else if (q1.Association == TypeAssociation.Droite && q1.Priorite < q2.Priorite)
                                {
                                    polonaise.Add(pile.Pop());
                                }
                                else { break; }
                                if (pile.Count == 0) { break; }
                            }

                        }
                        pile.Push(dt);
                    }
                    else
                    {
                        result = null;
                        erreur = string.Format(Parametres.Langues.Traduction("Erreurs", "E10"), dt.Name, chaine);
                        IsErreur = true;
                        break;
                    }
                }
            }
            if (IsErreur) { return false; }
            if (pile.Count > 0)
            {
                foreach (DefToken item in pile) { polonaise.Add(item); }
            }
            /// creation de la liste des variables            
            result = polonaise;
            erreur = string.Empty;
            return true;
        }
        private bool IsNumber(char c) { if (NumbersList.Contains(c)) { return true; } else { return false; } }
        private bool IsComparaison(char c) { if (ComparaisonList.Contains(c)) { return true; } else { return false; } }
        private bool IsPonctuation(char c) { if (PonctuationList.Contains(c)) { return true; } else { return false; } }
        /// <summary>
        /// Trouve la chaine "c" dans la symbolique ou le nom de la liste DefToken
        /// </summary>
        /// <param name="c">chaine ou caractere à trouver</param>
        /// <param name="tokens">DefToken correspondant</param>
        /// <returns>true si trouver sinon non</returns>
        private bool Find(string c, out DefToken tokens)
        {
            if (dictionaire.ContainsKey(c)) { tokens = dictionaire[c]; return true; }
            else if (Symboles.ContainsKey(c)) { tokens = Symboles[c]; return true; }
            else { tokens = null; return false; }
        }
    }

}
