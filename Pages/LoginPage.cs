using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow_Xero.Pages
{
    public class LoginPage
    {

        private readonly IWebDriver webDriver;

        
        public LoginPage(ScenarioContext scenarioContext) {
           webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
           
        }

        public IWebElement btnLogin => webDriver.FindElement(By.XPath("//*[@data-automationid='LoginSubmit--button']"));
        public IWebElement txtUsername => webDriver.FindElement(By.Name("Username"));
        public IWebElement txtPassword => webDriver.FindElement(By.Name("Password"));
        
        public void ClickLogin()
        {
           var btn =  webDriver.FindElement(By.XPath("//*[@class='login']"));
            btn.Click();
        }

        public void EnterCredentials(string username, string password) {
           
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByName("Username");
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Click();
            
        }


        
          
    }
}
