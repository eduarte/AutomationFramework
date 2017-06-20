using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UTNTest.Pages
{
    public class LoginPage
    {
        IWebDriver _browserDriver;

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "btn-signin")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.Id, Using = "user_remember_me")]
        public IWebElement rememberMeCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "user_remember_me")]
        public IWebElement createNewAccount { get; set; }

        [FindsBy(How = How.Id, Using = "notifications-error")]
        public IWebElement notificationError { get; set; }


        public LoginPage(IWebDriver browserDriver)
        {
            _browserDriver = browserDriver;
            PageFactory.InitElements(_browserDriver, this);
        }

        public SignUpPage createAccount() {
            createNewAccount.Click();
            return new SignUpPage(_browserDriver);
        }

        public HomaPage doLogin(string email, string password) {
            emailField.SendKeys(email);
            passwordField.SendKeys(password);
            signInButton.Click();

            return new HomaPage(_browserDriver);
        }

        
    }
}

