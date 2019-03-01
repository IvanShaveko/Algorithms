using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsertSymbolsToEnd;
using PowerOfThree;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "111111111111111111111111111";
            MachineOfPowerOfThree.Run(str);

            str = "11111111111111111111111111";
            MachineOfPowerOfThree.Run(str);

            str = "aaaaabbbbaababab";
            Console.WriteLine(Insert.InsertToEnd(str) + '\n');

            str = "bbbbabababa";
            Console.WriteLine(Insert.InsertToEnd(str) + '\n');

            str = "aaaaaaaaaa";
            Console.WriteLine(Insert.InsertToEnd(str) + '\n');
        }
    }
}
