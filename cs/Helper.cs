using NUnit.Framework;
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

        public IWebDriver webDriver;
        public Helper(IWebDriver webDriver) {
            this.webDriver = webDriver;

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

        
        public void WebdriverWait(int milliS)  => System.Threading.Thread.Sleep(milliS);

        public void checkMessageBoxText(String message)
        {

            WaitForElementIsVisibleByXPath("//*[@class='ui-pnotify-text ']");
            var xPathmessage = webDriver.FindElement(By.XPath("//*[@class='ui-pnotify-text ']")).Text;
            Assert.AreEqual(message, xPathmessage);

        }

        public void checkMessageBoxTextContains(String message)
        {

            WaitForElementIsVisibleByXPath("//*[@class='ui-pnotify-text ']");
            var xPathmessage = webDriver.FindElement(By.XPath("//*[@class='ui-pnotify-text ']")).Text;
            Assert.True(xPathmessage.Contains(message));

        }


    }
}
