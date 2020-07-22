using Xunit;
using FIFOAnimalShelter.Classes;

namespace AnimalShelterTesting
{
    public class AnimalShelterTests
    {
        [Fact]
        public void CanCreateAnEmptyAnimalShelter()
        {
            //Arrange
            AnimalShelter testShelter = new AnimalShelter();

            //Assert
            Assert.Null(testShelter.Dequeue("cat"));
        }

        [Fact]
        public void CanDequeueTheOldestAnimalWithNoPref()
        {
            //Arrange
            AnimalShelter testShelter = new AnimalShelter();

            //Act
            Dog dog1 = new Dog("Albert");
            testShelter.Enqueue(dog1);

            Cat cat1 = new Cat("Bowling Ball");
            testShelter.Enqueue(cat1);

            //Assert
            Assert.Equal(dog1, testShelter.Dequeue("no preference"));
        }

        [Fact]
        public void CanDequeueTheOldestAnimalWithCatPref()
        {
            //Arrange
            AnimalShelter testShelter = new AnimalShelter();

            //Act
            Dog dog1 = new Dog("Albert");
            testShelter.Enqueue(dog1);

            Cat cat1 = new Cat("Bowling Ball");
            testShelter.Enqueue(cat1);

            Dog dog2 = new Dog("Sheetrock");
            testShelter.Enqueue(dog2);

            Cat cat2 = new Cat("Knitty Smitty");
            testShelter.Enqueue(cat2);

            Dog dog3 = new Dog("Brah");
            testShelter.Enqueue(dog3);

            Cat cat3 = new Cat("Wish Bone");
            testShelter.Enqueue(cat3);

            //Assert
            Assert.Equal(cat1, testShelter.Dequeue("cat"));
        }

        [Fact]
        public void CanDequeueTheOldestAnimalWithDogPref()
        {
            //Arrange
            AnimalShelter testShelter = new AnimalShelter();

            //Act
            Dog dog1 = new Dog("Albert");
            testShelter.Enqueue(dog1);

            Cat cat1 = new Cat("Bowling Ball");
            testShelter.Enqueue(cat1);

            Dog dog2 = new Dog("Sheetrock");
            testShelter.Enqueue(dog2);

            Cat cat2 = new Cat("Knitty Smitty");
            testShelter.Enqueue(cat2);

            Dog dog3 = new Dog("Brah");
            testShelter.Enqueue(dog3);

            Cat cat3 = new Cat("Wish Bone");
            testShelter.Enqueue(cat3);

            //Assert
            Assert.Equal(dog1, testShelter.Dequeue("dog"));
        }

        [Fact]
        public void ReturnsNullWhenNoCatsWithCatPref()
        {
            //Arrange
            AnimalShelter testShelter = new AnimalShelter();

            //Act
            Dog dog1 = new Dog("Albert");
            testShelter.Enqueue(dog1);

            Cat cat1 = new Cat("Bowling Ball");
            testShelter.Enqueue(cat1);

            Dog dog2 = new Dog("Sheetrock");
            testShelter.Enqueue(dog2);

            Cat cat2 = new Cat("Knitty Smitty");
            testShelter.Enqueue(cat2);

            Dog dog3 = new Dog("Brah");
            testShelter.Enqueue(dog3);

            Cat cat3 = new Cat("Wish Bone");
            testShelter.Enqueue(cat3);

            testShelter.Dequeue("cat");
            testShelter.Dequeue("cat");
            testShelter.Dequeue("cat");

            //Assert
            Assert.Null(testShelter.Dequeue("cat"));
        }

        [Fact]
        public void ReturnsNullWhenNoDogsWithDogPref()
        {
            //Arrange
            AnimalShelter testShelter = new AnimalShelter();

            //Act
            Dog dog1 = new Dog("Albert");
            testShelter.Enqueue(dog1);

            Cat cat1 = new Cat("Bowling Ball");
            testShelter.Enqueue(cat1);

            Dog dog2 = new Dog("Sheetrock");
            testShelter.Enqueue(dog2);

            Cat cat2 = new Cat("Knitty Smitty");
            testShelter.Enqueue(cat2);

            Dog dog3 = new Dog("Brah");
            testShelter.Enqueue(dog3);

            Cat cat3 = new Cat("Wish Bone");
            testShelter.Enqueue(cat3);

            testShelter.Dequeue("dog");
            testShelter.Dequeue("dog");
            testShelter.Dequeue("dog");

            //Assert
            Assert.Null(testShelter.Dequeue("dog"));
        }
    }
}
