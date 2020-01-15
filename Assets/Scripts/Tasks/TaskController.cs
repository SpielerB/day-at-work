using System.Diagnostics.CodeAnalysis;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Tasks
{
    /**
     * Manages the tasks, updates the task list and notifies the SimulationController about time changes
     */
    public class TaskController : MonoBehaviour
    {
        /**
         * The text area for the task list
         */
        public TextMeshProUGUI taskList;

        /**
         * The initial task
         */
        public Task initialTask;

        /**
         * Shows the task list
         */
        public void ShowTaskList()
        {
            taskList.gameObject.SetActive(true);
        }

        /**
         * Hides the task list
         */
        public void HideTaskList()
        {
            taskList.gameObject.SetActive(false);
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            if (initialTask != null) initialTask.Begin();
            UpdateTaskList();
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
            UpdateTaskList();
        }

        /**
         * Updates the task list
         */
        private void UpdateTaskList()
        {
            var sb = new StringBuilder();
            var current = initialTask;
            var count = 1;
            while (current != null)
            {
                sb.Append(current.IsActive() ? "> " : "   ");
                sb.Append(count++);
                sb.Append(". ");
                sb.Append(current.title);
                sb.Append('\n');
                current = current.nextTask;
            }

            taskList.text = sb.ToString();
        }
    }
}
