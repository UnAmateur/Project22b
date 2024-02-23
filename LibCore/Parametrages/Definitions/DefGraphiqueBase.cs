using System.Drawing;

namespace LibCore.Parametrages.Definitions
{
    internal class DefGraphiqueBase : Definition
    {
        public Brush Zone { get { return new DefPinceau((Noeud)this["Zone"]); } }
        public Pen Cadre { get { return new DefCrayon((Noeud)this["Cadre"]); } }
        public DefGraphiqueBase() : this("Graphique") { }
        public DefGraphiqueBase(string name) : this(name, new DefPinceau(), new DefCrayon()) { }
        public DefGraphiqueBase(string name, DefPinceau zone, DefCrayon crayon) : base(name)
        {
            zone.Name = "Zone";
            Add(zone);
            crayon.Name = "Cadre";
            Add(crayon);
        }
        public DefGraphiqueBase(Noeud noeud) : base(noeud)
        {
            if (!IsValid("Zone", "Cadre")) { Create(); }
        }
        protected override void Create()
        {
            Clear();
            Add(new DefPinceau("Zone", 224, 224, 224));
            Add(new DefCrayon("Cadre", 0, 0, 0, 1f, null));
        }
    }

}
