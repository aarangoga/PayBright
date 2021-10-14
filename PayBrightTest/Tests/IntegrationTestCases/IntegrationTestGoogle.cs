using PayBrightTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PayBrightTest.Tests.IntegrationTestCases
{
    public class IntegrationTestGoogle
    {
        private readonly IWebDriver _driver;

        private readonly Google_main _google_mainPage;

        private readonly Google_results _google_resultsPage;


        public IntegrationTestGoogle()
        {
            _driver = new ChromeDriver();

            _google_mainPage = new Google_main(_driver);

            _google_resultsPage = new Google_results(_driver);
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
        public void OpenGooglePage_PageShouldBeDisplayed()
        {
            _google_mainPage.WaitGoogleMainPageIsLoaded();
        }

        [Test]
        public void SearchWordPayBright_ResultsShouldBeDisplayed()
        {
            _google_mainPage.WaitGoogleMainPageIsLoaded();
            _google_mainPage.InputTextAndClickInGoogleSearch("PayBright");
            _google_resultsPage.WaitGoogleResultsAreLoaded();
            _google_resultsPage.VerifyIfUrlIsPresentInResults("paybright.com", true);

        }
    }
}
