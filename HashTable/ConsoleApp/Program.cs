using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable.HashTable();

            table.Insert(1, 143);
            table.Insert(15, 156);
            table.Insert(8, 12);

            table.Print();

            Console.ReadKey();
        }
    }
}
