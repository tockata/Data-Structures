namespace _05_LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("LinkedStack is empty!");
            }

            var firstNode = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return firstNode.Value;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];

            var currentNode = this.firstNode;
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return result;
        }
        
        private class Node<T>
        {
            private T value;

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public Node<T> NextNode { get; set; }
        }
    }

    public class Example
    {
        public static void Main(string[] args)
        {
        }
    }
}
