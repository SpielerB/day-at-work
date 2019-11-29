using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : IInteraction
{   //Kontext of NPC State Machine 
    private bool isActive;

    public AStateMachine machine;

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

    public bool CanActivate()
    {
        throw new System.NotImplementedException();
    }
}
