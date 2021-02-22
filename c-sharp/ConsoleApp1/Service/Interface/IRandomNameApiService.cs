using System;

namespace JokeGenerator.Service.Interface
{
    public interface IRandomNameApiService
    {
        Tuple<string, string> GetRandomName();
    }
}