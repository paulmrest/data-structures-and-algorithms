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

        
        /// <summary>
        /// Takes an array of integers, inserts a new integer value shifting all the array elements to the right.
        /// </summary>
        /// <param name="array">
        /// int[]: the array of integers
        /// </param>
        /// <param name="value">
        /// int: the value to be inserted
        /// </param>
        /// <returns>
        /// int[]: the integer array with the new integer inserted
        /// </returns>
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

        
        /// <summary>
        /// Returns a string representation of an integer array.
        /// </summary>
        /// <param name="intArray">
        /// int[]: an array of integers
        /// </param>
        /// <returns>
        /// string: a representation of an integer array
        /// </returns>
        static string StringifyIntArray(int[] intArray)
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

        /// <summary>
        /// 
        //
        /// </summary>
        public static void SomeMethod()
        {

        }
    }
}
