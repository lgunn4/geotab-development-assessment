using System;
using JokeGenerator.Config;
using JokeGeneratorTests.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTests
{
    [TestClass]
    public class ConsoleMenuConfigTests
    {
        [TestMethod]
        public void PassingInEmptyConfigurationMakesAllValuesNull()
        {
            var configBuilder = new ConfigurationBuilder();
            var configRoot = configBuilder.Build();

            var consoleMenuConfig = new ConsoleMenuConfig(configRoot);
            
            Assert.AreEqual(consoleMenuConfig.GetDefaultColor(), consoleMenuConfig.InformationTextColor);
            Assert.AreEqual(consoleMenuConfig.GetDefaultColor(), consoleMenuConfig.InputTextColor);
            Assert.AreEqual(consoleMenuConfig.GetDefaultColor(), consoleMenuConfig.PromptTextColor);
        }
        
        [TestMethod]
        public void PassingInConfigFileBuildsConsoleMenuConfig()
        {
            var consoleMenuConfig = new ConsoleMenuConfig(ConfigurationInitializer.InitConfiguration());
            
            Assert.AreEqual(ConsoleColor.Red, consoleMenuConfig.PromptTextColor);
            Assert.AreEqual(ConsoleColor.White, consoleMenuConfig.InputTextColor);
            Assert.AreEqual(ConsoleColor.Yellow, consoleMenuConfig.InformationTextColor);
        }
    }
}