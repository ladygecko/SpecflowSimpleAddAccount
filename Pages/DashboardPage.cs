using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Specflow_Xero.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver webDriver;
        private readonly Helper helper;

        public DashboardPage(ScenarioContext scenarioContext) {

            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
            helper = new Helper(webDriver);
           
        }

        private IWebElement mnuElement (String text) {
            return webDriver.FindElement(By.XPath("//*[@data-name='navigation-menu/" + text.ToLower() + "']"));
        }
        private IWebElement mnuBankAccounts => webDriver.FindElement(By.XPath("//*[@data-name='navigation-menu/accounting/bank-accounts']"));
        
      

        public void ClickSubmenu(String text)
        {

            helper.WaitForElementIsVisibleByXPath("//*[@data-name='navigation-menu/" + text.ToLower() + "']");
            mnuElement(text).Click();
        }
        

        public void ClickAccountingBankAccountSubmenu() { 

            helper.WaitForElementIsVisibleByXPath("//*[@data-name='navigation-menu/accounting/bank-accounts']");
            mnuBankAccounts.Click();
        }
        

    }
}
