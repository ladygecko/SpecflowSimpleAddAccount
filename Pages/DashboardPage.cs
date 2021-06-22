using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
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
           // helper.WaitForElementIsVisibleByXPath("//*[@class='ng-binding' and contains(text(),'Dashboard')]");
            
        }
        
        public IWebElement mnuAccounting => webDriver.FindElement(By.XPath("//*[@data-name='navigation-menu/accounting']"));
        public IWebElement mnuBankAccounts => webDriver.FindElement(By.XPath("//*[@data-name='navigation-menu/accounting/bank-accounts']"));
      
      
      public void ClickSubmenuAccounting() {
            
            helper.WaitForElementIsVisibleByXPath("//*[@data-name='navigation-menu/accounting']");
            mnuAccounting.Click();
         }

        public void ClickSubmenuBankAccounts()
        {

            helper.WaitForElementIsVisibleByXPath("//*[@data-name='navigation-menu/accounting/bank-accounts']");
            mnuBankAccounts.Click();
        }
        

    }
}
