using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new []{1, 2, 3, 6, 7};

            Console.WriteLine(arr.BinarySearch(7));
            Console.WriteLine(arr.InterpolitionSearch(6));

            Console.ReadKey();
        }
    }
}
