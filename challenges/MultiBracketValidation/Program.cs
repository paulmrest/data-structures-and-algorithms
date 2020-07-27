using System;
using StacksAndQueues.Classes;
using System.Linq;
using System.Threading.Channels;

namespace MultiBracketValidation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string string1 = "(){}[[]]";
            Console.WriteLine("The string {0} has balanced brackets: {1}", string1, MultiBracketValidation(string1) ? "true" : "false");

            string string2 = "{}{Code}Fellows](())";
            Console.WriteLine("The string {0} has balanced brackets: {1}", string2, MultiBracketValidation(string2) ? "true" : "false");
        }

        /// <summary>
        /// Takes a string and returns true if the brackets in that string are balanced, false otherwise.
        /// </summary>
        /// <param name="input">
        /// string: a string containing zero or more brackets
        /// </param>
        /// <returns>
        /// bool: true if the brackets in the input are balanced, false otherwise
        /// </returns>
        public static bool MultiBracketValidation(string input)
        {
            Stack<char> stack = new Stack<char>();
            char[] openingBrackets = new char[] { '{', '[', '(' };
            char[] closingBrackets = new char[] { '}', ']', ')' };
            foreach (char oneChar in input)
            {
                if (openingBrackets.Contains(oneChar))
                {
                    stack.Push(oneChar);
                }
                else if (closingBrackets.Contains(oneChar))
                {
                    char poppedChar = PopCharStackAndHandleNullRef(stack);
                    if (poppedChar == '\0' || closingBrackets[Array.IndexOf(openingBrackets, poppedChar)] != oneChar)
                    {
                        return false;
                    }
                }
            }
            return stack.IsEmpty();
        }

        /// <summary>
        /// Helper method to handle the NullReferenceException thrown by stack.Pop() on an empty stack.
        /// </summary>
        /// <param name="stack">
        /// Stack<char>: a stack of chars
        /// </param>
        /// <returns>
        /// char: if stack is not empty, the top char value from the stack. If stack is empty, '\0'.
        /// </returns>
        private static char PopCharStackAndHandleNullRef(Stack<char> stack)
        {
            char nextChar = '\0';
            try
            {
                nextChar = stack.Pop();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return nextChar;
        }
    }
}
