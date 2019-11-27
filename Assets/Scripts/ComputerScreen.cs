using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{

    public TextMeshProUGUI time;
    public TextMeshProUGUI date;

    private SimulationController simulation;
    private SimulationController simulation2;

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
}
