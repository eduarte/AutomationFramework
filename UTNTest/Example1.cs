using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestFixture]
    public class Utn
    {
        private IWebDriver browserDriver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private string geckoDriverPath = @"C:\geckodriver\";

        [SetUp]
        public void SetupTest()
        {
            Browser("chrome");
            baseURL = "http://utn.ac.cr/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                browserDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheUtnTest()
        {
            browserDriver.Navigate().GoToUrl(baseURL + "/");
            browserDriver.FindElement(By.XPath(".//a[text()='Sedes']")).Click();
            browserDriver.FindElement(By.XPath(".//a[text()='Sede Regional de San Carlos']")).Click();
            browserDriver.FindElement(By.XPath(".//nav/ul/li[2]/a[text()='Carreras']")).Click();
            browserDriver.FindElement(By.XPath(".//a[text()='Tecnologías Informáticas - Ingeniería del Software']")).Click();
            IWebElement careerHeader = browserDriver.FindElement(By.XPath("//h2[contains(@class, 'page-header')]"));
            Assert.IsTrue(careerHeader.Text.Contains("TECNOLOGÍAS INFORMÁTICAS - INGENIERÍA DEL SOFTWARE"));
        }

        private void Browser(string browserName) {
            if (browserName.ToLower().Contains("firefox"))
            {
                FirefoxDriverService firefoxService = FirefoxDriverService.CreateDefaultService(geckoDriverPath, "geckodriver.exe");
                firefoxService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                browserDriver = new FirefoxDriver(firefoxService);
            }
            else {
                if (browserName.ToLower().Contains("chrome"))
                {
                    browserDriver = new ChromeDriver(@"D:\Automation\Drivers");
                }
            }
            browserDriver.Manage().Window.Maximize();
            browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                browserDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                browserDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = browserDriver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
