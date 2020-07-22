using System;
using FIFOAnimalShelter.Classes;

namespace FIFOAnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the FIFO Animal Shelter.");
            AnimalShelter shelter = new AnimalShelter();
            Console.WriteLine("First we'll add a dog named \"Albert\" to the shelter");
            shelter.Enqueue(new Dog("Albert"));
            Console.WriteLine("Next we'll add a cat named \"Bowling Ball\"");
            shelter.Enqueue(new Cat())
        }
    }
}
