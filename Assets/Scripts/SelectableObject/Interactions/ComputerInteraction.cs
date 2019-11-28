using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class ComputerInteraction : MonoBehaviour, IInteraction
{

    public Canvas screenCanvas;

    private SimulationController simulation;
    private PlayerController player;
    private bool online;

    public void Activate()
    {
        online = true;
        screenCanvas.gameObject.SetActive(true);
    }

    public bool IsActive()
    {
        return online;
    }

}
