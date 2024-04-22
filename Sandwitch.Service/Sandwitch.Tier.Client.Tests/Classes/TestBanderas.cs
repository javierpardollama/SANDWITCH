using System.Linq;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    [TestFixture]
    public class TestBanderas : TestBase
    {    
        [Test]
        public void Add()
        {
            Test(() =>
            {
                Wait.Until(d => d.FindElement(By.Id("nav-banderas"))).Click();

                Wait.Until(d => d.FindElement(By.ClassName("add-button"))).Click();

                Wait.Until(d => d.FindElement(By.Id("bandera-add-modal")).Displayed);

                new Actions(Driver).KeyDown(Keys.Escape).Perform();
            });
        }

        [Test]
        public void Edit()
        {
            Test(() =>
            {
                Wait.Until(d => d.FindElement(By.Id("nav-banderas"))).Click();

                Wait.Until(d => d.FindElements(By.TagName("td")).First()).Click();

                Wait.Until(d => d.FindElement(By.Id("bandera-update-modal")).Displayed);

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
