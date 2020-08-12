using System;

namespace MergeSortNameSpace
{
    public class MergeSortClass
    {
        /// <summary>
        /// Recursively sorts an array of integers in place.
        /// </summary>
        /// <param name="array">
        /// int[]: an array of integers
        /// </param>
        public static void MergeSort(int[] array)
        {
            int length = array.Length;
            if (length > 1)
            {
                int midPoint = length / 2;
                int[] leftArray = array[0..midPoint];
                int[] rightArray = array[midPoint..length];
                MergeSort(leftArray);
                MergeSort(rightArray);
                Merge(leftArray, rightArray, array);
            }
        }

        /// <summary>
        /// Private helper method. Merges leftArray and rightArray into origArray, in order, as long as leftArray and rightArray are sorted.
        /// </summary>
        /// <param name="leftArray">
        /// int[]: a sorted array of integers
        /// </param>
        /// <param name="rightArray">
        /// int[]: a sorted array of integers
        /// </param>
        /// <param name="origArray">
        /// int[]: an array of integers, not necessarily sorted
        /// </param>
        private static void Merge(int[] leftArray, int[] rightArray, int[] origArray)
        {
            int leftArrayIndex = 0;
            int rightArrayIndex = 0;
            int origArrayIndex = 0;
            while (leftArrayIndex < leftArray.Length && rightArrayIndex < rightArray.Length)
            {
                if (leftArray[leftArrayIndex] <= rightArray[rightArrayIndex])
                {
                    origArray[origArrayIndex] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
                else
                {
                    origArray[origArrayIndex] = rightArray[rightArrayIndex];
                    rightArrayIndex++;
                }
                origArrayIndex++;
            }
            if (leftArrayIndex >= leftArray.Length)
            {
                Array.Copy(rightArray, rightArrayIndex, origArray, origArrayIndex, origArray.Length - origArrayIndex);
            }
            else
            {
                Array.Copy(leftArray, leftArrayIndex, origArray, origArrayIndex, origArray.Length - origArrayIndex);
            }
        }
    }
}
