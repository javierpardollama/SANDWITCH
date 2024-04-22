using System.Linq;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestVientos : TestBase
    {
        [Test]
        public void Add()
        {
            Test(() =>
            {
                Wait.Until(d => d.FindElement(By.Id("nav-vientos"))).Click();

                Wait.Until(d => d.FindElement(By.ClassName("add-button"))).Click();

                Wait.Until(d => d.FindElement(By.Id("viento-add-modal")).Displayed);

                new Actions(Driver).KeyDown(Keys.Escape).Perform();
            });
        }

        [Test]
        public void Edit()
        {
            Test(() =>
            {
                Wait.Until(d => d.FindElement(By.Id("nav-vientos"))).Click();

                Wait.Until(d => d.FindElements(By.TagName("td")).First()).Click();

                Wait.Until(d => d.FindElement(By.Id("viento-update-modal")).Displayed);

                new Actions(Driver).KeyDown(Keys.Escape).Perform();
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
