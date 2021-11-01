using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedList
{
    class CircleClosedList<T> : IClosedList<T>
    {
        Element<T> head;
        Element<T> current;

        int count;

        public CircleClosedList()
        {
            head = null;
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                var current = head;
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Data;
            }
            set
            {
                var current = head;
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                for (int i = 0; i < index; i++)
                    current = current.Next;

                current.Data = value;
            }
        }

        public T Head => head.Data;

        public T Current => current.Data;

        public T Previous => current.Prev.Data;

        public T Next => current.Next.Data;

        public int Count => count;

        public bool IsReadOnly => false;

        public event EventHandler<T> HeadReached;

        public void Add(T item)
        {
            Element<T> element = new Element<T>(item);

            if (head == null)
            {
                head = element;
                head.Next = element;
                head.Prev = element;
                current = head;
            }
            else
            {
                element.Next = head.Prev;
                element.Prev = head;
                head.Prev.Next = element;
                head.Prev = element;
            }
            count++;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            var current  = head;
            if (current == null) return false;

            do
            {
                if (current.Equals(item))
                    return true;
                current = current.Next;
            }
            while (current != head);

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            for (int i = 0; i < Count; i++)
            {
                array.SetValue(this[i], arrayIndex++);
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            var current  = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        public int IndexOf(T item)
        {
            var current  = head;
            if (current == null) return -1;
            int count = 0;

            do
            {
                if (item.Equals(current))
                    return count;
                current = current.Next;
                count++;
            }
            while (current != head);

            return -1;

        }

        public void Insert(int index, T item)
        {
            Element<T> element = new Element<T>(item);
            var current = head;
            if (current == null) throw new ArgumentOutOfRangeException();
            for (int i = 0; i < index; i++)
                current = current.Next;
            element.Next = current;
            element.Prev = current.Prev;
            current.Prev.Next = element;
            current.Prev = element;

        }

        public void MoveBack(int step = 1)
        {
            for (int i = 0; i < step; i++)
            {
                current = current.Prev;
                if (current.Equals(head)) ;
                    HeadReached?.Invoke(this, Head);
            }
        }

        public void MoveNext(int step = 1)
        {
            for (int i = 0; i < step; i++)
            {
                current = current.Next;
                if (current.Equals(head)) ;
                HeadReached?.Invoke(this, Head);
            }
        }

        public bool Remove(T item)
        {
            var current  = head;
            Element<T> removeItem = null;

            if (count == 0) return false;

            do
            {
                if (current.Data.Equals(item))
                {
                    removeItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != head);

            if (removeItem != null)
            {
                if (count == 1)
                    head = null;
                else
                {
                    if (head == removeItem)
                        head = head.Next;
                    removeItem.Prev.Next = removeItem.Next;
                    removeItem.Next.Prev = removeItem.Prev;
                }
                count--;
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > count) throw new IndexOutOfRangeException();

            var current  = head;
            for (int i = 0; i < index; i++)
                current = head.Next;

            current.Next.Prev = current.Prev;
            current.Prev.Next = current.Next;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
