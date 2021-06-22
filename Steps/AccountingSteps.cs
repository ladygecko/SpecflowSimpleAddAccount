using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Specflow_Xero.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specflow_Xero.Steps
{
    [Binding]
    public class AccountingSteps 
    {
        
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver webDriver;


        public AccountingSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            webDriver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I login to Xero with below credentials")]
        public void GivenILoginToXeroWithCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            LoginPage loginPage = new LoginPage(this._scenarioContext);
            //loginPage.ClickLogin();

            loginPage.EnterCredentials(data.Username, data.Password);
            //loginPage.ClickLoginButton();

        }

        [When(@"I click Accounting from menu")]
        public void WhenIClickAccounting()
        {
            DashboardPage dashboard = new DashboardPage(this._scenarioContext);
            dashboard.ClickSubmenuAccounting();
            dashboard.ClickSubmenuBankAccounts();
            
        }

        [Then(@"I add new bank account")]
        public void WhenIAddNewBankAccount(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            BankAccountsPage bankAccountsPage = new BankAccountsPage(this._scenarioContext);
            bankAccountsPage.AddBankName(data);
        }





        [Then(@"An alert message appears with text")]
        public void ThenAnAlertMessageAppearsWithText(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            Helper helper = new Helper(webDriver);
            helper.checkMessageBoxText(data.Message);

        }


  

    }
}
