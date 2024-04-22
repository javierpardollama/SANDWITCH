using NUnit.Framework;
using NUnit.Framework.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    public abstract class TestBase
    {
        protected ChromeDriver Driver;

        protected WebDriverWait Wait;

        private readonly string Path = $"{AppDomain.CurrentDomain.BaseDirectory}/{DateTime.Now.ToString(@"yyyy-MM-dd")}/{TestContext.CurrentContext.Test.ClassName}";

        [OneTimeSetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200)
            };

            Driver.Navigate().GoToUrl("https://localhost:4200");
        }


        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Matches(ResultState.Error))
            {
                RecordScreen();
                RecordConsole();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }

        private void RecordScreen()
        {
            var screenshot = Driver.TakeScreenshot();

            Directory.CreateDirectory(Path);

            screenshot.SaveAsFile($"{Path}/{TestContext.CurrentContext.Test.Name}.png");
        }

        private void RecordConsole()
        {
            var logs = Driver.Manage().Logs;

            var entries = logs.GetLog(LogType.Browser).Where(x => x.Level == LogLevel.Severe).Select(x => x.Message).ToList();

            var json = JsonSerializer.Serialize(entries);

            File.WriteAllText($"{Path}/{TestContext.CurrentContext.Test.Name}.json", json);
        }
    }
}
