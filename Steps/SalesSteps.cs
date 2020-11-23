using NUnit.Framework;
using OpenQA.Selenium;
using Specflow_Unleashed.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specflow_Unleashed.Steps
{
    [Binding]
    public class SalesSteps

    {
        private AddSalesOrderPage addSalesOrderPage;
        private readonly IWebDriver webDriver;

        private readonly ScenarioContext _scenarioContext;
        public SalesSteps(ScenarioContext scenarioContext) {
            this._scenarioContext = scenarioContext;
            addSalesOrderPage = new AddSalesOrderPage(_scenarioContext);
            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [When(@"I click Sales -> Orders -> Add Sales Order")]
        public void WhenIClickSales_Orders_AddSalesOrder()
        {
            DashboardPage dashboardPage = new DashboardPage(_scenarioContext);
            dashboardPage.ClickMenuSales();
            dashboardPage.ClickSubmenuOrders();
            dashboardPage.ClickSubmenuAddSalesOrder();
            
        }
        
        [When(@"I create the sales order with the following details")]
        public void WhenICreateTheSalesOrderWithTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            addSalesOrderPage.AddOrder(data);
        }
        
        [When(@"I click Add button")]
        public void WhenIClickAddButton() => addSalesOrderPage.ClickAdd();


        [When(@"I click Complete button")]
        public void WhenIClickCompleteButton() => addSalesOrderPage.ClickComplete();
        

        [Then(@"The Stock on Hand of the product should display '(.*)'")]
        public void ThenTheStockOnHandOfTheProductShouldDisplay(int p0)
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"An alert message contains text")]
        public void ThenAnAlertMessageContainsText(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            Helper helper= new Helper(webDriver);
            helper.checkMessageBoxTextContains(data.Message);
        }

    }
}
