using System;

namespace QuickSortNameSpace
{
    public class QuickSortClass
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int position = Partition(array, left, right);
                QuickSort(array, left, position - 1);
                QuickSort(array, position + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int low = left - 1;
            for (int i = left; i < right; i++)
            {
                if (array[i] <= pivot)
                {
                    low++;
                    Swap(array, i, low);
                }
            }
            Swap(array, right, low + 1);
            return low + 1;
        }

        private static void Swap(int[] array, int i, int low)
        {
            int temp = array[i];
            array[i] = array[low];
            array[low] = temp;
        }
    }
}
