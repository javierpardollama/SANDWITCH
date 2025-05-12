using NUnit.Framework;
using NUnit.Framework.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Sandwitch.Tier.Client.Tests.Classes
{
    public class TestBase
    {
        protected ChromeDriver Driver;

        protected WebDriverWait Wait;

        protected INetwork Network;

        private readonly string Path = $"{AppDomain.CurrentDomain.BaseDirectory}/{DateTime.Now:yyyy-MM-dd}/{TestContext.CurrentContext.Test.ClassName}";

        private List<HttpRequestData> Requests = [];

        private List<HttpResponseData> Responses = [];

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

            Network = Driver.Manage().Network;      

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromMilliseconds(30)
            };

            Driver.Navigate().GoToUrl("http://localhost:4200");
        }

        [SetUp]
        public void SetUp()
        {
            Responses = [];
            Requests = [];

            Network.AddResponseHandler(SetUpNetworkResponseHandler());
            Network.AddRequestHandler(SetUpNetworkRequestHandler());

            Network.StartMonitoring().Wait();
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            Network.ClearRequestHandlers();
            Network.ClearResponseHandlers();
            Network.StopMonitoring().Wait();

            if (TestContext.CurrentContext.Result.Outcome.Matches(ResultState.Error))
            {
                RecordScreen();
                RecordConsole();
                RecordRequests();
                RecordResponses();
            }
        }

        private NetworkResponseHandler SetUpNetworkResponseHandler() => new()
        {
            ResponseMatcher = httpresponse => true,
            ResponseTransformer = http => { Responses.Add(http); return http; }
        };

        private NetworkRequestHandler SetUpNetworkRequestHandler() => new()
        {
            RequestMatcher = httprequest => true,
            RequestTransformer = http => { Requests.Add(http); return http; }
        };

        private void RecordRequests()
        {
            var json = JsonSerializer.Serialize(Requests);

            File.WriteAllText($"{Path}/{TestContext.CurrentContext.Test.Name}.requests.json", json);
        }

        private void RecordResponses()
        {
            var json = JsonSerializer.Serialize(Responses);

            File.WriteAllText($"{Path}/{TestContext.CurrentContext.Test.Name}.responses.json", json);
        }

        private void RecordScreen()
        {
            var screenshot = Driver.TakeScreenshot();

            Directory.CreateDirectory(Path);

            screenshot.SaveAsFile($"{Path}/{TestContext.CurrentContext.Test.Name}.screen.png");
        }

        private void RecordConsole()
        {
            var logs = Driver.Manage().Logs;

            var entries = logs.GetLog(LogType.Browser).Where(x => x.Level == LogLevel.Severe).Select(x => x.Message).ToList();

            var json = JsonSerializer.Serialize(entries);

            File.WriteAllText($"{Path}/{TestContext.CurrentContext.Test.Name}.console.json", json);
        }      
    }
}
