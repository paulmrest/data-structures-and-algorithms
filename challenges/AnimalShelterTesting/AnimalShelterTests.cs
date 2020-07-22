using System;
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
            Assert.Null(testShelter.Dequeue(AnimalPref.Cat));
        }
    }
}
