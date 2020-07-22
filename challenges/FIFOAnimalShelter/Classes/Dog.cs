using System;
using System.Collections.Generic;
using System.Text;

namespace FIFOAnimalShelter.Classes
{
    public class Dog : Animal
    {
        public override string Name 
        { 
            get => _name; 
            set => _name = value; 
        }
        private string _name;

        public Dog(string name)
        {
            Name = name;
        }
    }
}
