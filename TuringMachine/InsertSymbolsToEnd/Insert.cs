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
                    while (charArray[j] != default(char))
                    {
                        j++;
                    }

                    charArray[j] = '|';
                    j = state[j - i - 1];
                    i++;
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
            var j = 0;
            for (var i = array.Length - 1; i >=0; i--)
            {
                array[i] = ++j;
            }
        }
    }
}
