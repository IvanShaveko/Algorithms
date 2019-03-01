using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfThree
{
    public static class MachineOfPowerOfThree
    {
        public static void Run(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(nameof(str));
            }

            var charArray = str.ToCharArray();

            if (charArray.Length == 1)
            {
                Console.WriteLine("Yes\n");
                return;
            }

            var i = 0;
            var j = 0;
            var state = new int[]{1, 2, 0};

            while (i < charArray.Length)
            {
                j = state[j];
                i++;
            }

            if (j == 1 || j==2)
            {
                Console.WriteLine("No\n");
                return;
            }

            Console.WriteLine("Yes\n");
        }
    }
}
