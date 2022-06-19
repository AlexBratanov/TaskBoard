using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardWebAppTest.Objects
{
    public class TaskBoardPage : BasePage
    {
        public TaskBoardPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://taskboard-1.stykst.repl.co/boards";

        public IReadOnlyCollection<IWebElement> ListOfTasks =>
            driver.FindElements(By.CssSelector("body > main > div > div > table > tbody"));
        public IReadOnlyCollection<IWebElement> ListOfBoards => 
            driver.FindElements(By.CssSelector("body > main > div > div"));
    }
}
