using TaskBoardMobileTests.Objects;

namespace TaskBoardMobileTests.Tests
{
    public class TaskBoardTests : BaseTest
    {
        [Test]
        public void Test_TaskBoard_FirstListedTask()
        {
            var screen = new TaskBoardScreen(driver);
            screen.ConnectToAPI();
            Thread.Sleep(5000);
            var firstElementTitle = screen.ElementTaskTitle.First().Text;
            Assert.AreEqual("Project skeleton", firstElementTitle);
        }

        [Test]
        public void Test_TaskBoard_AddTask()
        {
            var screen = new TaskBoardScreen(driver);
            screen.ConnectToAPI();
            Thread.Sleep(5000);
            var newTaskTitle = "Pesho" + DateTime.Now.Ticks;

            screen.AddNewTask(newTaskTitle);
            screen.SearchForTask(newTaskTitle);

            Thread.Sleep(10000);

            var firstElementTitle = screen.ElementTaskTitle.First().Text;
            Assert.AreEqual(newTaskTitle, firstElementTitle);
        }
    }
}