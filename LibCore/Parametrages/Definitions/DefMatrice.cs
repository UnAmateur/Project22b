using LibMath;

namespace LibCore.Parametrages.Definitions
{
    internal class DefMatrice : Definition
    {
        public static implicit operator Matrice(DefMatrice value) { return value.ToMatrice(); }

        private const string NameClasse = "Matrice";
        public DefMatrice() : base(NameClasse) { }
        public DefMatrice(string name, Matrice matrice) : base(name)
        {
            Add("Ligne", matrice.NBLigne);
            Add("Colonne", matrice.NBColonne);
            Add("Data");
            for (int index = 0; index < matrice.Length; index++)
            {
                ((Noeud)this["Data"]).Add("Item-" + index.ToString("0000"), matrice[index]);
            }
        }
        public DefMatrice(Noeud noeud) : base(noeud)
        {
            if (noeud.IsValid("Ligne", "Colonne", "Data"))
            {

            }
        }
        public Matrice ToMatrice()
        {
            Matrice matrice;
            int ligne = GetValue<int>("Ligne");
            int colonne = GetValue<int>("Colonne");
            matrice = new Matrice(ligne, colonne);
            for (int index = 0; index < matrice.Length; index++)
            {
                matrice[index] = ((Noeud)this["Data"]).GetValue<double>("Item-" + index.ToString("0000"));
            }
            return matrice;
        }
        protected override void Create()
        {
            Clear();
            Add("Ligne", 3);
            Add("Colonne", 3);
            Add(new DefArray<double>("Data", new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }
    }
}
