﻿using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Sandwitch.Test.Client.Components;

[TestFixture]
public class ArenalesTest : BaseTest
{
    [Test]
    public void Add()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-arenales"))).Click();

        Wait.Until(d => d.FindElement(By.ClassName("add-button"))).Click();

        Wait.Until(d => d.FindElement(By.Id("arenal-add-modal")).Displayed);

        new Actions(Driver).KeyDown(Keys.Escape).Perform();

        Assert.Pass();
    }

    [Test]
    public void Edit()
    {
        Wait.Until(d => d.FindElement(By.Id("nav-toggle"))).Click();

        Wait.Until(d => d.FindElement(By.Id("nav-arenales"))).Click();

        Wait.Until(d => d.FindElements(By.TagName("td")).First()).Click();

        Wait.Until(d => d.FindElement(By.Id("arenal-update-modal")).Displayed);

        new Actions(Driver).KeyDown(Keys.Escape).Perform();

        Assert.Pass();
    }
}