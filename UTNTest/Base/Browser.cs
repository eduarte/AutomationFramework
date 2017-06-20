using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace UTNTest.Base
{
    public  class Browser
    {
        private  IWebDriver _browserDriver;
        private  string geckoDriverPath = @"C:\geckodriver\";

        public IWebDriver getBrowser(string browserName)
        {
            if (browserName.ToLower().Contains("firefox"))
            {
                FirefoxBrowser();
            }
            else
            {
                ChromeBrowser();
            }
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            return _browserDriver;
        }

        private  void FirefoxBrowser() {
            FirefoxDriverService firefoxService = FirefoxDriverService.CreateDefaultService(geckoDriverPath, "geckodriver.exe");
            firefoxService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            _browserDriver = new FirefoxDriver(firefoxService);
        }

        private  void ChromeBrowser() {
            _browserDriver = new ChromeDriver(@"D:\Automation\Drivers");
        }



    }
}
