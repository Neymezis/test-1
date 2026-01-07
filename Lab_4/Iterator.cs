using System;
namespace Lab_4
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
    public class ArrayIterator<T> : IIterator<T>
    {
        private T[] items;
        private int position;

        public ArrayIterator(T[] items)
        {
            this.items = items;
            this.position = 0;
        }

        public bool HasNext()
        {
            return position < items.Length;
        }

        public T Next()
        {
            if (HasNext())
            {
                return items[position++];
            }
            throw new IndexOutOfRangeException("Элементы закончились");
        }
    }
    class Program
    {
        static void Main()
        {
            string[] fruits = { "Apple", "Banana", "Cherry", "Date" };

            IIterator<string> iterator = new ArrayIterator<string>(fruits);

            while (iterator.HasNext())
            {
                string fruit = iterator.Next();
                Console.WriteLine(fruit);
            }
        }
    }
}
