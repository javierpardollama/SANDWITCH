using System;
using System.Linq;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestProvincias
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
            Wait.Until(d => d.FindElement(By.Id("nav-provincias"))).Click();

            Wait.Until(d => d.FindElement(By.ClassName("add-button"))).Click();

            Wait.Until(d =>  d.FindElement(By.Id("provincia-add-modal")).Displayed );

            new Actions(Driver).KeyDown(Keys.Escape).Perform();
        }

        [Test]
        public void Edit()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-provincias"))).Click();

            Wait.Until(d => d.FindElements(By.TagName("td")).First()).Click();

            Wait.Until(d => d.FindElement(By.Id("provincia-update-modal")).Displayed);

            new Actions(Driver).KeyDown(Keys.Escape).Perform();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
