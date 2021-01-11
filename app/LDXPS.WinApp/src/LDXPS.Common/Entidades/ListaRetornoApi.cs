
using System.Collections;
using System.Collections.Generic;
using LDXPS.Common.Http;

namespace LDXPS.Common.Entidades
{
    public class ListaRetornoApi<T> : EntidadeBase, IList<T>
    {
        private readonly List<T> _list;

        public ListaRetornoApi()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public int Count => _list.Count;
        public bool IsReadOnly => false;

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        public List<T> ToList()
        {
            return _list;
        }
    }
}
