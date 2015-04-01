using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgorithmAnalysis
{

    /// <summary>
    /// Class to drive algorithm analysis
    /// </summary>
    class AlgorithmAnalysisDriver
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int n = 1000;

            for (int i = 0; i < n; i++ )
            {
                list.Add(i);
            }
            list.Reverse(0, n);

            Sorts.InsertionSort(ref list, 0, n);
            list.Reverse(0, n);
            list = Sorts.MergeSort(list);
            list.Reverse(0, n);
            Sorts.QuickMedianOfThreeSort(ref list);
            list.Reverse(0, n);
            Sorts.OriginalQuickSort(ref list);
            list.Reverse(0, n);
            Sorts.SinkSort(ref list);
            list.Reverse(0, n);
            Sorts.ShellSort(ref list);


            //Use sink sort to sort list
            //Sorts.InsertionSort(ref list);
            
            Console.WriteLine('\n');

            //Display sorted list
            for (int count = 0; count < n; count++)
            {
                Console.WriteLine(list[count]);
            }
            Console.ReadLine();

        }
    }
}
