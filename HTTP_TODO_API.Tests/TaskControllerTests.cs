using HTTP_TODO_API.Controllers;
using HTTP_TODO_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HTTP_TODO_API.Tests
{
    public class TaskControllerTests
    {
        [Fact]
        public void GetTaskReturnsBadRequestResultWhenIdIsNull()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseInMemoryDatabase("todoapidb");
            var _dbContext = new ApplicationContext(optionsBuilder.Options);

            var controller = new TaskController(_dbContext);

            IActionResult result = controller.Get(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetTaskReturnsNotFoundResultWhenTaskNotFound()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseInMemoryDatabase("todoapidb");
            var _dbContext = new ApplicationContext(optionsBuilder.Options);
            _dbContext.Remove(new Task { Id = 999 });
            // в фейковой бд нет записи с этим Id
            int testUserId = 999;

            var controller = new TaskController(_dbContext);

            IActionResult result = controller.Get(testUserId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostTaskReturnsOkWhenGivenId()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseInMemoryDatabase("todoapidb");
            var _dbContext = new ApplicationContext(optionsBuilder.Options);
            Task testTask = new Task { Id = 100, Title = "Test" };

            var controller = new TaskController(_dbContext);

            IActionResult result = controller.Post(testTask);

            Assert.IsType<OkResult>(result);
        }
    }
}
