using OpenQA.Selenium;
using Shouldly;

namespace PayBrightTest.Pages
{
    public class Google_results : Common
    {

        private readonly By resultsPanel = By.Id("res");


        private By CiteElement (string expectedUrl)
        {
            var el = By.XPath($"//div[@id='res']//cite[contains(text(),'{expectedUrl}')]");
            return el;
        }

        public Google_results(IWebDriver driver) : base(driver) {}    

        #region Definition of actions


        public void WaitGoogleResultsAreLoaded()
        {
            IsElementVisible(resultsPanel).ShouldBeTrue();
        }

        public void VerifyIfUrlIsPresentInResults(string expectedUrl, bool shouldBePresent)
        {
            var el = CiteElement(expectedUrl);
            if (shouldBePresent)
            {
                IsElementVisible(el).ShouldBeTrue();
            }
            else
            {
                IsElementVisible(el).ShouldBeFalse();
            }
            
        }

        public void ClickLinkPayBrightInGooglePage(string url)
        {
            var el = CiteElement(url);

            if (IsElementVisible(el))
            {
                ClickElement(el);
            }

        }

        #endregion

    }
}
