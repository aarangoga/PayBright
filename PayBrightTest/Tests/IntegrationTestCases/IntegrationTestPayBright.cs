using PayBrightTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PayBrightTest.Tests.IntegrationTestCases
{
    public class IntegrationTestPayBright
    {
        private readonly IWebDriver _driver;

        private readonly PayBright_main _payBright_mainPage;

        private readonly PayBright_shopDirectory _payBright_shopDirectoryPage;



        public IntegrationTestPayBright()
        {
            _driver = new ChromeDriver();

            _payBright_mainPage = new PayBright_main(_driver);

            _payBright_shopDirectoryPage = new PayBright_shopDirectory(_driver);

        }

        [SetUp]
        public void OneTimeSetUp()
        {
            _payBright_mainPage.OpenPayBrightPage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void OpenPayBrightPage_MainPageShouldBeDisplayed()
        {
            _payBright_mainPage.WaitPayBrightPageIsLoaded();
        }

        [Test]
        public void NavigateToMenuShopDirectory_PageMenuShopDirectorShouldBeDisplayed()
        {
            _payBright_mainPage.WaitPayBrightPageIsLoaded();
            _payBright_mainPage.NavigateToMenuShopDirectory();
            _payBright_shopDirectoryPage.VerifyShopDirectoryIsLoaded();
            
        }

        [Test]
        public void SearchSamsung_OnlyResultSamsungShouldBeDisplayed()
        {
            _payBright_mainPage.WaitPayBrightPageIsLoaded();
            _payBright_shopDirectoryPage.VerifyShopDirectoryIsLoaded();
            _payBright_shopDirectoryPage.SelectItemSortBy_ByName("New");
            _payBright_shopDirectoryPage.InputTextMerchantSearch("Samsung");
            _payBright_shopDirectoryPage.VerifyIfBrandIsDisplayedInResultsPanel("Samsung");

        }


    }
}