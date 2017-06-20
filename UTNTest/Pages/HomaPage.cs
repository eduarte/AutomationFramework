using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UTNTest.Pages
{
    public class HomaPage
    {
        IWebDriver _browserDriver;
        [FindsBy(How = How.Id, Using = "my_account")]
        public IWebElement userName { get; set; }

        public HomaPage(IWebDriver browserDriver)
        {
            _browserDriver = browserDriver;
            PageFactory.InitElements(_browserDriver, this);
        }

        public string loggedUserName() {
            return userName.Text.Trim().ToString();
        }
    }
}
