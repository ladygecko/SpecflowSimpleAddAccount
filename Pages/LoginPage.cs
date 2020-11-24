using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow_Unleashed.Pages
{
    public class LoginPage
    {

        private readonly IWebDriver webDriver;

        
        public LoginPage(ScenarioContext scenarioContext) {
           webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
           
        }

        public IWebElement btnLogin => webDriver.FindElement(By.XPath("//*[@class='login']"));
        public IWebElement txtUsername => webDriver.FindElement(By.Id("username"));
        public IWebElement txtPassword => webDriver.FindElement(By.Id("password"));
        public IWebElement btnLogonUser => webDriver.FindElement(By.Id("btnLogOn"));
        public void ClickLogin()
        {
           var btn =  webDriver.FindElement(By.XPath("//*[@class='login']"));
            //btnLogin.Click();
            btn.Click();
        }

        public void EnterCredentials(string username, string password) {
           
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByID("username");
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            
        }


        public void ClickLoginButton() => btnLogonUser.Submit();
          
    }
}
