using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class ComputerInteraction : MonoBehaviour, IInteraction
{

    public Canvas screenCanvas;
    public MovementNode requiredMovementNode;

    private PlayerController player;
    private bool online;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public bool CanActivate()
    {
        return requiredMovementNode == null || player.CurrentMovementPoint == requiredMovementNode;
    }

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
