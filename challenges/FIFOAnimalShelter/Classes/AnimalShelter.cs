using System;
using StacksAndQueues.Classes;

namespace FIFOAnimalShelter.Classes
{
    public enum AnimalPref
    {
        Dog = 1,
        Cat,
        NoPreference
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
            animal.DateTimeCaptured = DateTime.Now;
            if (animal is Cat)
            {
                Cat cat = (Cat)animal;
                Cats.Enqueue(cat);
            }
            else if (animal is Dog)
            {
                Dog dog = (Dog)animal;
                Dogs.Enqueue(dog);
            }
        }

        public Animal Dequeue(AnimalPref pref)
        {
            Animal animal = null;
            try
            {
                if (pref == AnimalPref.NoPreference && (Cats.Peek() != null || Dogs.Peek() != null))
                {
                    if (Cats.Peek() != null && Dogs.Peek() != null)
                    {
                        DateTime oldestCat = Cats.Peek().DateTimeCaptured;
                        DateTime oldestDog = Dogs.Peek().DateTimeCaptured;
                        animal = oldestCat < oldestDog ? (Animal)Cats.Dequeue() : (Animal)Dogs.Dequeue();
                    }
                    else if (Cats.Peek() != null)
                    {
                        animal = (Animal)Cats.Dequeue();
                    }
                    else
                    {
                        animal = (Animal)Dogs.Dequeue();
                    }
                }
                else if (pref == AnimalPref.Cat && Cats.Peek() != null)
                {
                    animal = (Animal)Cats.Dequeue();
                }
                else if (pref == AnimalPref.Dog && Dogs.Peek() != null)
                {
                    animal = (Animal)Dogs.Dequeue();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return animal;
        }
    }
}
