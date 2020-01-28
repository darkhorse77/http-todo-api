using HTTP_TODO_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HTTP_TODO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        ApplicationContext db;
        public SearchController(ApplicationContext context)
        {
            db = context;
        }
        /// <summary>
        /// Поиск задач по имени во всех списках
        /// </summary>
        /// <param name="condition">Искомое выражение</param>
        /// <returns>Список задач, совпадающих по имени с условием</returns>
        [HttpGet]
        public IActionResult Get(string condition)
        {
            List<Task> result = db.Tasks.Where(x => EF.Functions.Like(x.Title, $"%{condition}%")).ToList();
            if (result.Count == 0)
                return NotFound();
            return new ObjectResult(result);
        }
    }
}