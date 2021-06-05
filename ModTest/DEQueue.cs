using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModTest
{
    class DEQueue<T>
    {
        private List<T> items;

        public DEQueue()
        {
            items = new List<T>();
        }

        public void pushBack(T item)
        {
            items.Add(item);
        }

        public void pushFront(T item)
        {
            items.Insert(0, item);
        }

        public T popFront()
        {
            T item = items.FirstOrDefault<T>();
            if (items.Count > 0)
            {
                items.RemoveAt(0);
            }
            return item;
        }

        public T popBack()
        {
            T item = items.LastOrDefault<T>();
            if (items.Count > 0)
            {
                items.RemoveAt(items.Count - 1);
            }
            return item;
        }

        public T back()
        {
            return items.LastOrDefault<T>();
        }

        public T front()
        {
            return items.FirstOrDefault<T>();
        }

        public int size()
        {
            return items.Count;
        }

        public void clear()
        {
            items.Clear();
        }

        public T[] toArray()
        {
            return items.ToArray();
        }
    }
}
