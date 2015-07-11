namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedLinkedList<T> : IEnumerable
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        private ListNode<T> this[int index]
        {
            get
            {
                if (index < 0 || (this.Count - 1) < index)
                {
                    throw new IndexOutOfRangeException("Index can not be negative and bigger then list length!");
                }

                int i = 0;
                ListNode<T> currentNode = this.head;
                while (i != index)
                {
                    currentNode = currentNode.NextNode;
                    i++;
                }

                return currentNode;
            }
        }

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(item);
                this.tail = this.head;
            }
            else
            {
                var newTail = new ListNode<T>(item);
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else if (index == this.Count - 1)
            {
                this.tail = this[index - 1];
            }
            else
            {
                ListNode<T> removedListNode = this[index];

                if (index != 0)
                {
                    this[index - 1].NextNode = removedListNode.NextNode;
                }
                else
                {
                    this.head = removedListNode.NextNode;
                }
            }

            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            int index = 0;

            while (index <= this.Count - 1)
            {
                if (this[index].Value.Equals(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            int index = 0;
            int lastIndex = -1;

            while (index <= this.Count - 1)
            {
                if (this[index].Value.Equals(item))
                {
                    lastIndex = index;
                }

                index++;
            }

            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }
        }
    }
}
