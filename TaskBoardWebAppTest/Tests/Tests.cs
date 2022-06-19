using OpenQA.Selenium;
using TaskBoardWebAppTest.Objects;

namespace TaskBoardWebAppTest.Tests.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test_GetAllTasks_CheckTitleByBoardName()
        {
            var page = new TaskBoardPage(driver);
            page.Open();

            var boards = page.ListOfBoards;
            foreach (var board in boards)
            {
                var boardName = board
                    .FindElement(By.CssSelector("h1")).Text;
                if (boardName == "Done")
                {
                    var taskTitle = board
                        .FindElement(By.CssSelector("table > tbody > tr > td")).Text;
                    Assert.AreEqual("Project skeleton", taskTitle);
                    break;
                }
            }
        }

        [Test]
        public void Test_SearchTask_ByKeyword()
        {
            var page = new SearchPage(driver);
            page.Open();

            var keyword = "home";
            page.SearchTask(keyword);
            
            var firstTaskTitle = page.GetAllTasks().First();
            Assert.AreEqual("Home page", firstTaskTitle);
        }

        [Test]
        public void Test_SearchTask_ByInvalidKeyword()
        {
            var page = new SearchPage(driver);
            page.Open();

            var keyword = "home" + DateTime.Now.Ticks;
            page.SearchTask(keyword);

            var searchResult = page.ElementSearchResult.Text;
            Assert.AreEqual("No tasks found.", searchResult);
        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            var page = new CreatePage(driver);
            page.Open();

            var title = string.Empty;
            var description = "Some Description";
            page.CreateTask(title, description);

            var errorMessage = page.ElementErrorMessage.Text;
            Assert.AreEqual("Error: Title cannot be empty!", errorMessage);
        }

        [Test]
        public void Test_CreateTask_ValidData()
        {
            var page = new CreatePage(driver);
            page.Open();

            var title = "Task" + DateTime.Now.Ticks;
            var description = "Some Description";
            page.CreateTask(title, description);

            var newPage = new TaskBoardPage(driver);
            newPage.Open();

            var tasks = newPage.ListOfTasks;
            foreach (var task in tasks)
            {
                var taskName = task
                    .FindElement(By.CssSelector("tr.title > td")).Text;
                var isFound = false;
                if (taskName == title)
                {
                    isFound = true;
                    Assert.AreEqual(title, taskName);
                    break;
                }
            }
        }
    }
}