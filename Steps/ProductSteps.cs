using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Specflow_Unleashed.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specflow_Unleashed.Steps
{
    [Binding]
    public class ProductSteps 
    {
        IWebDriver webDriver = new ChromeDriver();
        [Given(@"I login to Unleashed Software with below credentials")]
        public void GivenILoginToUnleashedSoftwareWithBelowCredentials(Table table)
        {
            //IWebDriver webDriver = new ChromeDriver();
            dynamic data = table.CreateDynamicInstance();
            webDriver.Navigate().GoToUrl("https://www.unleashedsoftware.com/");
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.ClickLogin();
            
            loginPage.EnterCredentials(data.Username, data.Password);
            loginPage.ClickLoginButton();
          
        }
        
        [When(@"I click Add Product")]
        public void WhenIClickAddProduct()
        {
            DashboardPage dashboard = new DashboardPage(webDriver);
            dashboard.ClickMenuInventory();
            dashboard.ClickSubmenuProducts();
            dashboard.ClickSubmenuAddProdcut();

        }
        
        
       
        [Then(@"An alert message appears with text")]
        public void ThenAnAlertMessageAppearsWithText(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            ProductPage productPage = new ProductPage(webDriver);
            productPage.checkMessageBoxText(data.Message);
            webDriver.Quit();

        }

       

        [When(@"I create the following product details")]
        public void WhenICreateTheFollowingProductDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            ProductPage productPage = new ProductPage(webDriver);
            productPage.AddProduct(data.ProductCode, data.ProductDescription);
            productPage.btnSave.Click();
        }

    }
}
