using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuringMachine;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        { 
            var result = new Machine(0, new Head("aaababababa", 0), TransitionTableGenerator.AddToString()).Run();

            Console.WriteLine(result);

            result = new Machine(0, new Head("1111111111", 0), TransitionTableGenerator.PowerOfThree()).Run();

            Console.WriteLine(result);
        }
    }
}
