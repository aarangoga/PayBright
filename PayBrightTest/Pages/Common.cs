using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.IO;

namespace PayBrightTest.Pages
{
    public class Common
    {

        private readonly IWebDriver _driver;


        public Common(IWebDriver driver)
        {
            _driver = driver;

        }

        protected void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);

            _driver.Manage().Window.Maximize();
        }

        protected bool IsElementVisible(By locator)
        {
            var isVisible = false;
            try
            {
                isVisible = WaitForElementUntilIsVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                isVisible = false;
            }
            catch (Exception e)
            {
                isVisible = false;
            }
            return isVisible;
        }

        protected IWebElement WaitForElementUntilIsVisible(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        protected IWebElement WaitForElementUntilIsClickable(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        protected void ClickElement(By locator)
        {
            WaitForElementUntilIsVisible(locator);

            _driver.FindElement(locator).Click();
        }

        protected void ClearFieldAndSentKeys(By locator, string text)
        {
            WaitForElementUntilIsVisible(locator);

            _driver.FindElement(locator).Click();

            _driver.FindElement(locator).SendKeys(Keys.Delete);

            _driver.FindElement(locator).SendKeys(text);

        }

        protected void WaitSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

    }

}
