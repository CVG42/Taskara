using System.Collections.Generic;
using Taskara.Data;

public interface IDatabaseSource
{
    void Init();

    void AddTask(TaskModel task);
    void UpdateTask(TaskModel task);
    void DeleteTask(int taskId);
    List<TaskModel> GetAllTasks();
    TaskModel GetTaskById(int id);

    PlayerStats GetPlayerStats();
    void UpdatePlayerStats(PlayerStats playerStats);
}
