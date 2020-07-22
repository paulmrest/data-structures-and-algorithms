using System;

namespace FIFOAnimalShelter.Classes
{
    public abstract class Animal
    {
        public abstract string Name { get; set; }

        public virtual DateTime DateTimeCaptured { get; set; }
    }
}
