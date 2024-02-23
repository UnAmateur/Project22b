using System;
using System.Collections.Generic;
using System.Linq;

namespace LibCore.Formules
{
    public class ItemVariable : Core
    {
        internal event EventHandler<string> ItemVariableErreur;
        private Dictionary<string, double> items = new Dictionary<string, double>();

        public ItemVariable() : base("ItemVariable")
        {
            items.Add("VAR", double.NaN);
        }

        internal int Count { get { return items.Count; } }
        public double this[string key]
        {
            get
            {
                try
                {
                    return items[key];
                }
                catch
                {
                    OnErreur(key);
                    return double.NaN;
                }
            }
            set
            {
                try
                {
                    items[key] = value;
                }
                catch
                {
                    OnErreur(key);
                }

            }
        }
        public List<string> Keys { get { return items.Keys.ToList(); } }
        internal void Clear()
        {
            items.Clear();
            items.Add("VAR", double.NaN);
        }
        internal void Add(string name) { if (!items.ContainsKey(name)) { items.Add(name, double.NaN); } }
        internal void OnErreur(string value) { ItemVariableErreur?.Invoke(this, value); }

    }

}
