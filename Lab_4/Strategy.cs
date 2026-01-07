using System;
namespace Lab_4
{
    public interface ISortingStrategy
    {
        void Sort(int[] array);
    }

    public class BubbleSortStrategy : ISortingStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Сортируем пузырьком...");

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
    public class QuickSortStrategy : ISortingStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Сортируем быстро (QuickSort)...");
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[right]) = (array[right], array[i + 1]);
            return i + 1;
        }
    }

    public class Sorter
    {
        private ISortingStrategy _strategy;
        public void SetStrategy(ISortingStrategy strategy)
        {
            _strategy = strategy;
            Console.WriteLine($"Установлена стратегия: {strategy.GetType().Name}");
        }

        public void SortArray(int[] array)
        {
            if (_strategy == null)
            {
                Console.WriteLine("Ошибка: стратегия не выбрана!");
                return;
            }
            _strategy.Sort(array);
        }
    }
}
class Program
{
    static void Main()
    {
        Sorter sorter = new Sorter();
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        sorter.SetStrategy(new BubbleSortStrategy());
        sorter.SortArray((int[])numbers.Clone());

        sorter.SetStrategy(new QuickSortStrategy());
        sorter.SortArray((int[])numbers.Clone());
    }
}
