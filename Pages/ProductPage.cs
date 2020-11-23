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
    public class ProductPage
    {

        private readonly IWebDriver webDriver;

        public ProductPage(ScenarioContext scenarioContext) {
            
            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
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

        

        

    }
}
