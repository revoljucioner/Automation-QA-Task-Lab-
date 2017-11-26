using OpenQA.Selenium;

namespace TesBot
{
    abstract class HotlineBase : PageBase
    {
        public enum Languages
        {
            ru,
            uk
        }

        public IWebElement SearchBlock
        {
            get
            {
                return driver.FindElement(By.Id("searchbox")); ;
            }
        }

        public HotlineBase(IWebDriver driver) : base(driver)
        {
        }

        public void ChangeLanguage(Languages language)
        {
            IWebElement ChangeLanguageButton;

            if (language == Languages.ru)
            {
                 ChangeLanguageButton = FindElementByXPath("//*[@data-language='ru']");
            }
            else 
            {
                 ChangeLanguageButton = FindElementByXPath("//*[@data-language='uk']");
            }

            ChangeLanguageButton.Click();
        }

        public void TypeSearch(string text)
        {
            SearchBlock.SendKeys(text);
        }
    }
}


