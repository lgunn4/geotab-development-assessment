using System.Collections.Generic;
using JokeGenerator.Config;
using JokeGeneratorTests.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTests
{
    [TestClass]
    public class MenuConfigTest
    {
        [TestMethod]
        public void PassingInEmptyConfigurationMakesAllValuesNull()
        {
            var configBuilder = new ConfigurationBuilder();
            var configRoot = configBuilder.Build();

            var menu = new MenuConfig(configRoot);
            
            Assert.IsNull(menu.MainMenuPrompt);
            Assert.IsNull(menu.MainMenuOptions);
            Assert.IsNull(menu.RandomJokeOption);
            Assert.IsNull(menu.InstructionsPrompt);
            Assert.IsNull(menu.QuitOption);
            Assert.IsNull(menu.CategoryInputPrompt);
            Assert.IsNull(menu.RandomNamePrompt);
            Assert.IsNull(menu.SpecifyCategoryPrompt);
            Assert.IsNull(menu.NumberOfJokesPrompt);
            Assert.IsNull(menu.CategoryOption);
            Assert.AreEqual('\0', menu.InstructionsChar);
        }

        [TestMethod]
        public void PassingInConfigurationFileBuildsMenuConfig()
        {
            var config = ConfigurationInitializer.InitConfiguration();
            var menuConfig = new MenuConfig(config);

            Assert.AreEqual("C", menuConfig.CategoryOption);
            Assert.AreEqual('I', menuConfig.InstructionsChar);
            Assert.AreEqual("InstructionsPrompt", menuConfig.InstructionsPrompt);
            Assert.AreEqual("CategoryPrompt", menuConfig.CategoryInputPrompt);
            
            var testMenuOptions = new List<string>();
            testMenuOptions.Add("C");
            testMenuOptions.Add("R");
            testMenuOptions.Add("Q");
            Assert.AreEqual(testMenuOptions.Count, menuConfig.MainMenuOptions.Length);
            foreach (var option in menuConfig.MainMenuOptions)
            {
                Assert.IsTrue(testMenuOptions.Contains(option));
            }
        }
        
    }
}