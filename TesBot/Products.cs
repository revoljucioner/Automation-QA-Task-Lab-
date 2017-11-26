using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace TesBot
{
    abstract class Products : HotlineBase
    {
        public Products(IWebDriver driver) : base(driver)
        {
        }

        public void SortProductslistByPrice(SortOrder sortOrder)
        {
            IWebElement SortDropList = FindElementByXPath("//*[@data-tracking-id='sort-1']");
            SortDropList.Click();
            IWebElement SortByPriceButton;
            if (sortOrder == SortOrder.ASC)
            {
                SortByPriceButton = FindElementByXPath("/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div[1]/div/div[3]/ul/li[1]/select/option[1]");
            }
            else
            {
                SortByPriceButton = FindElementByXPath("/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div[1]/div/div[3]/ul/li[1]/select/option[2]");
            }

            SortByPriceButton.Click();
        }

        public List<double> ListOfPrice()
        {
            var ArrayOfPrice = FindElementsByXPath("//*[@class='price-md']");

            List<double> prices = new List<double>();

            Regex regexCurrency = new Regex(@".грн");

            foreach (var el in ArrayOfPrice)
            {
                if (el.Displayed == true)
                {
                    var price = Convert.ToDouble(Regex.Replace(el.Text, regexCurrency.ToString(), ""));
                    prices.Add(price);
                }
            }

            return prices;
            List<double> pricesCopy = new List<double>(prices);
        }

        public List<double> SortList(List<double> list, SortOrder sortOrder)
        {
            list.Sort();

            if (sortOrder == SortOrder.DESC)
            {
                list.Reverse();
            }

            return list;
        }

        public void TypeMinPrice(double minPrice)
        {
            WaitVisibilityOfAllElementsLocatedByXPath(30, "//input[@data-price-min]");
            //new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//input[@data-price-min]")));

            IWebElement MinPriceField = FindElementByXPath("//input[@data-price-min]");
            ScrollIntoViewElemet(MinPriceField);

            MinPriceField.Click();
            MinPriceField.SendKeys(SelectAll());

            MinPriceField.SendKeys(Convert.ToString(minPrice));
        }

        public void TypeMaxPrice(double maxPrice)
        {
            WaitVisibilityOfAllElementsLocatedByXPath(30, "//input[@data-price-max]");
            //new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//input[@data-price-max]")));

            IWebElement MaxPriceField = FindElementByXPath("//input[@data-price-max]");
            ScrollIntoViewElemet(MaxPriceField);

            MaxPriceField.Click();
            MaxPriceField.SendKeys(SelectAll());


            MaxPriceField.SendKeys(Convert.ToString(maxPrice));
        }

        public void ClickPriceFilterSubmit()
        {
            IWebElement PriceFilterOk = FindElementByXPath("//input[@data-price-submit]");
            ScrollIntoViewElemet(PriceFilterOk);

            PriceFilterOk.Click();
        }

        public double GetMinPrice()
        {
            SortProductslistByPrice(SortOrder.ASC);
            return ListOfPrice()[0];
        }

        public double GetMaxPrice()
        {
            SortProductslistByPrice(SortOrder.DESC);
            return ListOfPrice()[0];
        }
    }
}
