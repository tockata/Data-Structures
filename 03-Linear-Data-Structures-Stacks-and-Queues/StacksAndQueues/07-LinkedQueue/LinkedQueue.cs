namespace _07_LinkedQueue
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else if (this.Count == 1)
            {
                this.head.NextNode = newNode;
                newNode.PrevNode = this.head;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                newNode.PrevNode = this.tail;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
        }

        public T[] ToArray()
        {
        }

        private class QueueNode<T>
        {
            public QueueNode(T element)
            {
                this.Value = element;
            }

            public T Value { get; private set; }

            public QueueNode<T> NextNode { get; set; }

            public QueueNode<T> PrevNode { get; set; }
        }
    }
}
