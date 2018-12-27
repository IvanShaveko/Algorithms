using System;

namespace Search
{
    public static class InterpolitionSearchExtension
    {
        public static int InterpolitionSearch(this int[] array, int item)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} must be initialized");
            }
            if (array.Length == 0)
            {
                return -1;
            }

            var low = 0;
            var high = array.Length - 1;

            while (array[low] < item && array[high] > item)
            {
                var mid = low + ((item - array[low]) * (high - low)) / (array[high] - array[low]);

                if (array[mid] < item)
                {
                    low = mid + 1;
                }
                else if (array[mid] > item)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (array[low] == item)
            {
                return low;
            }
            else if(array[high] == item)
            {
                return high;
            }

            return -1;
        }
    }
}