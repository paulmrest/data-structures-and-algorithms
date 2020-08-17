using System;

namespace QuickSortNameSpace
{
    public class QuickSortClass
    {
        /// <summary>
        /// Public method. Takes in an array of integers and sorts it in place.
        /// </summary>
        /// <param name="array">
        /// int[]: an array of integers to be sorted
        /// </param>
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Private method. Recursively calls itself to sort an array of integers in place.o
        /// </summary>
        /// <param name="array">
        /// int[]: an array of integers to be sorted
        /// </param>
        /// <param name="left">
        /// int: the leftmost position to begin sorting
        /// </param>
        /// <param name="right">
        /// int: the rightmost position to begin sorting
        /// </param>
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int position = Partition(array, left, right);
                QuickSort(array, left, position - 1);
                QuickSort(array, position + 1, right);
            }
        }

        /// <summary>
        /// Private helper method. Shifts an array and returns an int between the parameter left and right such that for the value in the array at that index, all values to the left of that index are less than or equal the value, and all values to the right are greater or equal.
        /// </summary>
        /// <param name="array">
        /// int[]: an array to be shifted
        /// </param>
        /// <param name="left">
        /// int: the left most bound to be considered
        /// </param>
        /// <param name="right">
        /// int: the right most bound to be considered
        /// </param>
        /// <returns>
        /// int: the index of the value such that, between the parameter left and right indexes, all values to the left are less or equal, and all values to the right are more or equal
        /// </returns>
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

        /// <summary>
        /// Private helper method. Swaps the value at index i for the value at index low in the parameter array.
        /// </summary>
        /// <param name="array">
        /// int[]: the array to have values swapped
        /// </param>
        /// <param name="i">
        /// int: one of the indexs to to be swapped
        /// </param>
        /// <param name="low">
        /// int: the other index to be swapped
        /// </param>
        private static void Swap(int[] array, int i, int low)
        {
            int temp = array[i];
            array[i] = array[low];
            array[low] = temp;
        }
    }
}
