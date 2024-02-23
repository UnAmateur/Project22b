using System.Collections.Generic;

namespace LibCore.Parametrages.Definitions
{
    internal class DefDict<T> : Definition
    {
        public DefDict() : this("Array") { }
        public DefDict(string name) : this(name, null) { }
        public DefDict(string name, List<T> list) : base(name)
        {
            for (int index = 0; index < list.Count; index++)
            {
                Add(index, list[index]);

            }
        }
        protected void Add(int index, T value)
        {
            if (value is Noeud valueNoeud)
            {
                Add(valueNoeud);
            }
            else if (value is Core valueCore)
            {
                Add(valueCore.Name, valueCore);
            }
            else
            {
                Add("Item-" + index.ToString("0000"), value);
            }
        }
        public DefDict(Noeud noeud) : base(noeud)
        {

        }
        protected override void Create() { Clear(); }
    }

}
