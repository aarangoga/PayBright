using OpenQA.Selenium;
using Shouldly;

namespace PayBrightTest.Pages
{
    public class PayBright_main : Common
    {
        private readonly string urlPayBrightPage = "https://paybright.com/en/";

        private readonly By mainPagePanel = By.Id("#top");

        private readonly By menuShopDirectory = By.XPath("//a[@href='/en/shop-directory']");



        #region Definition of actions

        public PayBright_main(IWebDriver driver) : base(driver)
        {
        }

        public void OpenPayBrightPage()
        {
            OpenPage(urlPayBrightPage);
        }

        public void WaitPayBrightPageIsLoaded()
        {
            IsElementVisible(mainPagePanel).ShouldBeTrue();
        }

        public void NavigateToMenuShopDirectory()
        {
            IsElementVisible(menuShopDirectory).ShouldBeTrue();
            ClickElement(menuShopDirectory);
            this.WaitPayBrightPageIsLoaded();

        }

        #endregion


    }
}
