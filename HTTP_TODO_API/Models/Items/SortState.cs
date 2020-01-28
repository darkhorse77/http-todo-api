namespace HTTP_TODO_API.Models
{
    /// <summary>
    /// 0 - Importance,
    /// 1 - ImportanceDesc,
    /// 2 - Deadline,
    /// 3 - DeadLineDesc,
    /// 4 - Сompleted,
    /// 5 - Active,
    /// 6 - Alphabet,
    /// 7 - AlphabetDesc,
    /// 8 - Created,
    /// 9 - CreatedDesc
    /// </summary>
    public enum SortState
    {
        Importance,
        ImportanceDesc,
        Deadline,
        DeadlineDesc,
        Completed,
        Active,
        Alphabet,
        AlphabetDesc,
        Created,
        CreatedDesc
    }
}
