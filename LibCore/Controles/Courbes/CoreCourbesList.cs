using System;
using System.Collections;
using System.Collections.Generic;

namespace LibCore.Controles.Courbes
{
    internal class CoreCourbesList : Core, IList<CoreCourbes>
    {
        public event EventHandler ListeChanged;
        private List<CoreCourbes> _courbes = new List<CoreCourbes>();

        public CoreCourbesList() : this("CoreCourbesList") { }

        public CoreCourbesList(string name) : base(name) { }

        protected virtual void OnListChanged()
        {
            ListeChanged?.Invoke(this, null);
        }

        #region IList<CoreCourbes>
        public CoreCourbes this[int index]
        {
            get => ((IList<CoreCourbes>)_courbes)[index];
            set
            {
                ((IList<CoreCourbes>)_courbes)[index] = value;
                OnListChanged();
            }
        }

        public int Count => ((ICollection<CoreCourbes>)_courbes).Count;

        public bool IsReadOnly => ((ICollection<CoreCourbes>)_courbes).IsReadOnly;

        public void Add(CoreCourbes item)
        {
            ((ICollection<CoreCourbes>)_courbes).Add(item);
            OnListChanged();
        }

        public void Clear()
        {
            ((ICollection<CoreCourbes>)_courbes).Clear();
            OnListChanged();
        }

        public bool Contains(CoreCourbes item)
        {
            return ((ICollection<CoreCourbes>)_courbes).Contains(item);
        }

        public void CopyTo(CoreCourbes[] array, int arrayIndex)
        {
            ((ICollection<CoreCourbes>)_courbes).CopyTo(array, arrayIndex);
        }

        public IEnumerator<CoreCourbes> GetEnumerator()
        {
            return ((IEnumerable<CoreCourbes>)_courbes).GetEnumerator();
        }

        public int IndexOf(CoreCourbes item)
        {
            return ((IList<CoreCourbes>)_courbes).IndexOf(item);
        }

        public void Insert(int index, CoreCourbes item)
        {
            ((IList<CoreCourbes>)_courbes).Insert(index, item);
            OnListChanged();
        }

        public bool Remove(CoreCourbes item)
        {
            bool result = ((ICollection<CoreCourbes>)_courbes).Remove(item);
            OnListChanged();
            return result;
        }

        public void RemoveAt(int index)
        {
            ((IList<CoreCourbes>)_courbes).RemoveAt(index);
            OnListChanged();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_courbes).GetEnumerator();
        }
        #endregion
    }
}