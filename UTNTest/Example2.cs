using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using UTNTest.Base;
using UTNTest.Pages;

namespace SeleniumTests
{
    [TestFixture]
    public class Example2
    {
        private string baseURL;

        private LoginPage loginPage;
        private SignUpPage signUpPage;
        private HomaPage homePage;
        private IWebDriver browserDriver;
        private Browser browser;

        [SetUp]
        public void SetupTest()
        {
            browser = new Browser();
            browserDriver = browser.getBrowser("chrome");
            browserDriver.Navigate().GoToUrl("https://courses.ultimateqa.com/users/sign_in");
            loginPage = new LoginPage(browserDriver);
        }
        
        [Test]
        public void invalidLogin()
        {
            loginPage.doLogin("email@email.com", "password");
            Assert.IsTrue(loginPage.notificationError.Text.Contains("Invalid email or password."));
        }

        [Test]
        public void validLogin()
        {
            homePage = loginPage.doLogin("autoF@autof.com", "autof123");
            Assert.IsTrue(homePage.loggedUserName().Contains("Auto F"));
        }

        [TearDown]
        public void TeardownTest()
        {
            browserDriver.Quit();
        }


    }
}
