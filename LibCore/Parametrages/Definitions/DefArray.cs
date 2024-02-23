namespace LibCore.Parametrages.Definitions
{
    internal class DefArray<T> : Definition
    {
        public delegate Toutput Converter<in Tinput, out Toutput>(Tinput input);
        public static implicit operator object[](DefArray<T> definition) { return definition.ToArray(); }
        public DefArray() : this("Array") { }
        public DefArray(string name) : this(name, null) { }
        public DefArray(string name, T[] array) : base(name)
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] is Noeud noeud)
                {
                    Add(noeud);
                }
                else
                {
                    Add("Item-" + index.ToString("0000"), array[index]);
                }
            }
        }
        public DefArray(Noeud noeud) : base(noeud) { }
        public T[] ToArray(Converter<object, T> converter)
        {
            T[] result = new T[Keys.Count];
            for (int index = 0; index < Keys.Count; index++)
            {
                result[index] = converter(this[Keys[index]]);
            }
            return result;
        }
        public object[] ToArray()
        {
            object[] result = new object[Keys.Count];
            for (int index = 0; index < Keys.Count; index++)
            {
                result[index] = this[Keys[index]];
            }
            return result;
        }
        protected override void Create()
        {
            Clear();
        }
    }

}
