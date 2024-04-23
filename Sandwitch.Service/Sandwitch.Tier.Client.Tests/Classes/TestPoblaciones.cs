using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using System.Linq;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestPoblaciones : TestBase
    {
        [Test]
        public void Add()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-poblaciones"))).Click();

            Wait.Until(d => d.FindElement(By.ClassName("add-button"))).Click();

            Wait.Until(d => d.FindElement(By.Id("poblacion-add-modal")).Displayed);

            new Actions(Driver).KeyDown(Keys.Escape).Perform();

            Assert.Pass();
        }

        [Test]
        public void Edit()
        {
            Wait.Until(d => d.FindElement(By.Id("nav-poblaciones"))).Click();

            Wait.Until(d => d.FindElements(By.TagName("td")).First()).Click();

            Wait.Until(d => d.FindElement(By.Id("poblacion-update-modal")).Displayed);

            new Actions(Driver).KeyDown(Keys.Escape).Perform();

            Assert.Pass();
        }
    }
}
