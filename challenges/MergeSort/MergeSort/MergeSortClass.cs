using System;

namespace MergeSortNameSpace
{
    public class MergeSortClass
    {
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
