using System;

public class CircularQueue<T>
{
    private const int DefaultQueueCapacity = 16;

    private T[] elements;

    private int startIndex = 0;

    private int endIndex = 0;

    public CircularQueue()
    {
        this.elements = new T[DefaultQueueCapacity];
    }

    public CircularQueue(int capacity)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.endIndex] = element;

        if (this.endIndex == this.elements.Length - 1)
        {
            this.endIndex = 0;
        }
        else
        {
            this.endIndex++;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T element = this.elements[this.startIndex];

        if (this.startIndex == this.elements.Length - 1)
        {
            this.startIndex = 0;
        }
        else
        {
            this.startIndex++;
        }

        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        T[] arrayToReturn = new T[this.Count];
        arrayToReturn = this.CopyElements(arrayToReturn);

        return arrayToReturn;
    }

    private void Grow()
    {
        T[] newArray = new T[this.elements.Length * 2];
        newArray = this.CopyElements(newArray);

        this.elements = newArray;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private T[] CopyElements(T[] newArray)
    {
        T[] array = newArray;
        int sourceIndex = this.startIndex;
        for (int i = 0; i < this.Count; i++)
        {
            array[i] = this.elements[sourceIndex];
            if (sourceIndex == this.elements.Length - 1)
            {
                sourceIndex = 0;
            }
            else
            {
                sourceIndex++;
            }
        }

        return array;
    }
}

public class Example
{
    public static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
