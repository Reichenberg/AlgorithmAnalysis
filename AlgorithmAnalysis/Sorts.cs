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
    }
}
