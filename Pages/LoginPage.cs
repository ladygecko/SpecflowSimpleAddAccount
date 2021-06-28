using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Specflow_Xero.Pages
{
    public class LoginPage
    {

        private readonly IWebDriver webDriver;

        
        public LoginPage(ScenarioContext scenarioContext) {
           webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
           
        }

        private IWebElement btnLogin => webDriver.FindElement(By.XPath("//*[@data-automationid='LoginSubmit--button']"));
        private IWebElement txtUsername => webDriver.FindElement(By.Name("Username"));
        private IWebElement txtPassword => webDriver.FindElement(By.Name("Password"));
      

        public void EnterCredentials(string username, string password) {
           
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByName("Username");
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Click();
            
        }


        
          
    }
}
