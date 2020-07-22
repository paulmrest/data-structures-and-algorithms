using System;
using FIFOAnimalShelter.Classes;

namespace FIFOAnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the FIFO Animal Shelter.");
            Console.WriteLine();
            AnimalShelter shelter = new AnimalShelter();
            Console.WriteLine("First we'll add a dog named \"Albert\" to the shelter");
            shelter.Enqueue(new Dog("Albert"));
            Console.WriteLine();
            Console.WriteLine("Next we'll add a cat named \"Bowling Ball\"");
            shelter.Enqueue(new Cat("Bowling Ball"));
            Console.WriteLine();
            Console.WriteLine("Next we'll add the following two dogs to the shelter:");
            Console.WriteLine("\"Sheetrock\"");
            Console.WriteLine("\"Brave Toaster\"");
            shelter.Enqueue(new Dog("Sheetrock"));
            shelter.Enqueue(new Dog("Brave Toaster"));
            Console.WriteLine();
            Console.WriteLine("Finally, we'll add the following two cats to the shelter:");
            Console.WriteLine("\"Knitty Smitty\"");
            Console.WriteLine("\"Wish Bone\"");
            shelter.Enqueue(new Cat("Knitty Smitty"));
            shelter.Enqueue(new Cat("Wish Bone"));
            Console.WriteLine();

            FreeTheAnimals(shelter);
        }

        private static void FreeTheAnimals(AnimalShelter shelter)
        {
            bool freedomRings = true;
            while (freedomRings)
            {
                Console.WriteLine("Would you like to free a dog or a cat? Or no preference?");
                Console.Write("Enter a \"dog\", \"cat\", or \"no preference\": ");
                string rawPrefEntry = Console.ReadLine();

                //AnimalPref pref;
                //while (true)
                //{
                //    Console.Write("Enter a \"dog\", \"cat\", or \"no preference\": ");
                //    string rawPrefEntry = Console.ReadLine();
                //    if (Int32.TryParse(rawPrefEntry, out int userPref) && userPref > 0 && userPref < 4)
                //    {
                //        pref = (AnimalPref)userPref;
                //        break;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Please enter a valid number");
                //    }
                //}

                Animal freedAnimal = shelter.Dequeue(rawPrefEntry);
                if (freedAnimal != null)
                {
                    Console.WriteLine("You've freed {0}, a {1}.", freedAnimal.Name, freedAnimal.GetType().Name);
                }
                else
                {
                    Console.WriteLine("You didn't free any animals. Either the shelter is empty or you mistyped.");
                }
                Console.Write("Would you like to try to free another animal? (y/n) ");
                string rawContinueEntry = Console.ReadLine();
                if (rawContinueEntry.ToLower() != "y" && rawContinueEntry.ToLower() != "yes")
                {
                    Console.WriteLine("I hope you can live with yourself...");
                    freedomRings = false;
                }
                Console.WriteLine();
            }
        }
    }
}
