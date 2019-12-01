using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tasks
{
    public abstract class Task : MonoBehaviour
    {

        public uint startHour;
        public uint startMinute;
        public string title;
        public Task nextTask;

        private SimulationController simCol;

        private SimulationController SimulationController
        {
            get
            {
                if (simCol == null)
                {
                    simCol = FindObjectOfType<SimulationController>();
                }

                return simCol;
            }
        }
        private bool isActive;

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
            if (nextTask != null) nextTask.Begin();
        }

        protected abstract void BeginTask();

    }
}
