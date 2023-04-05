

using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using AppiumCalculatorTestsPOM.Pages;

namespace AppiumCalculatorTestsPOM.Tests
{
    public class BaseTest
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"E:\QA_Automation_Front-End\WindowsApplicationDriver\SummatorDesktopApp.exe";
        protected WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;

        [SetUp]
        public void Setup()
        {
            //Start Appium using the desktop Appium Server
            this.appiumOptions = new AppiumOptions() { PlatformName = "Windows" };
            appiumOptions.AddAdditionalCapability("app", appLocation);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
            

        }
        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }
    }

}
