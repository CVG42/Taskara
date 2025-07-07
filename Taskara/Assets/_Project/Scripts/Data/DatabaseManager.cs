using System.Collections.Generic;
using System.IO;
using SQLite;
using Taskara.Data;
using UnityEngine;

public class DatabaseManager : Singleton<IDatabaseSource>, IDatabaseSource
{
    private SQLiteConnection _database;
    private string _databasePath => Path.Combine(Application.persistentDataPath, "TaskaraDB.sqlite");

    public void Init()
    {
        _database = new SQLiteConnection(_databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        _database.CreateTable<TaskModel>();
        _database.CreateTable<PlayerStats>();

        if (_database.Find<PlayerStats>(1) == null)
        {
            _database.Insert(new PlayerStats
            {
                Level = 1,
                Experience = 0,
                LastLoginDate = System.DateTime.Now,
            });
        }
    }

    public PlayerStats GetPlayerStats() => _database.Find<PlayerStats>(1);
    public void UpdatePlayerStats(PlayerStats playerStats) => _database.Update(playerStats);

    public void AddTask(TaskModel task) => _database.Insert(task);
    public void UpdateTask(TaskModel task) => _database.Update(task);
    public void DeleteTask(int taskId) => _database.Delete<TaskModel>(taskId);
    public List<TaskModel> GetAllTasks() => _database.Table<TaskModel>().ToList();
    public TaskModel GetTaskById(int id) => _database.Find<TaskModel>(id);
}
