namespace DIASP.Model
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public string Style { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name:{Name} Author:{Author} Style:{Style} Age:{Age}";
        }
    }
}
