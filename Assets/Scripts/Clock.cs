using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Clock : MonoBehaviour
    {

        private TextMeshProUGUI textMesh;
        private SimulationController simulationController;

        private SimulationController SimulationController
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

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            textMesh.text = SimulationController.GetTimeString();
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
            textMesh.text = SimulationController.GetTimeString();
        }
    }
}
