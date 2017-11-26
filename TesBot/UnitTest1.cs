using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TesBot
{
    [TestClass]
    public class UnitTest1
    {
        string UrlHotline = "http://hotline.ua/";
        string ProjectPath = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
        IWebDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver();

        [OneTimeSetUp] 
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
        }

        [OneTimeTearDown] 
        public void OneTimeTearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        [SetUp] 
        public void SetUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown] 
        public void TearDown()
        {

        }

        [Test]
        public void TEST_1()
        {
            driver.Navigate().GoToUrl("https://google.com.ua");
            Google pageGoogle = new Google(driver);
            pageGoogle.TypeSearchInput(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(pageGoogle.FeelingLuckyClick());

            NUnit.Framework.Assert.AreEqual(pageHotlineMain.driver.Url, UrlHotline);
        }

        [Test]
        public void TEST_2_ru()
        {
            driver.Navigate().GoToUrl(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(driver);
            pageHotlineMain.ChangeLanguage(HotlineBase.Languages.ru);

            NUnit.Framework.Assert.AreEqual(pageHotlineMain.FindUppercase().Text, "КАТАЛОГ ТОВАРОВ");
        }

        [Test]
        public void TEST_2_uk()
        {
            driver.Navigate().GoToUrl(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(driver);
            pageHotlineMain.ChangeLanguage(HotlineBase.Languages.uk);

            NUnit.Framework.Assert.AreEqual(pageHotlineMain.FindUppercase().Text, "КАТАЛОГ ТОВАРІВ");
        }

        [Test]
        public void TEST_3()
        {
            driver.Navigate().GoToUrl(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(driver);
            Obektivy pageHotlineObektivy = pageHotlineMain.SelectObektivySubCategory();

            NUnit.Framework.Assert.AreEqual(pageHotlineObektivy.driver.Url, "http://hotline.ua/av/obektivy/");
        }

        [Test]
        public void TEST_4()
        {
            double MinPrice = 0;
            double MaxPrice = 10000;
            driver.Navigate().GoToUrl(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(driver);
            Obektivy pageHotlineObektivy = pageHotlineMain.SelectObektivySubCategory();

            pageHotlineObektivy.SortProductslistByPrice(PageBase.SortOrder.ASC);
            pageHotlineObektivy.ClickFullCader();
            pageHotlineObektivy.TypeMinPrice(MinPrice);
            pageHotlineObektivy.TypeMaxPrice(MaxPrice);
            pageHotlineObektivy.ClickPriceFilterSubmit();

            pageHotlineObektivy.CompareAGreaterThanB(pageHotlineObektivy.GetMinPrice(),MinPrice, PageBase.Equality.Nostrict);
            pageHotlineObektivy.CompareAGreaterThanB(MaxPrice, pageHotlineObektivy.GetMaxPrice(), PageBase.Equality.Nostrict);
        }

        [Test]
        public void TEST_5_ASC()
        {
            driver.Navigate().GoToUrl(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(driver);
            Snoubordy pageHotlineSnoubordy = pageHotlineMain.SelectSnoubordySubCategory();
            pageHotlineSnoubordy.SortProductslistByPrice(PageBase.SortOrder.ASC);
            var ListOfPrice = pageHotlineSnoubordy.ListOfPrice();

            NUnit.Framework.Assert.AreEqual(ListOfPrice, pageHotlineSnoubordy.SortList(ListOfPrice, PageBase.SortOrder.ASC));
        }

        [Test]
        public void TEST_5_DESC()
        {
            driver.Navigate().GoToUrl(UrlHotline);
            HotlineMain pageHotlineMain = new HotlineMain(driver);
            Snoubordy pageHotlineSnoubordy = pageHotlineMain.SelectSnoubordySubCategory();
            pageHotlineSnoubordy.SortProductslistByPrice(PageBase.SortOrder.DESC);
            var ListOfPrice = pageHotlineSnoubordy.ListOfPrice();

            NUnit.Framework.Assert.AreEqual(ListOfPrice, pageHotlineSnoubordy.SortList(ListOfPrice, PageBase.SortOrder.DESC));
        }
    }
}