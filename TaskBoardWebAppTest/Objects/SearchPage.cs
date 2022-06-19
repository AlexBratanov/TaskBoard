using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardWebAppTest.Objects
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://taskboard-1.stykst.repl.co/tasks/search";

        public IWebElement TextBoxKeyword =>
            driver.FindElement(By.Id("keyword"));
        public IWebElement ButtonSearch =>
            driver.FindElement(By.Id("search"));
        public IReadOnlyCollection<IWebElement> ListOfTasks => driver
            .FindElements(By.CssSelector("#task2 > tbody > tr > td"));
        public IWebElement ElementTaskMatchingKeyword =>
            driver.FindElement(By.CssSelector("body > main > h1"));
        public IWebElement ElementSearchResult =>
            driver.FindElement(By.Id("searchResult"));

        public void SearchTask(string keyword)
        {
            TextBoxKeyword.Clear();
            TextBoxKeyword.SendKeys(keyword);
            ButtonSearch.Click();
        }
        public string[] GetAllTasks()
        {
            var tasks = ListOfTasks
                .Select(t => t.Text)
                .ToArray();
            return tasks;
        }
    }
}
