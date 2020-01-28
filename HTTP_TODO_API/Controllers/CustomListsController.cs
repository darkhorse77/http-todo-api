using System;
using System.Collections.Generic;
using System.Linq;
using HTTP_TODO_API.Models;
using HTTP_TODO_API.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HTTP_TODO_API.Controllers
{
    /// <summary>
    /// CRUD интерфейс для работы с пользовательскими списками
    /// </summary>
    [Route("api/lists/custom")]
    [ApiController]
    public class CustomListsController : ControllerBase
    {
        ApplicationContext db;
        public CustomListsController(ApplicationContext context)
        {
            db = context;
        }

        /// <summary>
        /// Получение всех пользовательских списков
        /// </summary>
        /// <returns>Коллекция списков</returns>
        [HttpGet]
        public List<TaskList> Get()
        {
            List<TaskList> list = db.CustomLists.Include(x => x.Tasks).ToList();
            return list;
        }
        /// <summary>
        /// Получение списка по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort">Сортировка задач в списке</param>
        /// <returns>Список с данным id</returns>
        [HttpGet("{id}/{sort}")]
        public IActionResult Get(int id, SortState sort)
        {
            TaskList list = db.CustomLists.Where(x => x.Id == id).Include(x => x.Tasks).FirstOrDefault();
            if (list == null)
                return NotFound();
            return new ObjectResult(Sorting.Sort(list, sort));

        }
        /// <summary>
        /// Создание нового списка
        /// </summary>
        /// <param name="list">Обьект списка</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TaskList list)
        {
            db.CustomLists.Add(list);
            db.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Изменение списка
        /// </summary>
        /// <param name="list">Изменённый список</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(TaskList list)
        {
            db.CustomLists.Update(list);
            db.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление списка по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TaskList list = db.CustomLists.Where(x => x.Id == id).FirstOrDefault();
            if (list != null)
            {
                db.CustomLists.Remove(list);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}