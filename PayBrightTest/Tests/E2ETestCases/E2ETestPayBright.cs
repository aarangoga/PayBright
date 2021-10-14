using PayBrightTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PayBrightTest.Tests
{
    [TestFixture]
    public class E2ETestPayBright
    {

        private readonly IWebDriver _driver;

        private readonly Google_main _google_mainPage;

        private readonly Google_results _google_resultsPage;

        private readonly PayBright_main _payBright_mainPage;

        private readonly PayBright_shopDirectory _payBright_shopDirectoryPage;


        public E2ETestPayBright()
        {
            _driver = new ChromeDriver();

            _google_mainPage = new Google_main(_driver);

            _google_resultsPage = new Google_results(_driver);

            _payBright_mainPage = new PayBright_main(_driver);

            _payBright_shopDirectoryPage = new PayBright_shopDirectory(_driver);
        }

        [SetUp]
        public void OneTimeSetUp()
        {
            _google_mainPage.OpenGooglePage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        [Test]
        [Description("This is the E2E test case")]
        public void PayBrightE2ETestCase()
        {
            _google_mainPage.WaitGoogleMainPageIsLoaded();
            _google_mainPage.InputTextAndClickInGoogleSearch("PayBright");
            _google_resultsPage.WaitGoogleResultsAreLoaded();
            _google_resultsPage.VerifyIfUrlIsPresentInResults("paybright.com", true);
            _google_resultsPage.ClickLinkPayBrightInGooglePage("paybright.com");
            _payBright_mainPage.WaitPayBrightPageIsLoaded();
            _payBright_shopDirectoryPage.VerifyShopDirectoryIsLoaded();
            _payBright_shopDirectoryPage.SelectItemSortBy_ByName("Popular");
            _payBright_shopDirectoryPage.InputTextMerchantSearch("Samsung");
            _payBright_shopDirectoryPage.VerifyIfBrandIsDisplayedInResultsPanel("Samsung");

        }

    }
}
