using RestSharp;
using System.Net;
using System.Text.Json;

namespace APITests
{
    public class Tests
    {
        private RestClient client;
        private RestRequest request;
        private const string baseUrl = "https://taskboard.stykst.repl.co/api/tasks";

        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseUrl);
        }

        [Test]
        public void Test_GetAllTasks_FirstTasksName()
        {
            // Arrange
            request = new RestRequest(baseUrl);

            // Act
            var response = client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(response.Content);

            // Assert
            Assert.IsNotNull(response.Content);
            Assert.IsTrue(tasks.Count > 0);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Project skeleton", tasks.First().title);
        }

        [Test]
        public void Test_FirstTasksKeyword_Valid()
        {
            // Arrange
            request = new RestRequest(baseUrl + "/search/Home");

            // Act
            var response = client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(response.Content);

            // Assert
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Home page", tasks.First().title);
        }

        [Test]
        public void Test_FirstTasksKeyword_Invalid()
        {
            // Arrange
            var randnum = DateTime.Now.Ticks;
            request = new RestRequest(baseUrl + "/search/" + randnum);

            // Act
            var response = client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(response.Content);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(tasks.Count == 0);
        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            // Arrange
            var title = string.Empty;
            var description = "API + UI tests";
            var board = "Open";
            request = new RestRequest(baseUrl);
            request.AddJsonBody(new { title, description, board});
            var response = client.Execute(request, Method.Post);

            // Act
            var tasks = JsonSerializer.Deserialize<Tasks>(response.Content);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("Title cannot be empty!", tasks.errMsg);
        }

        [Test]
        public void Test_CreateTask_ValidData()
        {
            // Arrange
            var title = "New Task" + DateTime.Now.Ticks;
            var description = "API + UI tests";
            var board = "Open";
            request = new RestRequest(baseUrl);
            request.AddJsonBody(new { title, description, board});
            var response = client.Execute(request, Method.Post);

            // Act
            var newTask = JsonSerializer.Deserialize<Tasks>(response.Content);

            request = new RestRequest(baseUrl + "/search/" + title);
            var newesponse = client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(newesponse.Content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual("Task added.", newTask.msg);
            Assert.AreEqual(title, tasks.First().title);
        }
    }
}