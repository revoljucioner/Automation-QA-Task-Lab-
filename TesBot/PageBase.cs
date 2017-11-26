using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TesBot
{
    abstract class PageBase
    {
        public IWebDriver driver { get; protected set; }

        public enum SortOrder
        {
            ASC,
            DESC
        }

        public enum Equality
        {
            Strict,
            Nostrict
        }

        public IWebElement FindUppercase()
        {
            return FindElementByXPath("//*[@class='uppercase']");
        }

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetAttributeValue(IWebElement element, string attribute, string value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", element, attribute, value);
        }

        public string SelectAll()
        {
            return (Keys.Control + "a");
        }

        public string Paste()
        {
            return (Keys.Control + "v");
        }

        public string Copy()
        {
            return (Keys.Control + "c");
        }

        public void ScrollIntoViewElemet(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public IWebElement FindElementByXPath(string text)
        {
            return driver.FindElement(By.XPath(text));
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.IWebElement> FindElementsByXPath(string text)
        {
            return driver.FindElements(By.XPath(text));
        }

        public void CompareAGreaterThanB(double a, double b, Equality equality)
        {
            if (equality == Equality.Nostrict)
            {
                if (a<b)
                {
                    throw new AssertFailedException();
                }
            }
            else if (equality == Equality.Strict)
            {
                if (a <= b)
                {
                    throw new AssertFailedException();
                }
            }
        }

        public void WaitVisibilityOfAllElementsLocatedByXPath(int time, string XPath)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XPath)));
        }    
    }
}
