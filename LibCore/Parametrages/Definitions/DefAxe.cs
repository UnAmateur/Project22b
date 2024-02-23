using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefAxe : Definition
    {

        public Pen Crayon { get { return new DefCrayon((Noeud)this["Crayon"]); } }
        public DefGraduation Graduation { get { return new DefGraduation((Noeud)this["Graduation"]); } }
        internal DefAxe(Noeud noeud) : base(noeud)
        {
            if (!noeud.IsValid("Crayon", "Graduation")) { Create(); }
        }

        public DefAxe() : this("Graduation") { }

        public DefAxe(string name) : this(name, new DefCrayon(), new DefGraduation()) { }
        public DefAxe(string name, DefCrayon crayon, DefGraduation graduation) : base(name)
        {
            Add(crayon);
            Add(graduation);
        }

        protected override void Create()
        {
            Add(new DefCrayon());
            Add(new DefGraduation());
        }
    }
}
