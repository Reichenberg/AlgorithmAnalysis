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
            int n = 10;
            Random rand = new Random();

            //Add n random numbers into list
            for(int count = 0; count < n; count++)
            {
                list.Add(rand.Next());
                Console.WriteLine(list[count]);
            }

            //Use sink sort to sort list
            Sorts.SinkSort(ref list);
            Console.WriteLine('\n');

            for (int count = 0; count < n; count++ )
            {
                Console.WriteLine(list[count]);
            }
                Console.ReadLine();

        }
    }
}
