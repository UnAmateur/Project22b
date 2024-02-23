using System;
using System.Collections.Generic;

namespace LibCore.Parametrages
{
    public static class Parametres
    {
        private static Dictionary<string, ParametreBase> items = null;
        public static ParametreThemes Themes { get { return (ParametreThemes)items["Themes"]; } }
        public static ParametreConfig Config { get { return (ParametreConfig)items["Config"]; } }
        public static ParametreLangues Langues { get { return (ParametreLangues)items["Langues"]; } }
        public static ParametreCouleurs Couleurs { get { return (ParametreCouleurs)items["Couleurs"]; } }
        static Parametres()
        {
            Initialise();
        }
        public static void Initialise()
        {
            items = new Dictionary<string, ParametreBase>();
            if (!items.ContainsKey("Config"))
            {
                ParametreConfig config = new ParametreConfig();
                items.Add("Config", config);
            }
            if (!items.ContainsKey("Themes"))
            {
                if (Config is null) { throw new ArgumentException("Parametres::Initialise::Config is null"); }
                ParametreThemes themes = new ParametreThemes(Config.Path.GetValue<string>("Themes"), Config.Files.GetValue<string>("Themes"));
                items.Add("Themes", themes);
            }
            if (!items.ContainsKey("Langues"))
            {
                if (Config is null) { throw new ArgumentException("Parametres::Initialise::Config is null"); }
                ParametreLangues langues = new ParametreLangues(Config.Path.GetValue<string>("Langues"), Config.Files.GetValue<string>("Langues"));
                items.Add("Langues", langues);
            }
            if (!items.ContainsKey("Couleurs"))
            {
                if (Config is null) { throw new ArgumentException("Parametres::Initialise::Config is null"); }
                ParametreCouleurs couleurs = new ParametreCouleurs(Config.Path.GetValue<string>("Couleurs"), Config.Files.GetValue<string>("Couleurs"));
                items.Add("Couleurs", couleurs);
            }
        }
        public static void Add(string key, ParametreBase parametre)
        {
            if (items is null) { return; }
            if (!items.ContainsKey(key))
            {
                items.Add(key, parametre);
            }
        }
        public static void Setup()
        {
            items = new Dictionary<string, ParametreBase>();
            ParametreConfig config = new ParametreConfig(true);
            config.Setup();
            items.Add("Config", config);
            ParametreThemes themes = new ParametreThemes(config.Path.GetValue<string>("Themes"), config.Files.GetValue<string>("Themes"), true);
            themes.Setup();
            items.Add("Themes", themes);
            ParametreLangues langues = new ParametreLangues(config.Path.GetValue<string>("Langues"), config.Files.GetValue<string>("Langues"), true);
            langues.Setup();
            items.Add("Langues", langues);
            ParametreCouleurs couleurs = new ParametreCouleurs(config.Path.GetValue<string>("Couleurs"), config.Files.GetValue<string>("Couleurs"), true);
            couleurs.Setup();
            items.Add("Couleurs", couleurs);
        }
    }
}
