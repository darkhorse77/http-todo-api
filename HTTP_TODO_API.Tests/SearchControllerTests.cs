using HTTP_TODO_API.Models;
using HTTP_TODO_API.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace HTTP_TODO_API.Tests
{
    public class SearchControllerTests
    {
        [Fact]
        public void SearchReturnsNotFoundResultWhenNoMatchesFound()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseInMemoryDatabase("todoapidb");
            var _dbContext = new ApplicationContext(optionsBuilder.Options);

            var controller = new SearchController(_dbContext);

            IActionResult result = controller.Get("invalid request $*@*@*#)#_!(@!_#!!@(_!#(!#_!(");

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
