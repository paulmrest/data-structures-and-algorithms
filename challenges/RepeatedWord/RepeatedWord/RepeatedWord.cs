using System;
using GenericIComparableBST;
using GenericIComparableBST.Classes;
using Microsoft.VisualBasic.CompilerServices;

namespace RepeatedWord
{
    public class RepeatedWord
    {
        /// <summary>
        /// Static method. Given a string of "words", finds the first word (CI) that repeats and returns it. If no words repeat, returns an empty string.
        /// </summary>
        /// <param name="input">
        /// string: a string of words
        /// </param>
        /// <returns>
        /// string: the first repeated word present in the input (CI), or an empty string
        /// </returns>
        public static string FindRepeatedWord(string input)
        {
            char[] delimiters = { ' ', ',', '.', ':', ';', '?', '!' };
            string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 1)
            {
                BinarySearchTree<string> wordTree = new BinarySearchTree<string>();
                foreach (string oneWord in words)
                {
                    if (wordTree.Contains(oneWord.ToLower()))
                    {
                        return oneWord;
                    }
                    else
                    {
                        wordTree.Add(oneWord.ToLower());
                    }
                }
            }
            return "";
        }
    }
}
