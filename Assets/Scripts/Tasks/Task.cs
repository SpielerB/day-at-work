using UnityEngine;

namespace Assets.Scripts.Tasks
{
    public abstract class Task : MonoBehaviour
    {

        public uint startHour;
        public uint startMinute;
        public string title;
        public Task nextTask;

        private TaskIndicator taskIndicator;
        private SimulationController simulationController;
        private bool isActive;

        protected SimulationController SimulationController
        {
            get
            {
                if (simulationController == null)
                {
                    simulationController = FindObjectOfType<SimulationController>();
                }

                return simulationController;
            }
        }

        protected TaskIndicator TaskIndicator
        {
            get
            {
                if (taskIndicator == null)
                {
                    taskIndicator = FindObjectOfType<TaskIndicator>();
                }

                return taskIndicator;
            }
        }

        public void Begin()
        {
            SimulationController.SetTime(startHour, startMinute);
            BeginTask();
            isActive = true;
        }

        public bool IsActive() => isActive;

        public void Finish()
        {
            if (!isActive) return;
            isActive = false;
            if (nextTask != null)
            {
                nextTask.Begin();
            }
            else
            {
                taskIndicator.gameObject.SetActive(false);
                SimulationController.EndSimulation();
            }
        }

        protected abstract void BeginTask();

    }
}
