using System.IO;
using JokeGenerator.Config;
using JokeGenerator.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;

namespace JokeGenerator
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddTransient<IJokeGeneratorService, JokeGeneratorService>()
                        .AddSingleton<ICategoryApiService, CategoryApiService>()
                        .AddSingleton<IJokeApiService, JokeApiService>()
                        .AddSingleton<IRandomNameApiService, RandomNameApiService>()
                        .AddSingleton<IConsoleMenu, ConsoleMenu>()
                        .AddSingleton<IMenuConfig, MenuConfig>()
                        .AddHttpClient()
                        .RemoveAll<IHttpMessageHandlerBuilderFilter>();
                }).Build();
            
            var svc = ActivatorUtilities.CreateInstance<JokeGeneratorService>(host.Services);
            svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}