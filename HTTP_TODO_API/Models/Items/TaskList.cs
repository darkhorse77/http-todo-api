using System.Collections.Generic;

namespace HTTP_TODO_API.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskList(string title, List<Task> tasks)
        {
            Title = title;
            Tasks = tasks;
        }

        public TaskList() { }
    }
}
