using System;

namespace InsertionSortNameSpace
{
    public class InsertionSortClass
    {
        public static void InsertionSort(int[] intArray)
        {
            for (int i = 1; i < intArray.Length; i++)
            {
                int j = i - 1;
                int temp = intArray[i];
                while (j >= 0 && temp < intArray[j])
                {
                    intArray[j + 1] = intArray[j];
                    j = j - 1;
                }
                intArray[j + 1] = temp;
            }
        }
    }
}
