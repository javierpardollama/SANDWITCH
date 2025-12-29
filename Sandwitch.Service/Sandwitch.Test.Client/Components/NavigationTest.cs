using NUnit.Framework;
using OpenQA.Selenium;

namespace Sandwitch.Test.Client.Components;

[TestFixture]
public class NavigationTest : BaseTest
{
    [Test]
    public void Home()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-search"))).Click();

        Assert.That(Driver.Title.Contains("Sandwitch"), Is.True);
    }

    [Test]
    public void States()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-states"))).Click();

        Wait.Until(d => d.Url.Contains("States"));

        Assert.That(Driver.Url.Contains("States"), Is.True);
    }

    [Test]
    public void Townes()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-towns"))).Click();

        Wait.Until(d => d.Url.Contains("Towns"));

        Assert.That(Driver.Url.Contains("Towns"), Is.True);
    }

    [Test]
    public void Beaches()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-Beaches"))).Click();

        Wait.Until(d => d.Url.Contains("Beaches"));

        Assert.That(Driver.Url.Contains("Beaches"), Is.True);
    }

    [Test]
    public void Flags()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-flags"))).Click();

        Wait.Until(d => d.Url.Contains("Flags"));

        Assert.That(Driver.Url.Contains("Flags"), Is.True);
    }

    [Test]
    public void Winds()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-winds"))).Click();

        Wait.Until(d => d.Url.Contains("Winds"));

        Assert.That(Driver.Url.Contains("Winds"), Is.True);
    }
}