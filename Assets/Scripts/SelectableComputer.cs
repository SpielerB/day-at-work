using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class SelectableComputer : MonoBehaviour
{

    public CanvasGroup screenCanvas;

    private SimulationController simulation;
    private PlayerController player;
    private bool online;

    public void Start()
    {
        simulation = FindObjectOfType<SimulationController>();
        player = FindObjectOfType<PlayerController>();
        Assert.IsNotNull(simulation, "The SimulationController must exist");
        Assert.IsNotNull(player, "The Player must exist");
    }

    public void PointerClick(BaseEventData data)
    {
        online = !online;
        screenCanvas.alpha = online ? 1 : 0;
        screenCanvas.blocksRaycasts = online;
    }

    public void Update()
    {
        simulation.Advance();
    }

}
