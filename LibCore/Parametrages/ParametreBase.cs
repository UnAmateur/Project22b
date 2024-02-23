using System.Collections.Generic;
using System.IO;

namespace LibCore.Parametrages
{
    public abstract class ParametreBase : Core
    {
        private Noeud parametreNoeud = new Noeud();
        private const string extName = "Xml";
        protected readonly string pathName = string.Empty;
        protected readonly string fileName = string.Empty;
        protected bool ExistDirectory { get { if (string.IsNullOrEmpty(pathName)) { return true; } else { return Directory.Exists(pathName); } } }
        protected bool ExistFile { get { return File.Exists(PathFile); } }
        protected string PathFile
        {
            get
            {
                if (string.IsNullOrEmpty(pathName)) { return fileName + "." + extName; } else { return pathName + "\\" + fileName + "." + extName; }
            }
        }
        protected object this[string key] { get { if (IsNullOrEmpty) { return null; } else { return parametreNoeud[key]; } } }
        protected object this[params string[] keys] { get { if (IsNullOrEmpty) { return null; } else { return parametreNoeud[keys]; } } }
        protected List<string> Keys { get { if (IsNullOrEmpty) { return null; } else { return parametreNoeud.Keys; } } }
        protected bool IsNullOrEmpty { get { if (parametreNoeud is null) { return true; } else { return parametreNoeud.IsNullOrEmpty; } } }
        protected ParametreBase() : base("ParametreBase") { Initialise(); }
        protected ParametreBase(string namepath, string filename, bool setup = false) : this("ParametreBase", namepath, filename, setup) { }
        protected ParametreBase(string name, string namepath, string filename, bool setup = false) : base(name)
        {
            pathName = namepath;
            fileName = filename;
            if (!setup) { Initialise(); }
        }
        protected void Initialise()
        {
            if (ExistDirectory)
            {
                if (ExistFile)
                {
                    Load();
                }
                else
                {
                    DefaultValues();
                }
            }
            else
            {
                DefaultValues();
            }
        }
        protected abstract void DefaultValues();
        protected void Add(string key) { parametreNoeud.Add(key); }
        protected void Add(string key, object value) { parametreNoeud.Add(key, value); }
        internal void Save()
        {
            parametreNoeud.Save(PathFile);
        }
        protected void Load()
        {
            parametreNoeud = Noeud.Load(PathFile);
        }
        public void Setup()
        {
            if (!string.IsNullOrEmpty(pathName))
            {
                if (Directory.Exists(pathName)) { Directory.Delete(pathName, true); }
                Directory.CreateDirectory(pathName);
            }
            if (File.Exists(PathFile))
            {
                File.Delete(PathFile);
            }
            DefaultValues();
            Save();
        }
    }
}
