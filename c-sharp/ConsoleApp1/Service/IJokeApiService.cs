namespace JokeGenerator.Service
{
    public interface IJokeApiService
    {
        string GetJokeText(Joke joke);
    }
}