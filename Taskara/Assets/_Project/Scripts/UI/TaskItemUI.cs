using System.Collections;
using System.Collections.Generic;
using Taskara.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Taskara.UI
{
    public class TaskItemUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _completeButton;

        private TaskModel _task;

        public void Setup(TaskModel model)
        {
            _task = model;
            UpdateLabel();

            _completeButton.onClick.RemoveAllListeners();
            _completeButton.onClick.AddListener(OnCompleteButtonClicked);
        }

        private void OnCompleteButtonClicked()
        {
            if (_task.Progress < _task.Goal)
            {
                _task.Progress++;
                DatabaseManager.Source.UpdateTask(_task);
                UpdateLabel();
            }
        }

        private void UpdateLabel()
        {
            var percentage = (int)((float)_task.Progress / _task.Goal * 100);
            _label.text = $"{_task.Name}: {_task.Progress}/{_task.Goal} ({percentage}%)";
            _label.color = _task.IsCompleted ? Color.green : Color.white;
        }
    }
}