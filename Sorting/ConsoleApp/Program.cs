using System;
using System.Diagnostics;
using ArrayExtension;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[38];
            var random = new Random();
            var stopWatch = new Stopwatch();

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            stopWatch.Start();
            array.QuickSort();
            stopWatch.Stop();

            Console.WriteLine("Time of QS: " + stopWatch.Elapsed);

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            stopWatch.Start();
            array.MergeSort();
            stopWatch.Stop();

            Console.WriteLine("Time of MS: " + stopWatch.Elapsed);

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            stopWatch.Start();
            array.HybridSort();
            stopWatch.Stop();

            Console.WriteLine("Time of HS: " + stopWatch.Elapsed);

            Console.ReadKey();
        }
    }
}
