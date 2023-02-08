using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * Handles information about the simulation like time and the game ending
     */
    public class SimulationController : MonoBehaviour
    {
        /**
         * Default starting hour of the simulation
         */
        public uint? startHour;

        /**
         * Default starting minute of the simulation
         */
        public uint? startMinute;

        /**
         * The canvas for the ending screen
         */
        public CanvasGroup endScreen;

        private DateTime now;
        private bool isSimulationEnding = false;
        private float simulationEndTimer = 0;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            now = DateTime.Now.Date.AddHours(startHour ?? 7).AddMinutes(startMinute ?? 50);
        }

        /**
         * Gets the current time
         */
        public DateTime GetTime()
        {
            return now;
        }

        /**
         * Gets the current time as string
         */
        public string GetTimeString()
        {
            return now.ToString("HH:mm");
        }

        /**
         * Gets the current date as string
         */
        public string GetDateString()
        {
            return now.ToString("dd.MM.yyyy");
        }

        /**
         * Advances the time by the given amount of hours and and minutes
         */
        public void AdvanceTime(uint hour, uint minute)
        {
            now = now.AddHours(hour).AddMinutes(minute);
        }

        /**
         * Sets the time to the given hour/minute
         */
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

        /**
         * Ends the simulation
         */
        public void EndSimulation()
        {
            endScreen.gameObject.SetActive(true);
            isSimulationEnding = true;
        }

    }
}
