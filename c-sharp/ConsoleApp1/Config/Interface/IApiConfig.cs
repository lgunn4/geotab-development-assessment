namespace JokeGenerator.Config.Interface
{
    public interface IApiConfig
    {
        string JokeApiUrl { get; }
        string CategoryApiUrl { get; }
        string RandomNameApiUrl { get; }
    }
}