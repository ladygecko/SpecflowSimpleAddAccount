using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow_Unleashed.cs
{
    [Binding]
    public sealed class GeneralHooks
    {
        private OpenQA.Selenium.IWebDriver _driver;
     
        [BeforeScenario]
        
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.unleashedsoftware.com/");
            scenarioContext.Add("currentDriver", _driver);
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }
    }
}
