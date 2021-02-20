using System.Collections.Generic;
using Newtonsoft.Json;

namespace JokeGenerator
{
    public class Joke
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private string _category;

        public Joke()
        {
            _firstName = null;
            _lastName = null;
        }
        public Joke(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public void SetCategory(string category)
        {
            _category = category;
        }

        public string GetCategory()
        {
            return _category;
        }

        public string GetFirstName()
        {
            return _firstName;
        }
        
        public string GetLastName()
        {
            return _lastName;
        }
    }
}