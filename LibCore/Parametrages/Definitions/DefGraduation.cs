using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefGraduation : Definition
    {
        public Pen Crayon { get { return new DefCrayon((Noeud)this["Crayon"]); } }
        public Font Police { get { return new DefPolice((Noeud)this["Police"]); } }
        internal DefGraduation(Noeud noeud) : base(noeud)
        {
            if (!noeud.IsValid("Crayon", "Police")) { Create(); }
        }

        public DefGraduation() : this("Graduation") { }

        public DefGraduation(string name) : this(name, new DefCrayon(), new DefPolice()) { }
        public DefGraduation(DefCrayon crayon, DefPolice police) : this("Graduation", crayon, police) { }
        public DefGraduation(string name, DefCrayon crayon, DefPolice police) : base(name)
        {
            crayon.Name = "Crayon";
            police.Name = "Police";
            Add(crayon);
            Add(police);
        }

        protected override void Create()
        {
            Clear();
            Add(new DefCrayon());
            Add(new DefPolice());
        }
    }
}
