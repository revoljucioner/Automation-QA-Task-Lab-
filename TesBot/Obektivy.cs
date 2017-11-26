using OpenQA.Selenium;

namespace TesBot
{
    class Obektivy : Products
    {
        public Obektivy(IWebDriver driver) : base(driver)
        {
        }

        public void ClickFullCader()
        {
            WaitVisibilityOfAllElementsLocatedByXPath(30, "//*[@data-filter-value='75704']");
            IWebElement FullCader = FindElementByXPath("//*[@data-filter-value='75704']");
            ScrollIntoViewElemet(FullCader);
            FullCader.Click();
        }
    }
}
