using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specflow_Xero.Pages
{
    public class Helper
    {

        public IWebDriver webDriver;
        public Helper(IWebDriver webDriver) {
            this.webDriver = webDriver;

        }
        public void WaitForElementIsVisibleByXPath(String xpath) {
            TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
            WebDriverWait wait = new WebDriverWait(webDriver, span);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        public void WaitForElementIsVisibleByID(String id)
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
            WebDriverWait wait = new WebDriverWait(webDriver, span);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public void WaitForElementIsVisibleByName(String name)
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 30, 0);
            WebDriverWait wait = new WebDriverWait(webDriver, span);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(name)));
        }


        public void WebdriverWait(int milliS)  => System.Threading.Thread.Sleep(milliS);



    }
}
