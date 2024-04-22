using NUnit.Framework;

using OpenQA.Selenium;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestNavigation : TestBase
    {
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
            Driver.FindElement(By.Id("nav-banderas")).Click();

            Assert.That(Driver.Url.Contains("banderas"), Is.True);
        }

        [Test]
        public void Vientos()
        {
            Driver.FindElement(By.Id("nav-vientos")).Click();

            Assert.That(Driver.Url.Contains("vientos"), Is.True);
        }
    }
}