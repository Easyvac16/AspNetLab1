namespace DIASP.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name:{Name} Surname:{Surname} Age:{Age}";
        }
    }
}
