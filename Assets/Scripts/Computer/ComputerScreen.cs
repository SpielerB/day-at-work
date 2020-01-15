using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    /**
     * This class manages the computer screen on the simulated computer
     */
    public class ComputerScreen : MonoBehaviour
    {
        /**
         * The text area for the current time
         */
        public TextMeshProUGUI time;

        /**
         * The text area for the current date
         */
        public TextMeshProUGUI date;

        private SimulationController simulation;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            simulation = FindObjectOfType<SimulationController>();
            time.text = simulation.GetTimeString();
            date.text = simulation.GetDateString();
        }

        private void Update()
        {
            time.text = simulation.GetTimeString();
            date.text = simulation.GetDateString();
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
