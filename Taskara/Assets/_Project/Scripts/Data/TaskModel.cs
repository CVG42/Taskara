using System;
using System.Collections;
using System.Collections.Generic;
using SQLite;
using UnityEngine;

namespace Taskara.Data
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Progress { get; set; }
        public int Goal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsCompleted => Progress >= Goal;
    }
}