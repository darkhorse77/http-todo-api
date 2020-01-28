using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTTP_TODO_API.Models;
using HTTP_TODO_API.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTTP_TODO_API.Controllers
{
    /// <summary>
    /// Доступ к умным спискам
    /// </summary>
    [Route("api/lists/smart/[action]")]
    [ApiController]
    public class SmartListsController : ControllerBase
    {
        ApplicationContext db;
        public SmartListsController(ApplicationContext context)
        {
            db = context;
        }
        /// <summary>
        /// Получение всех задач
        /// </summary>
        /// <param name="sort">Параметр сортировки</param>
        /// <returns></returns>
        [HttpGet]
        public TaskList All(SortState sort)
        {
            TaskList taskList = new TaskList("All tasks", db.Tasks.ToList());
            return Sorting.Sort(taskList, sort);
        }
        /// <summary>
        /// Получение всех задач, имеющих срок выполнения
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        public TaskList Planned(SortState sort)
        {
            TaskList taskList = new TaskList("Planned tasks", db.Tasks.Where(x => x.Deadline != DateTime.MinValue && x.Deadline != null).ToList());
            return Sorting.Sort(taskList, sort);
        }
        /// <summary>
        /// Получение всех задач с высоким приоритетом
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        public TaskList Important(SortState sort)
        {
            TaskList taskList = new TaskList("Important tasks", db.Tasks.Where(x => x.Priority == Priority.High).ToList());
            return Sorting.Sort(taskList, sort);
        }
        /// <summary>
        /// Получение всех задач, у которых дедлайн сегодня
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        public TaskList Todays(SortState sort)
        {
            TaskList taskList = new TaskList("Today's tasks", db.Tasks.Where(x => x.Deadline.Day == DateTime.Today.Day).ToList());
            return Sorting.Sort(taskList, sort);
        }
    }
}