using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow_Unleashed.Pages
{
    public class AddSalesOrderPage
    {
      
        private readonly IWebDriver webDriver;

        public AddSalesOrderPage(ScenarioContext scenarioContext) {
            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
        
        }

        public IWebElement txtCustCd => webDriver.FindElement(By.XPath("//*[@name='Customer.CustomerCode' and @type='text']"));
        public IWebElement txtProductAddLine => webDriver.FindElement(By.Id("ProductAddLine"));
        public IWebElement txtProductAddQty => webDriver.FindElement(By.Id("QtyAddLine"));
        public IWebElement txtCommentsAddLine => webDriver.FindElement(By.Id("CommentsAddLine"));
        public IWebElement btnAddOrderLine => webDriver.FindElement(By.Id("btnAddOrderLine"));
        public IWebElement btnComplete => webDriver.FindElement(By.Id("btnComplete"));
        public IWebElement customerSearchButton => webDriver.FindElement(By.Id("CustomerSearchButton"));
        public IWebElement customerSearchCode => webDriver.FindElement(By.Id("CustomerSearchCode"));
        public IWebElement runCustomerSearch => webDriver.FindElement(By.Id("RunCustomerSearch"));
        public IWebElement selectedCust(string custCode) => webDriver.FindElement(By.XPath("//*[@href='#' and contains(text(),'" + custCode + "')]"));
        public IWebElement confirmYes => webDriver.FindElement(By.Id("generic-confirm-modal-yes"));
        public IWebElement prdLink(string item) =>
            webDriver.FindElement(By.XPath("//*[@class='product-link ng-binding' and text()='" + item + "']"));



        public void AddOrder(dynamic data) {
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByXPath("//*[@name='Customer.CustomerCode' and @type='text']");
            customerSearchButton.Click();
            helper.WebdriverWait(1000);
            customerSearchCode.SendKeys(data.CustomerCode);
            runCustomerSearch.Click();
            var elemSelectedCust=selectedCust(data.CustomerCode);
            elemSelectedCust.Click();
            helper.WebdriverWait(1000);
            txtProductAddLine.SendKeys(data.Product);
            txtProductAddLine.SendKeys(Keys.Tab);
            helper.WebdriverWait(1000);
            String qty = (data.Quantity).ToString();
            txtProductAddQty.SendKeys(qty);
            txtProductAddQty.SendKeys(Keys.Tab);
            helper.WebdriverWait(1000);
            txtCommentsAddLine.SendKeys(data.Comments);
            txtCommentsAddLine.SendKeys(Keys.Tab);
            helper.WebdriverWait(1000);

        }
        
        public void ClickAdd() => btnAddOrderLine.Click();
        public void ClickComplete() {
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByID("btnComplete");
            btnComplete.Click();
            helper.WaitForElementIsVisibleByID("generic-confirm-modal-yes");
            confirmYes.Click();
            helper.WebdriverWait(1000);
         
        }

        public void ClickPrdLink(string item)
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
            WebDriverWait wait = new WebDriverWait(webDriver, span);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='product-link ng-binding' and text()='" + item + "']")));
            prdLink(item).Click();
        }


    }
}
