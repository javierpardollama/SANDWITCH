using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    public abstract class TestBase
    {
        protected ChromeDriver Driver;

        protected WebDriverWait Wait;

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

        protected List<string> GetBrowserError()
        {
            var logs = Driver.Manage().Logs;
            var logEntries = logs.GetLog(LogType.Browser);
            return logEntries.Where(x => x.Level == LogLevel.Severe).Select(x => x.Message).ToList();          
        }

        protected void Test(Action action)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                var screenshot = Driver.TakeScreenshot();

                var filePath = $"{DateTime.Now}-{action.Method.Name}";

                screenshot.SaveAsFile(filePath);

                throw;
            }
        }
    }
}
