using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTNTest.Pages

{
    public class SignUpPage
    {
        private IWebDriver _browserDriver;
        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.Id, Using = "btn-signin")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.Id, Using = "user_remember_me")]
        public IWebElement rememberMeCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "user_remember_me")]
        public IWebElement createNewAccount { get; set; }

        public SignUpPage(IWebDriver browserDriver)
        {
            _browserDriver = browserDriver;
            PageFactory.InitElements(_browserDriver, this);
        }



    }
}
