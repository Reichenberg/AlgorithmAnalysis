using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysis
{
    /// <summary>
    /// Class to hold various sorting algorithms
    /// </summary>
    public static class Sorts
    {
        /// <summary>
        /// Sink sort method
        /// </summary>
        /// <param name="list">List to sort</param>
        public static void SinkSort(ref List<int> list)
        {
            bool sorted = false;
            int pass = 0;

            //Sort until sorted or enough  passes completed
            while(!sorted && (pass < list.Count))
            {
                pass++;
                sorted = true;

                for(int i = 0; i < list.Count - pass; i++)
                {
                    //If not sorted, swap
                    if(list[i] > list[i + 1])
                    {
                        Swap(ref list, i, i + 1);
                        sorted = false;

                    }
                }
            }
            
        }

        /// <summary>
        /// Swaps items in a list
        /// </summary>
        /// <param name="list">List to have items swapped</param>
        /// <param name="n">index of the first item</param>
        /// <param name="m">index of the second item </param>
        public static void Swap(ref List<int> list, int n, int m)
        {
            int temp = list[n];
            list[n] = list[m];
            list[m] = temp;
            
        }

        /// <summary>
        /// Sorts the list using the insertion sort algorithm
        /// </summary>
        /// <param name="list">List to be sorted</param>
        public static void InsertionSort(ref List<int> list, int start, int end)
        {
            int temp, j;

            for(int i = 0; i < end; i++)
            {
                temp = list[i];

                for(j = i; j > start && temp < list[j-1]; j--)
                {
                    list[j] = list[j - 1];
                }

                list[j] = temp;
            }
        }

        /// <summary>
        /// Sorts the list using a selection sort
        /// </summary>
        /// <param name="list">list to be sorted</param>
        /// <param name="n">number of items in the list to be considered</param>
        public static void SelectionSort(ref List<int> list, int n)
        {
            if(n<= 1)
            {
                return;
            }
            int max = Max(list, n);
           if(list[max] != list[n-1])
           {
               Swap(ref list, max, n-1);
           }

           SelectionSort(ref list, n - 1);
        }

        /// <summary>
        /// Finds and returns the largest value in the list
        /// </summary>
        /// <param name="list">list to be searched</param>
        /// <param name="n">number of items to be considered</param>
        /// <returns>index of the largest value in the list</returns>
        private static int Max(List<int> list, int n)
        {
            int max = 0;
            for(int i = 0; i < n; i++)
            {
                if(list[max] < list[i])
                {
                    max = i;
                }
            }
            return max;
        }

        /// <summary>
        /// Method that allows access to quick sort algorithm
        /// </summary>
        /// <param name="list"> list to sort</param>
        public static void OriginalQuickSort(ref List<int> list)
        {
            QuickSort(ref list, 0, list.Count - 1);
        }

        /// <summary>
        /// Quicksort algorithm
        /// </summary>
        /// <param name="list"> list to be sorted</param>
        /// <param name="start">start of the list</param>
        /// <param name="end"> end of the list to be sorted</param>
        private static void QuickSort(ref List<int> list, int start, int end)
        {
            int left = start;
            int right = end;

            if(left >= right)
            {
                return;
            }

            while( left < right)
            {
                while(list[left] <= list[right] && left < right)
                {
                    right--;
                }

                if(left < right)
                {
                    Swap(ref list, left, right);
                }

                while(list[left] <= list[right] && left < right)
                {
                    left++;
                }

                if(left < right)
                {
                    Swap(ref list, left, right);
                }

                QuickSort(ref list, start, left - 1);
                QuickSort(ref list, right + 1, end);
            }
        }

        /// <summary>
        /// Method used to easily access Quick Median of three sort
        /// </summary>
        /// <param name="list">list to be sorted</param>
        public static void QuickMedianOfThreeSort(ref List<int> list)
        {
            QuickMedOfThreeSort(ref list, 0, list.Count - 1);
        }

        /// <summary>
        /// Sorts the list using the Quick Median of three sort
        /// </summary>
        /// <param name="list">list to be sorted</param>
        /// <param name="start">start of the list to be sorted</param>
        /// <param name="end">end of the list to be sorted</param>
        private static void QuickMedOfThreeSort(ref List<int> list, int start, int end)
        {
            const int cutoff = 10; //Point at which we switch to insertion

            if(start + cutoff > end)
            {
                InsertionSort(ref list, start, end);
            }
            else
            {
                int middle = (start + end) / 2;

                if(list[middle] < list[start])          //Find the median of three for pivot
                {                                       //By sorting them and pivot
                    Swap(ref list, start, middle);      // is in the middle position
                }
                if(list[end] < list[start])
                {
                    Swap(ref list, start, end);
                }
                if(list[end] < list[middle])
                {
                    Swap(ref list, middle, end);
                }

                int pivot = list[middle];
                Swap(ref list, middle, end -1);

                int left, right;

                for(left = start, right = end; ; )
                {
                    while(list[++left] < pivot)
                        ;
                    while(pivot < list[--right])
                        ;
                    if(left < right)
                    {
                        Swap(ref list, left, right);
                    }
                    else
                        break;
                }

                Swap(ref list, left, end - 1);

                QuickMedOfThreeSort(ref list, start, left -1);
                QuickMedOfThreeSort(ref list, left + 1, end);
            }
        }

        /// <summary>
        /// Sorts the list using the shell sort method
        /// </summary>
        /// <param name="list">List to be sorted</param>
        public static void ShellSort(ref List<int> list)
        {
            //Start with gap of n/2; divide by 2.2 each time until it reaches 1 or 0
            for(int gap = list.Count / 2; gap > 0; gap = (gap == 2 ? 1 : (int)(gap / 2.2)))
            {
                //Sort a subset by insertion
                int temp, j;
                for(int i = gap; i < list.Count; i++)
                {
                    temp = list[i];

                    for(j = i; j>=gap && temp < list[j-gap]; j -= gap)
                    {
                        list[j] = list[j - gap];
                    }
                    list[j] = temp;
                }
            }
        }

        /// <summary>
        /// Sorts the passed list using the Merge Sort algorithm
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <returns>Sorted list</returns>
        public static List<int> MergeSort (List<int> list)
        {
            if(list.Count <= 1)
            {
                return list;
            }

            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            //Create left and right sublists about half the size of the list
            int middle = list.Count / 2;

            for(int i = 0; i < middle; i++)
            {
                left.Add(list[i]);
            }
            for(int i = middle; i < list.Count; i++)
            {
                right.Add(list[i]);
            }

            //Recusrively apply the mergesort to each half
            left = MergeSort(left);
            right = MergeSort(right);


            if (left[left.Count - 1] <= right[0])
                return append(left, right);

            //Merge the lists maintaining sorted order
            result = merge(left, right);
            return result;
        }

        /// <summary>
        /// Mreges the 2 lists provided
        /// </summary>
        /// <param name="left">first list</param>
        /// <param name="right">second list</param>
        /// <returns>The two lists merged together</returns>
        private static List<int> merge (List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 && right.Count > 0)
            {
                if(left[0] < right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while(left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while(right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }

        /// <summary>
        /// Adds the provided lists into a single list
        /// </summary>
        /// <param name="left">base list</param>
        /// <param name="right">list to add to the base list</param>
        /// <returns>The combination of the 2 lists</returns>
        private static List<int> append (List<int> left, List<int> right)
        {
            List<int> result = new List<int>(left);
            foreach (int x in right)
                result.Add(x);
            return result;
        }
    }
}
