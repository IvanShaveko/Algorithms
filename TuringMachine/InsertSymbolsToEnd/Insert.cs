using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSymbolsToEnd
{
    public static class Insert
    {
        public static string InsertToEnd(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(nameof(str));
            }

            var charArray = new char[str.Length * 2];
            Array.Copy(str.ToCharArray(), charArray, str.Length);
            var i = 0;
            var j = 0;
            var state = new int[str.Length];

            SetStates(state);

            while (i < str.Length)
            {
                if (charArray[i] == 'a')
                {
                    while (charArray[i] != default(char))
                    {
                        i++;
                    }

                    charArray[i] = '|';
                    i = state[j++];
                }
                else
                {
                    break;
                }
            }

            return new string(charArray);
        }

        private static void SetStates(int[] array)
        {
            for (var i = 0; i <array.Length; i++)
            {
                array[i] = i+1;
            }
        }
    }
}
