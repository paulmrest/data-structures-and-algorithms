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

        /// <summary>
        /// Instantiates a new Dog object with a name.
        /// </summary>
        /// <param name="name">
        /// string: a name for this Dog instance
        /// </param>
        public Dog(string name)
        {
            Name = name;
        }
    }
}
