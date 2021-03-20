using System;

namespace HomoWork_4_1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else{
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> n = head;
            while (n != null)
            {
                action(n.Data);
                n = n.Next;
            }
        }
    }
    public class Test
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            intlist.ForEach(n => Console.Write($"{n},"));
            intlist.ForEach(n => max = n > max ? n : max);
            intlist.ForEach(n => min = n < min ? n : min);
            intlist.ForEach(n => sum += n);
            Console.WriteLine($"\n最大值为{max},最小值为{min},和为{sum}");
        }
    }
}
