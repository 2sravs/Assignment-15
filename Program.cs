using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssign_15
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);

                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }
        private static void Swap(int[] array, int i, int j)
        {
            int team = array[i];
            array[i] = array[j];
            array[j] = team;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                    arr[k++] = leftArray[i++];
                else
                    arr[k++] = rightArray[j++];
            }
            while (i < n1)
                arr[k++] = leftArray[i++];
            while (j < n2)
                arr[k++] = rightArray[j++];
        }
        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n / 2;
            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
                gap /= 2;
            }
        }
        public static int[] GenerateRandomArray(int k)
        {
            Random random = new Random();
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr[i] = random.Next(1, 150);
            }
            return arr;
        }
        public static void PrintArr(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        static void Main(string[] args)
        {            
            int[] arrSizes = { 20, 30, 50 };
            foreach (int k in arrSizes)
            {
                int[] randomArray = GenerateRandomArray(k);
                int[] quickSortArray = (int[])randomArray.Clone();
                int[] mergeSortArray = (int[])randomArray.Clone();
                int[] shellSortArray = (int[])randomArray.Clone();
                Console.WriteLine($"Sorting {k} elements with QuickSort");
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                QuickSort(quickSortArray);
                stopwatch1.Stop();
                Console.WriteLine("Quick sorted array:");
                PrintArr(quickSortArray);
                Console.WriteLine($"QuickSort time taken: {stopwatch1.Elapsed.TotalMilliseconds} milliseconds");

                Console.WriteLine($"Sorting {k} elements with MergeSort");
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                MergeSort(mergeSortArray);
                stopwatch2.Stop();
                Console.WriteLine("Merge sorted array:");
                PrintArr(mergeSortArray);
                Console.WriteLine($"MergeSort time taken: {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");

                Console.WriteLine($"Sorting {k} elements with ShellSort");
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch3.Start();
                ShellSort(shellSortArray);
                stopwatch3.Stop();
                Console.WriteLine("Shell sorted array:");
                PrintArr(shellSortArray);
                Console.WriteLine($"ShellSort time taken: {stopwatch3.Elapsed.TotalMilliseconds} milliseconds");
                Console.ReadKey();
            }
        }
    }
}

//Advanatages of 