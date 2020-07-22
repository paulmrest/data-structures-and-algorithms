namespace FIFOAnimalShelter.Classes
{
    public class Cat : Animal
    {
        public override string Name
        {
            get => _name;
            set => _name = value;
        }
        private string _name;

        /// <summary>
        /// Instantiates a new Cat object with a name.
        /// </summary>
        /// <param name="name">
        /// string: a name for this Cat instance
        /// </param>
        public Cat(string name)
        {
            Name = name;
        }
    }
}
