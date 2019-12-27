using System.Diagnostics.CodeAnalysis;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Tasks
{
    public class TaskController : MonoBehaviour
    {

        public TextMeshProUGUI taskList;
        public Task initialTask;

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
