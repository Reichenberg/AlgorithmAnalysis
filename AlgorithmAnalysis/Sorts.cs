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
        public static void InsertionSort(ref List<int> list)
        {
            int temp, j;

            for(int i = 1; i< list.Count; i++)
            {
                temp = list[i];

                for(j = i; j> 0 && temp < list[j-1]; j--)
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
    }
}
