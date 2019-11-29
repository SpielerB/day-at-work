using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteraction
{   //Kontext of NPC State Machine 
    private bool isActive;

    public AStateMachine machine;
    public MovementNode requiredPosition;

    private PlayerController player;
    private PlayerController Player
    {
        get
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerController>();
            }
            return player;
        }
    }

    public bool CanActivate()
    {
        return requiredPosition != null && requiredPosition == Player.CurrentMovementPoint;
    }

    public void Exit()
    {
        isActive = false;
    }
    
    public void Activate()
    {
        machine.ConvStart();
        isActive = true;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
