using System;
using SQLite;

namespace Taskara.Data
{
    public class PlayerStats
    {
        [PrimaryKey]
        public int ID { get; set; } = 1;
        public int Level { get; set; }
        public int Experience { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}