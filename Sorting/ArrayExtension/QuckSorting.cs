using System;

namespace ArrayExtension
{
    public static class QuckSorting
    {
        public static void QuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return;
            }

            DoQuickSort(array, 0, array.Length - 1);
        }

        private static void DoQuickSort(int[] array, int first, int last)
        {
            var point = ((last - first) / 2) + first;
            var p = array[point];
            var i = first;
            var j = last;
            while (i <= j)
            {
                while (array[i] < p && i <= last)
                {
                    i++;
                }

                while (array[j] > p && j >= first)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref array[i++], ref array[j--]);
                }
            }

            if (j > first)
            {
                DoQuickSort(array, first, j);
            }

            if (i < last)
            {
                DoQuickSort(array, i, last);
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            var tmp = i;
            i = j;
            j = tmp;
        }
    }
}