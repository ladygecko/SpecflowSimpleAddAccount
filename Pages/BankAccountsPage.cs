using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace Specflow_Xero.Pages
{
    public class BankAccountsPage
    {

        private readonly IWebDriver webDriver;
        private readonly Helper helper;

        public BankAccountsPage(ScenarioContext scenarioContext) {
            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
            helper = new Helper(webDriver);

        }
        public IWebElement btnAddBankAccount => webDriver.FindElement(By.XPath("//*[@data-automationid='Add Bank Account-button']"));
        public IWebElement txtBankSearch => webDriver.FindElement(By.XPath("//*[@name='xui-searchfield-1018-inputEl']"));

        public IWebElement txtDatarecord(String name) {
            return webDriver.FindElement(By.XPath("//*[@data-boundview='dataview-1021' and text()='"+ name +"']"));
            }

        public IWebElement txtAcctName => webDriver.FindElement(By.XPath("//*[@id='accountname-1037-inputEl']"));
        public IWebElement txtAcctType => webDriver.FindElement(By.XPath("//*[@id='accounttype-1039-inputEl']"));

        public IWebElement pickerAcctType => webDriver.FindElement(By.XPath("//*[@id='accounttype-1039-trigger-picker']"));
        public IWebElement txtAcctNumber => webDriver.FindElement(By.XPath("//*[@id='accountnumber-1068-inputEl']"));
        public IWebElement btnContinue => webDriver.FindElement(By.XPath("//*[@id='common-button-submit-1015-btnInnerEl']"));
        public void AddBankName(dynamic data) {
            btnAddBankAccount.Click();
            
            var bankUL = webDriver.FindElement(By.XPath("//*[@componentid='dataview-1021']"));
            var elements = bankUL.FindElements(By.TagName("li"));
            foreach (IWebElement li in elements)
            {
                if (li.Text.Equals(data.BankName))
                {
                    li.Click();
                    break;
                }
            }

            helper.WaitForElementIsVisibleByXPath("//*[@id='accountname-1037-inputEl']");
            txtAcctName.SendKeys(data.AccountName);
            pickerAcctType.Click();
            txtAcctType.SendKeys(Keys.Enter);
            String acctNo = Convert.ToString(data.AccountNumber);
            txtAcctNumber.SendKeys(acctNo);
            btnContinue.Click();
              
        }


    }
}
