using UnityEngine;

namespace Assets.Scripts.Tasks
{
    /**
     * Basis for all tasks
     */
    public abstract class Task : MonoBehaviour
    {
        /**
         * At which hour the task starts
         */
        public uint startHour;

        /**
         * At which minute the tas starts
         */
        public uint startMinute;

        /**
         * The title of the current task
         */
        public string title;

        /**
         * The succeeding task
         */
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

        /**
         * Starts the current task
         */
        public void Begin()
        {
            SimulationController.SetTime(startHour, startMinute);
            BeginTask();
            isActive = true;
        }

        /**
         * Is used to show if the current task is active
         */
        public bool IsActive() => isActive;

        /**
         * Finishes the current task and starts the next one if available.
         * If no next task is available, it will show the ending screen and finish the simulation
         */
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
