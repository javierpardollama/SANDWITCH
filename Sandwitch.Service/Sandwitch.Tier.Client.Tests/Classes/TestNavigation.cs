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
            Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();
            
            Wait.Until(d => d.FindElement(By.Id("nav-search"))).Click();

            Assert.That(Driver.Title.Contains("Sandwitch"), Is.True);
        }

        [Test]
        public void Provincias()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();
            
            Wait.Until(d => d.FindElement(By.Id("nav-provincias"))).Click();

            Wait.Until(d => d.Url.Contains("provincias"));

            Assert.That(Driver.Url.Contains("provincias"), Is.True);
        }

        [Test]
        public void Poblaciones()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();
            
            Wait.Until(d => d.FindElement(By.Id("nav-poblaciones"))).Click();

            Wait.Until(d => d.Url.Contains("poblaciones"));

            Assert.That(Driver.Url.Contains("poblaciones"), Is.True);
        }

        [Test]
        public void Arenales()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();
            
            Wait.Until(d => d.FindElement(By.Id("nav-arenales"))).Click();

            Wait.Until(d => d.Url.Contains("arenales"));

            Assert.That(Driver.Url.Contains("arenales"), Is.True);
        }

        [Test]
        public void Banderas()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();
            
            Wait.Until(d => d.FindElement(By.Id("nav-banderas"))).Click();

            Wait.Until(d => d.Url.Contains("banderas"));

            Assert.That(Driver.Url.Contains("banderas"), Is.True);
        }

        [Test]
        public void Vientos()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();
            
            Wait.Until(d => d.FindElement(By.Id("nav-vientos"))).Click();

            Wait.Until(d => d.Url.Contains("vientos"));

            Assert.That(Driver.Url.Contains("vientos"), Is.True);
        }
    }
}
