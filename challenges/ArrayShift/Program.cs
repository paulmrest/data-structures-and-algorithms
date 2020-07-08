using System;
using System.Text;

namespace ArrayShift
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringifyIntArray(InsertShiftArray(new int[] { 12, 6, 9, 11, 23 }, 4)));
            Console.WriteLine(StringifyIntArray(InsertShiftArray(new int[] { 12, 6, 9, 11 }, 7)));
        }

        public static int[] InsertShiftArray(int[] array, int value)
        {
            int length = array.Length;
            int newIndex = length / 2;
            if (length % 2 != 0)
            {
                newIndex++;
            }
            int[] newArray = new int[length + 1];
            newArray[newIndex] = value;
            for (int i = 0; i < length; i++)
            {
                if (i < newIndex)
                {
                    newArray[i] = array[i];
                }
                else
                {
                    newArray[i + 1] = array[i];
                }
            }
            return newArray;
        }

        static String StringifyIntArray(int[] intArray)
        {
            StringBuilder arrayString = new StringBuilder();
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i >= intArray.Length - 1)
                {
                    arrayString.Append(intArray[i]);
                }
                else
                {
                    arrayString.Append($"{intArray[i]}, ");
                }
            }
            return arrayString.ToString();
        }
    }
}
