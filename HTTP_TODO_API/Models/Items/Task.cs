using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HTTP_TODO_API.Models
{
    public class Task
    {   
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } 
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public int? CustomListId { get; set; }
        [JsonIgnore]
        public TaskList CustomList { get; set; }
    }
}
