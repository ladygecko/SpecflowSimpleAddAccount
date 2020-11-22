using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specflow_Unleashed.Pages
{
    public class LoginPage
    {
        
        public IWebDriver webDriver { get; }
        
        public LoginPage(IWebDriver webDriver) {
            this.webDriver = webDriver;
           

        }

        public IWebElement btnLogin => webDriver.FindElement(By.XPath("//*[@class='login']"));
        public IWebElement txtUsername => webDriver.FindElement(By.Id("username"));
        public IWebElement txtPassword => webDriver.FindElement(By.Id("password"));
        public IWebElement btnLogonUser => webDriver.FindElement(By.Id("btnLogOn"));
        public void ClickLogin()
        {
            btnLogin.Click();
        }

        public void EnterCredentials(String username, String password) {
           
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByID("username");
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            
        }


        public void ClickLoginButton() => btnLogonUser.Submit();
          
    }
}
