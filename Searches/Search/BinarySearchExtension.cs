using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public static class BinarySearchExtension
    {
        public static int BinarySearch(this int[] array, int item)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} must be initialized");
            }
            if (array.Length == 0)
            {
                return -1;
            }

            var left = 0;
            var right = array.Length - 1;
            var mid = left + (right - left) / 2;

            while (left <= right)
            {
                if (array[mid] == item)
                {
                    return mid;
                }

                if (array[mid] < item)
                {
                    left = mid + 1;
                    mid = left + (right - left) / 2;
                }
                else
                {
                    right = mid - 1;
                    mid = left + (right - left) / 2;
                }
            }

            return -1;
        }
    }
}
