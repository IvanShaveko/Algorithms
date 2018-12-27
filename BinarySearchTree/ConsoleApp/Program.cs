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
            var tree = new BinarySearchTree.BinarySearchTree {15, 20, 18, 7, 8, 6};


            tree.Delete(15);

            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
