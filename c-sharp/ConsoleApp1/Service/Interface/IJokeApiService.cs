using JokeGenerator.Domain;

namespace JokeGenerator.Service.Interface
{
    public interface IJokeApiService
    {
        string GetJokeText(Joke joke);
    }
}