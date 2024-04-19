using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Sandwitch.Tier.Client.Tests.Classes
{
    public class TestNavigation
    {
        private ChromeDriver Driver;

        [OneTimeSetUp]
        public void Setup()
        {           
            Driver = new ChromeDriver();
           
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
            var @elememt = Driver.FindElement(By.Id("nav-provincias"));
            @elememt.Click();

            Assert.That(Driver.Url.Contains("provincias"), Is.True);
        }

        [Test]
        public void Poblaciones()
        {
            var @elememt = Driver.FindElement(By.Id("nav-poblaciones"));
            @elememt.Click();

            Assert.That(Driver.Url.Contains("poblaciones"), Is.True);
        }

        [Test]
        public void Arenales()
        {
            var @elememt = Driver.FindElement(By.Id("nav-arenales"));
            @elememt.Click();

            Assert.That(Driver.Url.Contains("arenales"), Is.True);
        }

        [Test]
        public void Banderas()
        {
            var @elememt = Driver.FindElement(By.Id("nav-banderas"));
            @elememt.Click();

            Assert.That(Driver.Url.Contains("banderas"), Is.True);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}  