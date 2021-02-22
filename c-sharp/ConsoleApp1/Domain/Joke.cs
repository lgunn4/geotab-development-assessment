namespace JokeGenerator.Domain
{
    public class Joke
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Category { get; set; }

        public Joke() {}
        public Joke(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}