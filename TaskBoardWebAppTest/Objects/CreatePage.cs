using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardWebAppTest.Objects
{
    public class CreatePage : BasePage
    {
        public CreatePage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://taskboard-1.stykst.repl.co/tasks/create";

        public IWebElement TextBoxTitle =>
            driver.FindElement(By.Id("title"));
        public IWebElement TextBoxDescription =>
            driver.FindElement(By.Id("description"));
        public IWebElement ButtonCreate =>
            driver.FindElement(By.Id("create"));
        public IWebElement ElementErrorMessage =>
            driver.FindElement(By.CssSelector("body > main > div"));

        public void CreateTask(string title, string description)
        {
            TextBoxTitle.Clear();
            TextBoxTitle.SendKeys(title);
            TextBoxDescription.Clear();
            TextBoxDescription.SendKeys(description);
            ButtonCreate.Click();
        }
    }
}
