using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardWebAppTest.Objects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual string PageUrl { get; }

        public IWebElement LinkHome => driver
            .FindElement(By.XPath("//a[contains(.,'Home')]"));
        public IWebElement LinkTaskBoard => driver
            .FindElement(By.XPath("(//a[@href='/boards'])[1]"));
        public IWebElement LinkCreate => driver
            .FindElement(By.XPath("//a[contains(.,'Create')]"));
        public IWebElement LinkSearch => driver
            .FindElement(By.XPath("(//a[contains(.,'Search')])[1]"));
        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
