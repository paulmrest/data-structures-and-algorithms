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

        public Cat(string name)
        {
            Name = name;
        }
    }
}
