using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using AppiumCalculatorTestsPOM.Pages;

namespace AppiumCalculatorTestsPOM.Tests
{
    public class CalculatorPageTests : BaseTest

    {
        private CalculatorPage page;

        [SetUp]
        public void Setup()
        {
          
            this.page = new CalculatorPage(driver);
                               
        }
        [TearDown]
        public void CloseApp()
        {
          
            driver.Quit();
        }
        [Test]
        public void Test_CalculateTwoPositiveNumbers()
        {
            //var result = page.CalculateTwoNumbers("5", "10");
            Assert.That(page.CalculateTwoNumbers("5", "10"), Is.EqualTo("15"));
        }
    }
}