using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    public class SimulationController : MonoBehaviour
    {

        public uint? startHour;
        public uint? startMinute;
        public CanvasGroup endScreen;

        private DateTime now;
        private bool isSimulationEnding = false;
        private float simulationEndTimer = 0;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            now = DateTime.Now.Date.AddHours(startHour ?? 7).AddMinutes(startMinute ?? 50);
        }

        public DateTime GetTime()
        {
            return now;
        }

        public string GetTimeString()
        {
            return now.ToString("HH:mm");
        }

        public string GetDateString()
        {
            return now.ToString("dd.MM.yyyy");
        }

        public void AdvanceTime(uint hour, uint minute)
        {
            now = now.AddHours(hour).AddMinutes(minute);
        }

        public void SetTime(uint hour, uint minute)
        {
            now = now.Date.AddHours(hour).AddMinutes(minute);
        }

        public void Update()
        {
            if (!isSimulationEnding) return;
            endScreen.alpha += (Time.deltaTime / 4);
            if ((simulationEndTimer += Time.deltaTime) > 10)
            {
                Application.Quit();
            }
        }

        public void EndSimulation()
        {
            endScreen.gameObject.SetActive(true);
            isSimulationEnding = true;
        }

    }
}
