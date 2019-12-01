using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = SimulationController.GetTimeString();
    }

    private void Update()
    {
        textMesh.text = SimulationController.GetTimeString();
    }
}
