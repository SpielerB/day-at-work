using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.SelectableObject.Interactions;
using UnityEngine;

public abstract class AbstractState
{

    private NPCInteraction context;

    public void Init(NPCInteraction interaction)
    {
        context = interaction;
    }

    public abstract void DialogueStart();
    public abstract void PlayerTalks();
    public abstract void NPCTalks();
    public void Exit()
    {
        context.Finish();
    }
}

