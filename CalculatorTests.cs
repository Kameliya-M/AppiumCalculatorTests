using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumCalculatorTests
{
    public class CalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"E:\QA_Automation_Front-End\WindowsApplicationDriver\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private AppiumLocalService appiumLocalService;

        [OneTimeSetUp]
        public void OpenApplication()
        {
            //Start Appium using the desktop Appium Server
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            //appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            // Start Appium using headless mode
            //this.appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //appiumLocalService.Start();
            //this.appiumOptions = new AppiumOptions();
            //appiumOptions.AddAdditionalCapability("app", appLocation);
            //appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            //this.driver = new WindowsDriver<WindowsElement>(appiumLocalService, appiumOptions);

        }
        [OneTimeTearDown]
        public void CloseApplication()
        {
            driver.Quit();
        }


        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            //Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            //Act
            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys("5");
            secondField.SendKeys("15");
            calcButton.Click();
            //Assert
            Assert.That(resultField.Text, Is.EqualTo("20"));
        }

        [Test]
        public void Test_Sum_InvalidNumbers()
        {
            //Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            //Act
            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys("15");
            secondField.SendKeys("alabala");
            calcButton.Click();
            //Assert
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }
        [TestCase("5", "15", "20")]
        [TestCase("15", "15", "30")]
        [TestCase("5", "alabala", "error")]
        public void Test_Sum_Numbers(string firstValue, string secondValue, string result)
        {
            //Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            //Act
            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcButton.Click();
            //Assert
            Assert.That(resultField.Text, Is.EqualTo(result));
        }
    }
}