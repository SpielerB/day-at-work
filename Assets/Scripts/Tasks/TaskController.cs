using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{

    public TextMeshProUGUI taskList;
    public Task initialTask;

    private void Start()
    {
        if (initialTask != null) initialTask.Begin();
        UpdateTaskList();
    }

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
