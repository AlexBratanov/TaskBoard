using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardMobileTests.Objects
{
    public class TaskBoardScreen
    {
        private readonly AndroidDriver<AndroidElement> driver;

        public TaskBoardScreen(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public AndroidElement TextBoxConnectToAPI =>
            driver.FindElementById("taskboard.androidclient:id/editTextApiUrl");
        public AndroidElement ButtonConnect =>
            driver.FindElementById("taskboard.androidclient:id/buttonConnect");
        public AndroidElement TextBoxKeywordSearching =>
            driver.FindElementById("taskboard.androidclient:id/editTextKeyword");
        public AndroidElement ButtonSearch =>
            driver.FindElementById("taskboard.androidclient:id/buttonSearch");
        public AndroidElement ButtonAdd =>
            driver.FindElementById("taskboard.androidclient:id/buttonAdd");
        public AndroidElement TextBoxAddNewTaskTitle =>
            driver.FindElementById("taskboard.androidclient:id/editTextTitle");
        public AndroidElement ButtonCreate =>
            driver.FindElementById("taskboard.androidclient:id/buttonCreate");
        public IReadOnlyCollection<AndroidElement> ElementTaskTitle =>
            driver.FindElementsById("taskboard.androidclient:id/textViewTitle");

        public void ConnectToAPI()
        {
            TextBoxConnectToAPI.Clear();
            TextBoxConnectToAPI.SendKeys("https://taskboard.nakov.repl.co/api");

            ButtonConnect.Click();
        }
        public void SearchForTask(string text)
        {
            TextBoxKeywordSearching.Clear();
            TextBoxKeywordSearching.SendKeys(text);

            ButtonSearch.Click();
        }
        public void AddNewTask(string text)
        {
            ButtonAdd.Click();
            TextBoxAddNewTaskTitle.SendKeys(text);
            ButtonCreate.Click();
        }
    }
}
