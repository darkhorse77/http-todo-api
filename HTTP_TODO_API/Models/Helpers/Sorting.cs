using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_TODO_API.Models.Helpers
{
    public static class Sorting
    {
        public static TaskList Sort(TaskList list, SortState sort)
        {
            switch (sort)
            {
                case SortState.Importance: list.Tasks = list.Tasks.OrderBy(x => x.Priority).ToList(); return list;
                case SortState.ImportanceDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Priority).ToList(); return list;
                case SortState.Deadline: list.Tasks = list.Tasks.OrderBy(x => x.Deadline).ToList(); return list;
                case SortState.DeadlineDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Deadline).ToList(); return list;
                case SortState.Completed: list.Tasks = list.Tasks.Where(x => x.Status == Status.Done).ToList(); return list;
                case SortState.Active: list.Tasks = list.Tasks.Where(x => x.Status == Status.Active).ToList(); return list;
                case SortState.Alphabet: list.Tasks = list.Tasks.OrderBy(x => x.Title).ToList(); return list;
                case SortState.AlphabetDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Title).ToList(); return list;
                case SortState.Created: list.Tasks = list.Tasks.OrderBy(x => x.Created).ToList(); return list;
                case SortState.CreatedDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Created).ToList(); return list;
                default: return list;
            }
        }

        //public static List<TaskList> SortRange(List<TaskList> lists, SortState sort)
        //{
        //    foreach (TaskList list in lists)
        //    {
        //        switch (sort)
        //        {
        //            case SortState.Importance: list.Tasks = list.Tasks.OrderBy(x => x.Priority).ToList(); break;
        //            case SortState.ImportanceDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Priority).ToList(); break;
        //            case SortState.Deadline: list.Tasks = list.Tasks.OrderBy(x => x.Deadline).ToList(); break;
        //            case SortState.DeadLineDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Deadline).ToList(); break;
        //            case SortState.Сompleted: list.Tasks = list.Tasks.Where(x => x.Status == Status.Done).ToList(); break;
        //            case SortState.Active: list.Tasks = list.Tasks.Where(x => x.Status == Status.Active).ToList(); break;
        //            case SortState.Alphabet: list.Tasks = list.Tasks.OrderBy(x => x.Title).ToList(); break;
        //            case SortState.AlphabetDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Title).ToList(); break;
        //            case SortState.Created: list.Tasks = list.Tasks.OrderBy(x => x.Created).ToList(); break;
        //            case SortState.CreatedDesc: list.Tasks = list.Tasks.OrderByDescending(x => x.Created).ToList(); break;
        //            default: break;
        //        }
        //    }
        //    return lists;
        //}
    }
}
