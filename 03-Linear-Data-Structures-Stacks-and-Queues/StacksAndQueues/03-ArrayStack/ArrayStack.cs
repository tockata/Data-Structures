namespace _03_ArrayStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count < 1)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            this.Count--;
            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                return new T[0];
            }

            var arrayToReturn = new T[this.Count];
            for (int i = this.Count - 1, j = 0; i >= 0; i--, j++)
            {
                arrayToReturn[j] = this.elements[i];
            }

            return arrayToReturn;
        }

        private void Grow()
        {
            var newArray = new T[this.elements.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }
    }

    public class Example
    {
        public static void Main(string[] args)
        {
        }
    }
}
