using System;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestArenales
    {
        private ChromeDriver Driver;
        private WebDriverWait Wait;

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

        [Test]
        public void Add()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-arenales"))).Click();

            Wait.Until(d => d.FindElement(By.ClassName("add-button"))).Click();

            Wait.Until(d => d.FindElement(By.Id("arenal-add-modal")).Displayed);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
