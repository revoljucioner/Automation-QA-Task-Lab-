using OpenQA.Selenium;

namespace TesBot
{
    class Google : PageBase
    {

        public Google(IWebDriver driver) : base(driver)
        {
        }

        public void TypeSearchInput(string url)
        {
            IWebElement SearchInput = FindElementByXPath("//input[@id='lst-ib']");
            SearchInput.SendKeys(url);
        }

        public IWebDriver FeelingLuckyClick()
        {
            FindElementByXPath("//input[@name='btnI']").Click();
            return driver;
        }

    }
}
