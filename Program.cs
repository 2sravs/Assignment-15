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
        
        static void Main(string[] args)
        {
            int[] arr = { 38, 23, 45, 34, 4, 2, 10, 82 };
            Console.WriteLine("*********Merge Sort***********");
            Console.WriteLine("Original Array:" + string.Join(",", arr));
            MergeSort(arr);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MergeSort(arr);
            stopwatch.Stop();
            Console.WriteLine("After Merge Sort");
            Print(arr);
            Console.WriteLine($"ArraySize {arr.Length} TimeTaken{stopwatch.Elapsed.TotalMilliseconds} milliseconds");     
                                  
            
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("*********QUick Sort starts*********");
            Console.WriteLine("Original Array");
            Print(array);                     
            stopwatch.Start();
            QuickSort(array);
            stopwatch.Stop();
            Console.WriteLine("After quick Sort");
            Print(array);
            Console.WriteLine($"ArraySize {array.Length} TimeTaken{stopwatch.Elapsed.TotalMilliseconds} milliseconds");
            Console.ReadKey();
        }
    }
}
