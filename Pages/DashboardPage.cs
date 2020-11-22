using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specflow_Unleashed.Pages
{
    public class DashboardPage
    {
        
        public IWebDriver webDriver { get; }
        public DashboardPage(IWebDriver webDriver) {
            this.webDriver = webDriver;
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByXPath("//*[@class='ng-binding' and contains(text(),'Dashboard')]");
            

        }

        public IWebElement mnuInventory => webDriver.FindElement(By.XPath("//*[@class='ng-binding' and contains(text(),'Inventory')]"));
        public IWebElement sbmProduct => webDriver.FindElement(By.XPath("//*[text()='Products' and @class='ng-binding']"));

        public IWebElement sbmAddProduct => webDriver.FindElement(By.XPath("//*[text()='Add Product' and @class='ng-binding']"));

        public void ClickMenuInventory() => mnuInventory.Click();
        public void ClickSubmenuProducts() {
            Helper helper = new Helper(webDriver);
            
            helper.WaitForElementIsVisibleByXPath("//*[text()='Products' and @class='ng-binding']");
            sbmProduct.Click();
         }

        public void ClickSubmenuAddProdcut() {

           
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByXPath("//*[text()='Add Product' and @class='ng-binding']");
            sbmAddProduct.Click(); 
        
        }



          
    }
}
