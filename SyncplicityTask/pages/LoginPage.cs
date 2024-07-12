using OpenQA.Selenium;

namespace SyncplicityTask.pages
{
    internal class LoginPage:BasePage
    {
       
        private By EmailLocator = By.Id("MainContent_login_UserName");
        private By NextButtonLocator = By.Id("MainContent_login_btnNext");
        private By PasswordLocator = By.Id("MainContent_login_txtPassword");
        private By LoginButtonLocator = By.Id("MainContent_login_btnLogin");
        private By ErrorMessageLocator = By.Id("SystemMessageContent_statusMessage");
        private By UserNameErrorLocator = By.Id("MainContent_login_UserName-error");

        public LoginPage(IWebDriver driver):base(driver)    
        {
           
        }

        public void EnterEmail(string email)
        {
          this.Wrapper.EnterValue(this.EmailLocator, email);
        }
        public void ClickNextButton()
        {
            this.Wrapper.ClickElement(this.NextButtonLocator);
        }
        public void EnterPassword(string password)
        {
            this.Wrapper.EnterValue(this.PasswordLocator, password);
        }
        public void ClickLoginButton()
        {
            this.Wrapper.ClickElement(this.LoginButtonLocator);
        }
        public Boolean IsUsernameErrorMessageVisible()
        {
            return this.Wrapper.IsElementVisible(UserNameErrorLocator);
        }
        public string GetUsernameErrorMessage()
        {
            return this.Wrapper.GetTextFromElement(UserNameErrorLocator);
        }
        public Boolean IsLoginErrorMessageVisible()
        {
            return this.Wrapper.IsElementVisible(UserNameErrorLocator);
        }
        public void QuickLogin(string userName, string password)
        {
            this.EnterEmail(userName);
            this.ClickNextButton();
            this.EnterPassword(password);
            this.ClickLoginButton();
        }
    }
}
