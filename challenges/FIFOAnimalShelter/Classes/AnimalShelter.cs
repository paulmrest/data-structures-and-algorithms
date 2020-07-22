using System;
using StacksAndQueues.Classes;

namespace FIFOAnimalShelter.Classes
{
    public class AnimalShelter
    {
        private Queue<Dog> Dogs { get; set; }

        private Queue<Cat> Cats { get; set; }

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

        public Animal Dequeue(string pref)
        {
            if (pref == "no preference" && (PeekCats() != null || PeekDogs() != null))
            {
                if (PeekCats() != null && PeekDogs() != null)
                {
                    DateTime oldestCat = PeekCats().DateTimeCaptured;
                    DateTime oldestDog = PeekDogs().DateTimeCaptured;
                    return oldestCat < oldestDog ? (Animal)Cats.Dequeue() : (Animal)Dogs.Dequeue();
                }
                else if (PeekCats() != null)
                {
                    return (Animal)Cats.Dequeue();
                }
                else
                {
                    return (Animal)Dogs.Dequeue();
                }
            }
            else if (pref == "cat" && PeekCats() != null)
            {
                return (Animal)Cats.Dequeue();
            }
            else if (pref == "dog" && PeekDogs() != null)
            {
                return (Animal)Dogs.Dequeue();
            }
            return null;
        }

        private Cat PeekCats()
        {
            Cat cat = null;
            try
            {
                cat = Cats.Peek();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return cat;
        }

        private Dog PeekDogs()
        {
            Dog dog = null;
            try
            {
                dog = Dogs.Peek();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return dog;
        }
    }
}
