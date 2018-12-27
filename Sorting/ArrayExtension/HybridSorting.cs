using System;

namespace ArrayExtension
{
    public static class HybridSorting
    {
        public static void HybridSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return;
            }
            
            HybridSort(array, 0, array.Length - 1);
        }

        public static void HybridSort(this int[] array, int low, int high)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return;
            }

            if (high - low < 50)
            {
                InsertionSort(array, low, high);
            }
            else
            {
                var tmp = Partition(array, low, high);

                if (tmp - low < high - tmp)
                {
                    HybridSort(array, low, tmp - 1);
                }
                else
                {
                    HybridSort(array, tmp - 1, high);
                }
            }

        }

        private static void InsertionSort(int[] array, int low, int high)
        {
            for (var i = 0; i < high; i++)
            {
                var j = i + 1;

                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j -1], ref array[j]);
                    }
                    j--;
                }
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            var tmp = array[high];
            var index = low;

            for (var i = low; i < high; i++)
            {
                if (array[i] <= tmp)
                {
                    Swap(ref array[i],ref array[index]);
                    index++;
                }
            }

            Swap(ref array[high], ref array[index]);

            return index;
        }

        private static void Swap(ref int i, ref int j)
        {
            var tmp = i;
            i = j;
            j = tmp;
        }
    }
}