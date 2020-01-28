using HTTP_TODO_API.Controllers;
using HTTP_TODO_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HTTP_TODO_API.Tests
{
    public class CustomListsControllerTests
    {
        [Fact]
        public void GetByIdReturnsNotFoundWhenListNotFound()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseInMemoryDatabase("todoapidb");
            var _dbContext = new ApplicationContext(optionsBuilder.Options);

            var controller = new CustomListsController(_dbContext);

            IActionResult result = controller.Get(999, SortState.Importance);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
