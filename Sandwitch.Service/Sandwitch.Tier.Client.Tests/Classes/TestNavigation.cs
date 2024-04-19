using System;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestNavigation
    {
        private ChromeDriver Driver;

        [OneTimeSetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://localhost:4200");
        }

        [Test]
        public void Home()
        {
            Assert.That(Driver.Title.Contains("Sandwitch"), Is.True);
        }

        [Test]
        public void Provincias()
        {
            Driver.FindElement(By.Id("nav-provincias")).Click();

            Assert.That(Driver.Url.Contains("provincias"), Is.True);
        }

        [Test]
        public void Poblaciones()
        {
            Driver.FindElement(By.Id("nav-poblaciones")).Click();

            Assert.That(Driver.Url.Contains("poblaciones"), Is.True);
        }

        [Test]
        public void Arenales()
        {
            Driver.FindElement(By.Id("nav-arenales")).Click();

            Assert.That(Driver.Url.Contains("arenales"), Is.True);
        }

        [Test]
        public void Banderas()
        {
            Driver.FindElement(By.Id("nav-banderas")).Click(); ;


            Assert.That(Driver.Url.Contains("banderas"), Is.True);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}