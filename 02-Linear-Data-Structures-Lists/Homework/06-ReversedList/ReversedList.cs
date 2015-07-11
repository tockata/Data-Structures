namespace _06_ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int InitialListSize = 4;
        private T[] list;

        private int currentPosition = 0;

        public ReversedList()
        {
            this.list = new T[InitialListSize];
        }

        public int Count
        {
            get
            {
                return this.currentPosition;
            }
        }

        public int Capacity
        {
            get
            {
                return this.list.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || (this.Count - 1) < index)
                {
                    throw new IndexOutOfRangeException("Index can not be negative and bigger then list length!");
                }

                return this.list[this.Count - 1 - index];
            }

            set
            {
                if (index < 0 || (this.Count - 1) < index)
                {
                    throw new IndexOutOfRangeException("Index can not be negative and bigger then list length!");
                }

                this.list[this.Count - 1 - index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.currentPosition == this.list.Length)
            {
                T[] newList = new T[this.list.Length * 2];
                Array.Copy(this.list, newList, this.list.Length);
                this.list = newList;
            }

            this.list[this.currentPosition] = item;
            this.currentPosition++;
        }

        public void Remove(int index)
        {
            if (index < 0 || (this.Count - 1) < index)
            {
                throw new IndexOutOfRangeException("Index can not be negative and bigger then list length!");
            }

            T elementToRemove = this[index];
            T[] newList = this.list.Where(element => !element.Equals(elementToRemove)).ToArray();
            this.list = newList;

            this.currentPosition--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            
            while (index < this.currentPosition)
            {
                T value = this[index];
                yield return value;
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
