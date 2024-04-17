using System;
using System.IO;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Sandwitch.Tier.Client.Tests.Classes
{
    public class TestHome
    {
        private IWebDriver Driver;

        [OneTimeSetUp]
        public void Setup()
        {            
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            Driver = new ChromeDriver(path + @"\Drivers");
        }

        [Test]
        public void Index()
        {
            Driver.Navigate().GoToUrl("https://localhost:4200");

            Assert.That(Driver.Title.Contains(""), Is.True);
        }      


        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}  