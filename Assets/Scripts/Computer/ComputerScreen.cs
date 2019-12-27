using TMPro;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public class ComputerScreen : MonoBehaviour
    {

        public TextMeshProUGUI time;
        public TextMeshProUGUI date;

        private SimulationController simulation;

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
