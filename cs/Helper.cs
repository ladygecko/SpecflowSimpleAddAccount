using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specflow_Unleashed.Pages
{
    public class Helper
    {
        
        public IWebDriver webDriver { get; }
        public Helper(IWebDriver webDriver) {
            this.webDriver = webDriver;
           // TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
           // WebDriverWait wait = new WebDriverWait(webDriver, span);
           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='ng-binding' and contains(text(),'Dashboard')]")));

        }
        public void WaitForElementIsVisibleByXPath(String xpath) {
            TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
            WebDriverWait wait = new WebDriverWait(webDriver, span);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        public void WaitForElementIsVisibleByID(String id)
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
            WebDriverWait wait = new WebDriverWait(webDriver, span);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

    }
}
