using System;

namespace JokeGenerator.Service
{
    public interface IRandomNameApiService
    {
        Tuple<string, string> GetRandomName();
    }
}