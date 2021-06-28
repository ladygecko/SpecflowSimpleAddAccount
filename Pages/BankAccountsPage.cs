using OpenQA.Selenium;
using System;
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
        private IWebElement btnAddBankAccount => webDriver.FindElement(By.XPath("//*[@data-automationid='Add Bank Account-button']"));
        private IWebElement txtBankSearch => webDriver.FindElement(By.XPath("//*[@name='xui-searchfield-1018-inputEl']"));

        private IWebElement txtAcctName => webDriver.FindElement(By.XPath("//*[@id='accountname-1037-inputEl']"));
        private IWebElement txtAcctType => webDriver.FindElement(By.XPath("//*[@id='accounttype-1039-inputEl']"));

        private IWebElement pickerAcctType => webDriver.FindElement(By.XPath("//*[@id='accounttype-1039-trigger-picker']"));
        private IWebElement txtAcctNumber => webDriver.FindElement(By.XPath("//*[@id='accountnumber-1068-inputEl']"));
        private IWebElement btnContinue => webDriver.FindElement(By.XPath("//*[@id='common-button-submit-1015-btnInnerEl']"));
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
