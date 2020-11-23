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
        
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver webDriver;


        public ProductSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I login to Unleashed Software with below credentials")]
        public void GivenILoginToUnleashedSoftwareWithBelowCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            LoginPage loginPage = new LoginPage(this._scenarioContext);
            loginPage.ClickLogin();
            
            loginPage.EnterCredentials(data.Username, data.Password);
            loginPage.ClickLoginButton();
          
        }
        

        [When(@"I click Inventory -> Products -> Add Product")]
        public void WhenIClickInventory_Products_AddProduct()
        {
            DashboardPage dashboard = new DashboardPage(this._scenarioContext);
            dashboard.ClickMenuInventory();
            dashboard.ClickSubmenuProducts();
            dashboard.ClickSubmenuAddProdcut();
        }



        [Then(@"An alert message appears with text")]
        public void ThenAnAlertMessageAppearsWithText(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            Helper helper = new Helper(webDriver);
            helper.checkMessageBoxText(data.Message);

        }

       

        [When(@"I create the following product details")]
        public void WhenICreateTheFollowingProductDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            ProductPage productPage = new ProductPage(this._scenarioContext);
            productPage.AddProduct(data.ProductCode, data.ProductDescription);
            productPage.btnSave.Click();
        }

    }
}
