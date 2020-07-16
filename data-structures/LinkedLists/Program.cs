using System;
using LLLibrary;

namespace Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAndPrintLinkedList();
            LinkedList randList = new LinkedList();
        }

        /// <summary>
        /// Builds and prints a linked list from the user's input.
        /// </summary>
        static void BuildAndPrintLinkedList()
        {
            Console.WriteLine("We're going to build our very own linked list! Wheeeeee!");
            LinkedList list = new LinkedList();
            CreateLinkedList(list);
            Console.WriteLine("Great job! You built a linked list that looks like this:");
            Console.WriteLine(list.ToString());
            CheckLinkedListForValues(list);
        }

        /// <summary>
        /// Takes in a LinkedList object, takes user input and adds nodes to that LinkedList.
        /// </summary>
        /// <param name="list">The LinkedList object to have nodes added from user input</param>
        static void CreateLinkedList(LinkedList list)
        {
            int count = 0;
            while (true)
            {
                if (count == 0)
                {
                    Console.Write("Enter the integer you'd like to be the first node of your linked list: ");
                    string userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out int result))
                    {
                        list.Insert(result);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer value.");
                    }
                }
                else
                {
                    Console.WriteLine("Your linked list so far looks like this:");
                    Console.WriteLine(list.ToString());
                    Console.WriteLine("Would you like to add another node? (y/n)");
                    string userInput = Console.ReadLine();
                    if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
                    {
                        while (true)
                        {
                            Console.Write("Enter your next node's integer value: ");
                            string userInt = Console.ReadLine();
                            if (Int32.TryParse(userInt, out int result))
                            {
                                list.Insert(result);
                                count++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid integer value.");
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// Checks user input against the parameter LinkedList, and tells the user if the LinkedList contains that value.
        /// </summary>
        /// <param name="list">A LinkedList object</param>
        static void CheckLinkedListForValues(LinkedList list)
        {
            while (true)
            {
                Console.Write("Enter an integer to check if it's in your linked list: ");
                string userEntry = Console.ReadLine();
                if (Int32.TryParse(userEntry, out int result))
                {
                    bool containsInt = list.Includes(result);
                    Console.WriteLine("Your linked list does {0}contain the number, {1}, you entered.", containsInt ? "" : "not ", result);
                    Console.Write("Would you like to check if your linked list contains another integer? (y/n) ");
                    string userInput = Console.ReadLine();
                    if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer value.");
                }
            }

        }
    }
}