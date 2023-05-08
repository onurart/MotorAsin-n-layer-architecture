using System.Collections;

namespace MotorAsinBasketRobot.Core.DataAccess.Utilities.Results
{
    public class PagedResult<T> where T : class
    {
        private int totalCount;
        private IList<T> items;
        public int TotalCount { get => totalCount; set => totalCount = value; }
        public IList<T> Items
        {
            get => items ?? (items = new List<T>());
            set => items = value;
        }
        // public T this[int index] { get => items[index]; set => items[index]=value; }
        //public int Count => items.Count;

        //public bool IsReadOnly => items.IsReadOnly;

        //public void Add(T item)
        //{
        //    items.Add(item);
        //}
        //public void Clear()
        //{
        //    items.Clear();
        //}
        //public bool Contains(T item)
        //{
        //    return items.Contains(item);
        //}

        //public void CopyTo(T[] array, int arrayIndex)
        //{
        //    items.CopyTo(array, arrayIndex);
        //}

        //public IEnumerator<T> GetEnumerator()
        //{
        //   return items.GetEnumerator();
        //}

        //public int IndexOf(T item)
        //{
        //    return items.IndexOf(item);
        //}

        //public void Insert(int index, T item)
        //{
        //    items.Insert(index, item);
        //}

        //public bool Remove(T item)
        //{
        //    return items.Remove(item);
        //}

        //public void RemoveAt(int index)
        //{
        //    items.RemoveAt(index);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return items.GetEnumerator();
        //}
    }
}
