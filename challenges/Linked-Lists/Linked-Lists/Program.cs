using System;
using LLLibrary;

namespace Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAndPrintLinkedList();
        }

        static void BuildAndPrintLinkedList()
        {
            Console.WriteLine("We're going to build our very own linked list! Wheeeeee!");
            int count = 0;
            LinkedList list = new LinkedList();
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
            Console.WriteLine("Great job! You built a linked list with {0} nodes!", count);
            Console.WriteLine(list.ToString());
        }
    }
}
