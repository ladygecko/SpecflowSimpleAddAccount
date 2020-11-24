using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow_Unleashed.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver webDriver;
        private readonly Helper helper;

        public DashboardPage(ScenarioContext scenarioContext) {

            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
            helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByXPath("//*[@class='ng-binding' and contains(text(),'Dashboard')]");
            
        }

        public IWebElement mnuInventory => webDriver.FindElement(By.XPath("//*[@class='ng-binding' and contains(text(),'Inventory')]"));
        public IWebElement sbmProduct => webDriver.FindElement(By.XPath("//*[text()='Products' and @class='ng-binding']"));

        public IWebElement sbmAddProduct => webDriver.FindElement(By.XPath("//*[text()='Add Product' and @class='ng-binding']"));

        public IWebElement mnuSales => webDriver.FindElement(By.XPath("//*[@class='ng-binding' and contains(text(),'Sales')]"));
        public IWebElement sbmMnuOrders => webDriver.FindElement(By.XPath("//*[@class='ng-binding' and text()='Orders']//parent::*"));
        public IWebElement sbmMnuAddSalesOrder => webDriver.FindElement(By.XPath("//*[@class='ng-binding' and contains(text(),'Add Sales Order')]//parent::*"));
        public void ClickMenuInventory() => mnuInventory.Click();
      
        public void ClickSubmenuProducts() {
            
            helper.WaitForElementIsVisibleByXPath("//*[text()='Products' and @class='ng-binding']");
            sbmProduct.Click();
         }

        public void ClickSubmenuAddProdcut() {

            helper.WaitForElementIsVisibleByXPath("//*[text()='Add Product' and @class='ng-binding']");
            sbmAddProduct.Click(); 
        
        }

        public void ClickMenuSales() => mnuSales.Click();
        public void ClickSubmenuOrders()
        {

            helper.WaitForElementIsVisibleByXPath("//*[text()='Orders' and @class='ng-binding']//parent::*");
            sbmMnuOrders.Click();
        }

        public void ClickSubmenuAddSalesOrder()
        {
            helper.WaitForElementIsVisibleByXPath("//*[text()='Add Sales Order' and @class='ng-binding']//parent::*");
            sbmMnuAddSalesOrder.Click();
        }
        

    }
}
