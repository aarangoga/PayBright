using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shouldly;
using System;

namespace PayBrightTest.Pages
{
    public class PayBright_shopDirectory : Common
    {
        private readonly By searchSectionPanel = By.XPath("//section[@id='#top']/div[1]");

        private readonly By dropdownSortBy = By.Id("mui-component-select-sort-by");


        private readonly By searchMerchantTextBox = By.Name("search");


        private By menuItemSortBy (string nameOption)
        {
            var el = By.XPath($"//div[@id='menu-sort-by']//li[@role='option' and text()='{nameOption}']");

            return el;
        }

        private By TextBrand(string brandName)
        {
            var el = By.XPath($"//section[@id='#top']/div[3]//p[text()='{brandName}']");

            return el;
        }


        public PayBright_shopDirectory(IWebDriver driver) : base(driver) {}

     
        #region Definition of actions

        public void VerifyShopDirectoryIsLoaded()
        {
            IsElementVisible(searchSectionPanel).ShouldBeTrue();
            IsElementVisible(dropdownSortBy).ShouldBeTrue();
            IsElementVisible(searchMerchantTextBox).ShouldBeTrue();

        }

        public void SelectItemSortBy_ByName(string optionName)
        {
            WaitForElementUntilIsClickable(dropdownSortBy).Click();
            var el = menuItemSortBy(optionName);
            WaitForElementUntilIsClickable(el).Click();
        }
           

        public void InputTextMerchantSearch(string text)
        {
            ClearFieldAndSentKeys(searchMerchantTextBox, text);
            WaitSeconds(2);

        }

        public void VerifyIfBrandIsDisplayedInResultsPanel(string brandName)
        {
            var el = TextBrand(brandName);
            WaitForElementUntilIsVisible(el);
            IsElementVisible(el).ShouldBeTrue();

        }

        #endregion


    }


}
