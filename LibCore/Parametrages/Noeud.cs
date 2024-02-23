using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace LibCore.Parametrages
{
    [Serializable]
    public class Noeud : Core, IXmlSerializable
    {
        private readonly Dictionary<string, object> items = new Dictionary<string, object>();
        public List<string> Keys { get { return items.Keys.ToList(); } }
        public bool IsNullOrEmpty { get { if (items is null) { return true; } else { if (items.Count == 0) { return true; } else { return false; } } } }


        #region operateur THIS
        /// <summary>
        /// Retourne la valeur de la derniere clé trouvé
        /// </summary>
        /// <param name="strings">liste des clé en cascade</param>
        /// <returns>null si la clé n'existe pas</returns>
        public object this[params string[] strings]
        {
            get
            {
                if (items.Count != 0)
                {
                    if (strings.Count() == 1)
                    {
                        if (items.ContainsKey(strings[0])) { return items[strings[0]]; } else { return null; }
                    }
                    else
                    {
                        object result = null;
                        foreach (string key in strings)
                        {
                            if (result is null)
                            {
                                if (items.ContainsKey(key))
                                {
                                    if (items[key] is Noeud)
                                    {
                                        result = items[key];
                                    }
                                    else
                                    {
                                        result = null;
                                        break;
                                    }
                                }
                                else
                                {
                                    result = null;
                                    break;
                                }
                            }
                            else
                            {
                                if (result is Noeud donnees)
                                {
                                    if (donnees.Keys.Contains(key))
                                    {
                                        result = donnees[key];
                                    }
                                    else
                                    {
                                        result = null;
                                        break;
                                    }
                                }
                                else
                                {
                                    result = null;
                                    break;
                                }
                            }
                        }
                        return result;
                    }
                }
                else { return null; }
            }
        }
        /// <summary>
        /// Valeur de la clé 
        /// </summary>
        /// <param name="key">clé</param>
        /// <returns>null si la clé n'existe pas</returns>
        public object this[string key]
        {
            get { if (items.ContainsKey(key)) { return items[key]; } else { return null; } }
            set { if (items.ContainsKey(key)) { items[key] = value; } }
        }
        #endregion

        #region GETVALUE
        public T GetValue<T>(params string[] keys) where T : IConvertible
        {
            object p = this[keys];
            if (p == null)
            {
                return default;
            }
            T result = (T)Convert.ChangeType(p, typeof(T));
            return result;
        }
        public T GetValue<T>(Converter<object, T> converter, params string[] keys) where T : IConvertible
        {
            object p = this[keys];
            if (p == null)
            {
                return default;
            }
            T result = converter(p);
            return result;
        }
        #endregion

        #region Constructeurs
        public Noeud() : this("Donnees") { }
        public Noeud(string name) : base(name) { }
        protected Noeud(Noeud noeud)
        {
            if (noeud is null) { throw new ArgumentException("Noeud::Ctor(Noeud) => la valeur est nulle"); }
            items = noeud.items;
        }
        #endregion

        #region DELETE, CLEAR
        public bool Delete(string key) { return items.Remove(key); }
        public void Clear() { items.Clear(); }
        #endregion

        #region Add
        public void Add(string key)
        {
            if (items.ContainsKey(key)) { return; }
            items.Add(key, new Noeud() { Name = key });
        }
        public void Add(Noeud donnees)
        {
            Add(donnees.Name, donnees);
        }
        public void Add(string key, object value)
        {
            if (items.ContainsKey(key))
            {
                items[key] = value;
            }
            else
            {
                items.Add(key, value);
            }
        }
        #endregion

        #region Validation
        public bool IsValid(params string[] keys)
        {
            bool valide = true;
            foreach (string key in keys)
            {
                if (!Keys.Contains(key))
                {
                    valide = false;
                    break;
                }
            }
            return valide;
        }
        #endregion

        #region LOAD ET SAVE

        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Noeud));
                xml.Serialize(sw, this);
            }
        }
        public static Noeud Load(string path)
        {
            Noeud result;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Noeud));
                    result = (Noeud)xml.Deserialize(sr);
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }
        #endregion

        #region Implementation de IXmlSerialisable
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader is null) { return; }
            XmlSerializer xml;
            string key = reader.GetAttribute("Name");
            if (!string.IsNullOrEmpty(key)) { Name = key; }
            while (reader.Read())
            {
                key = reader.GetAttribute("Name");
                if (!string.IsNullOrEmpty(key))
                {
                    if (reader.Name == "Noeud")
                    {
                        xml = new XmlSerializer(typeof(Noeud));
                        Noeud noeud = (Noeud)xml.Deserialize(reader.ReadSubtree());
                        noeud.Name = key;
                        items.Add(key, noeud);
                    }
                    else if (reader.Name == "Variable")
                    {
                        reader.Read();
                        items.Add(key, reader.Value);
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer is null) { return; }
            writer.WriteAttributeString("Name", Name);
            foreach (string key in Keys)
            {
                if (items[key] is Noeud noeud)
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Noeud));
                    xml.Serialize(writer, noeud);
                }
                else
                {
                    writer.WriteStartElement("Variable");
                    writer.WriteAttributeString("Name", key);
                    writer.WriteValue(items[key].ToString());
                    writer.WriteEndElement();
                }
            }
        }
        #endregion

        #region ToString
        private string TabCalc(int index)
        {
            if (index > 0)
            {
                string result = "\t";
                return result.PadRight(index, '\t');
            }
            else { return string.Empty; }
        }
        private static int tab = -1;
        public override string ToString()
        {
            string result = string.Empty;
            tab++;
            result += string.Format(TabCalc(tab) + "<Noeud Name={0}>\r\n", Name);
            if (items.Keys.Count > 0)
            {
                foreach (string str in items.Keys)
                {
                    if (items[str] is Noeud noeud)
                    {
                        result += noeud.ToString();
                    }
                    else
                    {
                        tab++;
                        result += string.Format(TabCalc(tab) + "<Variable Name={0}>{1}</Variable>\r\n", str, items[str].ToString());
                        tab--;
                    }
                }
            }
            result += TabCalc(tab) + "</Noeud>\r\n";
            tab--;
            return result;
        }
        #endregion
    }
}
