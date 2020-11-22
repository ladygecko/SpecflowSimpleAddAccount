using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specflow_Unleashed.Pages
{
    public class ProductPage
    {
        
        public IWebDriver webDriver { get; }
        public ProductPage(IWebDriver webDriver) {
            this.webDriver = webDriver;
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByID("tabsDetailsLink");
          

        }

        public IWebElement txtProductCd => webDriver.FindElement(By.Id("Product_ProductCode"));
        public IWebElement txtProductDesc => webDriver.FindElement(By.Id("Product_ProductDescription"));

        public IWebElement btnSave => webDriver.FindElement(By.Id("btnSave"));

        public void AddProduct(String code, String desc) {
            txtProductCd.SendKeys(code);
            txtProductDesc.SendKeys(desc);
            
        }

        public void checkMessageBoxText(String message) {
        
            Helper helper = new Helper(webDriver);
            helper.WaitForElementIsVisibleByXPath("//*[@class='ui-pnotify-text ']");
            var xPathmessage = webDriver.FindElement(By.XPath("//*[@class='ui-pnotify-text ']")).Text;
            Assert.AreEqual("You have updated the product successfully.", xPathmessage);
        }

        

    }
}
