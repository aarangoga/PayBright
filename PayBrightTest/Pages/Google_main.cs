using OpenQA.Selenium;
using Shouldly;

namespace PayBrightTest.Pages
{
    public class Google_main : Common
    {
        private readonly string urlGooglePage = "https://www.google.ca/";

        private readonly By searchTextBox = By.Name("q");

        private readonly By searchButton = By.Name("btnK");


        public Google_main(IWebDriver driver) : base(driver)
        {
        }
   

        #region Definition of Actions
        public void OpenGooglePage()
        {          
            OpenPage(urlGooglePage);
        }

        public void WaitGoogleMainPageIsLoaded()
        {
            IsElementVisible(searchTextBox).ShouldBeTrue();
        }

        public void InputTextAndClickInGoogleSearch(string textToSearch)
        {
            ClearFieldAndSentKeys(searchTextBox, textToSearch);
            ClickElement(searchButton);
        }
        #endregion


    }
}
