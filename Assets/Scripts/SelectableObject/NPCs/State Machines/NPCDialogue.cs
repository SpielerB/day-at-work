using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCDialogue : MonoBehaviour
{
    private AbstractState state;
    public abstract void ConvStart();
    public abstract bool IsTalking();
    void Exit() { state.Exit();}
    
}
