using System;
using System.Text;
using StacksAndQueues.Classes;

namespace FIFOAnimalShelter.Classes
{
    public enum AnimalPref
    {
        Dog = 1,
        Cat
    }

    public class AnimalShelter
    {
        public Queue<Dog> Dogs { get; set; }

        public Queue<Cat> Cats { get; set; }

        public AnimalShelter()
        {
            Dogs = new Queue<Dog>();
            Cats = new Queue<Cat>();
        }

        public void Enqueue(Animal animal)
        {

        }

        public Animal Dequeue(AnimalPref pref)
        {
            Animal animal = null;

            return animal;
        }
    }
}
