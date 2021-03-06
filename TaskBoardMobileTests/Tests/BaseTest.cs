using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace TaskBoardMobileTests.Tests
{
    public class BaseTest
    {
        private const string AppiumServerUri = "http://[::1]:4723/wd/hub";
        private const string AppPath = @"C:\taskboard-androidclient.apk";
        protected AndroidDriver<AndroidElement> driver;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", AppPath);
            driver = new AndroidDriver<AndroidElement>(
                new Uri(AppiumServerUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}