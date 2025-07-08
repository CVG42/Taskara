using System;
using SQLite;

namespace Taskara.Data
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Progress { get; set; } = 0;
        public int Goal { get; set; } = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted => Progress >= Goal;
    }
}