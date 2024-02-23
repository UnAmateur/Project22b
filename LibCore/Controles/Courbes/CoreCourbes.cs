using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace LibCore.Controles.Courbes
{
    internal class CoreCourbes : Core, IList<GraphPoint>
    {
        private List<GraphPoint> Points = new List<GraphPoint>();
        public TypeCourbes CourbesType { get; set; } = TypeCourbes.None;
        public Pen Crayon { get; set; } = new Pen(Color.White, 1f);


        public GraphPoint this[int index] { get => ((IList<GraphPoint>)Points)[index]; set => ((IList<GraphPoint>)Points)[index] = value; }

        public CoreCourbes() : this("CoreCourbes") { }
        public CoreCourbes(string name) : base(name) { }
        public CoreCourbes(string name, List<PointF> liste, GraphPoint typepoint) : this(name)
        {
            Points.Clear();
            GraphPoint p;
            for (int index = 0; index < liste.Count; index++)
            {
                p = typepoint.Copy();
                p.Point = liste[index];
                Points.Add(p);
            }
        }
        public void Draw(Graphics g, CalculGraphique calcul)
        {
            PointF p1;
            PointF p2;
            switch (CourbesType)
            {
                case TypeCourbes.None:
                    foreach (GraphPoint item in Points)
                    {
                        item.Draw(g, calcul);
                    }
                    break;
                case TypeCourbes.LigneOuverte:
                    p1 = calcul(Points[0].Point);

                    for (int index = 0; index < Points.Count; index++)
                    {
                        p2 = calcul(Points[index].Point);
                        g.DrawLine(Crayon, p1, p2);
                        p1 = p2;
                    }
                    break;
                case TypeCourbes.LigneFermer:
                    p1 = calcul(Points[0].Point);


                    for (int index = 0; index < Points.Count; index++)
                    {
                        p2 = calcul(Points[index].Point);
                        g.DrawLine(Crayon, p1, p2);
                        p1 = p2;
                    }

                    p2 = calcul(Points[0].Point);
                    g.DrawLine(Crayon, p1, p2);

                    break;
                case TypeCourbes.Spline:
                    break;
                case TypeCourbes.Colonne:
                    break;
                default:
                    break;
            }
        }

        #region ILIST<GraphPoint>
        public int Count => ((ICollection<GraphPoint>)Points).Count;

        public bool IsReadOnly => ((ICollection<GraphPoint>)Points).IsReadOnly;
        public int IndexOf(GraphPoint item)
        {
            return ((IList<GraphPoint>)Points).IndexOf(item);
        }

        public void Insert(int index, GraphPoint item)
        {
            ((IList<GraphPoint>)Points).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<GraphPoint>)Points).RemoveAt(index);
        }
        public void AddRange(GraphPoint[] items)
        {
            for (int index = 0; index < items.Length; index++)
            {
                Add(items[index]);
            }
        }
        public void AddRange(List<GraphPoint> items)
        {
            for (int index = 0; index < items.Count; index++)
            {
                Add(items[index]);
            }
        }
        public void Add(GraphPoint item)
        {
            ((ICollection<GraphPoint>)Points).Add(item);
        }

        public void Clear()
        {
            ((ICollection<GraphPoint>)Points).Clear();
        }

        public bool Contains(GraphPoint item)
        {
            return ((ICollection<GraphPoint>)Points).Contains(item);
        }

        public void CopyTo(GraphPoint[] array, int arrayIndex)
        {
            ((ICollection<GraphPoint>)Points).CopyTo(array, arrayIndex);
        }

        public bool Remove(GraphPoint item)
        {
            return ((ICollection<GraphPoint>)Points).Remove(item);
        }

        public IEnumerator<GraphPoint> GetEnumerator()
        {
            return ((IEnumerable<GraphPoint>)Points).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Points).GetEnumerator();
        }
        #endregion
    }
}
