namespace TodoApi
{
    using System.Collections.Generic;

    class TodoDb
    {
        public static List<Todo> _todos { get; } = new List<Todo>
    {
        new Todo { Id = 1, Name = "Walk dog", IsComplete = false },
        new Todo { Id = 2, Name = "Do dishes", IsComplete = false },
        new Todo { Id = 3, Name = "Finish C# project", IsComplete = false }
    };
    }
}
