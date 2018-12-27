using System;

namespace ArrayExtension
{
    public static class MergeSorting
    {
        public static void MergeSort(this int[] array, int low, int high)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        public static void MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            MergeSort(array, 0, array.Length - 1);
        }

        private static void Merge(int[] array, int low, int middle, int high)
        {

            var left = low;
            var right = middle + 1;
            var tmp = new int[(high - low) + 1];
            var tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (array[left] < array[right])
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                }

                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (var i = 0; i < tmp.Length; i++)
            {
                array[low + i] = tmp[i];
            }
        }
    }
}
