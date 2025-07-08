using Taskara.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Taskara.UI
{
    public class TaskUIController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _taskTitle;
        [SerializeField] private TMP_InputField _taskDescription;
        [SerializeField] private TMP_InputField _taskGoal;
        [SerializeField] private TMP_Dropdown _taskType;
        [SerializeField] private Transform _taskListPanel;
        [SerializeField] private GameObject _taskItemPrefab;
        [SerializeField] private Button _addTaskButton;

        private void Start()
        {
            DatabaseManager.Source.Init();
            RefreshTaskList();
            _addTaskButton.onClick.AddListener(OnAddTaskClicked);
        }

        private void RefreshTaskList()
        {
            foreach (Transform task in _taskListPanel)
            {
                Destroy(task.gameObject);
            }

            var tasks = DatabaseManager.Source.GetAllTasks();

            foreach (var task in tasks)
            {
                var row = Instantiate(_taskItemPrefab, _taskListPanel).GetComponent<TaskItemUI>();
                row.Setup(task);
            }
        }

        private void OnAddTaskClicked()
        {
            if (string.IsNullOrWhiteSpace(_taskTitle.text)) return;

            int goal = int.TryParse(_taskGoal.text, out var pasedGoal) ? pasedGoal : 1;

            var task = new TaskModel
            {
                Name = _taskTitle.text,
                Description = _taskDescription.text,
                Type = _taskType.options[_taskType.value].text.ToLower(),
                Goal = goal,
                CreatedDate = System.DateTime.Now,
                DueDate = System.DateTime.Now.Date,
                Progress = 0,
            };

            DatabaseManager.Source.AddTask(task);
            RefreshTaskList();
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            _taskTitle.text = "";
            _taskDescription.text = "";
            _taskGoal.text = "";
            _taskType.value = 0;
        }
    }
}