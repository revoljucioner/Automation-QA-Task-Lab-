using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TesBot
{
    class HotlineMain : HotlineBase
    {
        public HotlineMain(IWebDriver driver) : base(driver)
        {
        }

        public Obektivy SelectObektivySubCategory()
        {
            SelectFotoapparatyObektivyCategory();
            WaitVisibilityOfAllElementsLocatedByXPath(30, "//*[@class='obektivy']");

            IWebElement ObektivySubCategory = FindElementByXPath("//*[@class='obektivy']");
            ObektivySubCategory.Click();
            return new Obektivy(driver);
        }

        public void SelectFotoapparatyObektivyCategory()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(FindElementByXPath("/html/body/div[1]/div[1]/div[2]/aside/nav/ul/li[17]/a")).Build().Perform();

            WaitVisibilityOfAllElementsLocatedByXPath(30, "//*[@class='fotoapparaty-obektivy-price']");

            IWebElement FotoapparatyObektivyCategory = FindElementByXPath("//*[@class='fotoapparaty-obektivy-price']");
            FotoapparatyObektivyCategory.Click();
        }


        public Snoubordy SelectSnoubordySubCategory()
        {
            SelectLyzhiKonkiCategory();

            WaitVisibilityOfAllElementsLocatedByXPath(30, "//*[@class='snoubordy']");
            
            IWebElement SnoubordySubCategory = FindElementByXPath("//*[@class='snoubordy']");
            SnoubordySubCategory.Click();
            return new Snoubordy(driver);
        }

        public void SelectLyzhiKonkiCategory()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(FindElementByXPath("/html/body/div[1]/div[1]/div[2]/aside/nav/ul/li[16]/a")).Build().Perform();

            WaitVisibilityOfAllElementsLocatedByXPath(30, "//*[@class='lyzhi-konki-price']");
            
            IWebElement LyzhiKonkiCategory = FindElementByXPath("//*[@class='lyzhi-konki-price']");
            LyzhiKonkiCategory.Click();
        }
    }
}
