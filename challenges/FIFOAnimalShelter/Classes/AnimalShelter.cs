using System;
using StacksAndQueues.Classes;

namespace FIFOAnimalShelter.Classes
{
    public class AnimalShelter
    {
        private Queue<Dog> Dogs { get; set; }

        private Queue<Cat> Cats { get; set; }

        /// <summary>
        /// Instantiates a new AnimalShelter object.
        /// </summary>
        public AnimalShelter()
        {
            Dogs = new Queue<Dog>();
            Cats = new Queue<Cat>();
        }

        /// <summary>
        /// Stores an object that inherits from Animal.
        /// </summary>
        /// <param name="animal">
        /// Animal: an object that inherits from Animal.
        /// </param>
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

        /// <summary>
        /// Retrieves an Animal in FIFO ordering, based off the string parameter "pref":
        /// <para>
        /// If pref is "cat" and there are Cats in the shelter, returns the cat that's been the shelter the longest. If there are no cats in the shelter, returns null.
        /// </para>
        /// <para>
        /// If pref is "dog" and there are Dogs in the shelter, returns the dog that's been the shelter the longest. If there are no dogs in the shelter, returns null.
        /// </para>
        /// <para>
        /// If pref is "no preference" and there are Cats or Dogs in the shelter, returns whichever has been in the shelter the longest. If there are only Cats or Dogs, returns the animal that's been in the shelter the longest. If no animals are in the shelter, returns null.
        /// </para>
        /// </summary>
        /// <param name="pref">
        /// string: the preferred animal
        /// </param>
        /// <returns>
        /// Animal: the animal released from the shelter
        /// </returns>
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

        /// <summary>
        /// Handles the exception thrown by Queue.Peek() for the Cats queue.
        /// </summary>
        /// <returns>
        /// Cat: if Cats queue is not empty, returns a reference to the Front Cat without affecting the queue. If Cats is empty, returns null.
        /// </returns>
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

        /// <summary>
        /// Handles the exception thrown by Queue.Peek() for the Dogs queue.
        /// </summary>
        /// <returns>
        /// Dog: if Dogs queue is not empty, returns a reference to the Front Dog without affecting the queue. If Dogs is empty, returns null.
        /// </returns>
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
