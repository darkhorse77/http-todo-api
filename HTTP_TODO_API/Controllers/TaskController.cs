using HTTP_TODO_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HTTP_TODO_API.Controllers
{
    /// <summary>
    /// CRUD интерфейс для работы с задачами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ApplicationContext db;
        public TaskController(ApplicationContext context)
        {
            db = context;
        }
        /// <summary>
        /// Получение задачи по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            Task task = db.Tasks.Where(x => x.Id == id).FirstOrDefault();
            if (task == null)
                return NotFound();
            return new ObjectResult(task);
        }
        /// <summary>
        /// Создание новой задачи
        /// </summary>
        /// <param name="task"></param>
        /// <remarks>Запрос посылаем без Id, так как он автоматически даётся базой данных</remarks>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Task task)
        {
            task.Id = new int(); // убираем Id чтобы не было проблемы при добавлении записи в бд
            db.Tasks.Add(task);
            db.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Изменение задачи
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Task task)
        {
            db.Tasks.Update(task);
            db.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление задачи по id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int[] ids)
        {
            List<Task> tasks = null;
            foreach (int id in ids)
            {
                Task task = db.Tasks.Where(x => x.Id == id).FirstOrDefault();
                if(task != null)
                    tasks.Add(task);
            }
            if (tasks != null)
            {
                db.Tasks.RemoveRange(tasks);
                db.SaveChanges();
            }
            return Ok(); 
        }
    }
}