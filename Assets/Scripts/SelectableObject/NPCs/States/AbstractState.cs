using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.SelectableObject.Interactions;
using UnityEngine;

/**
 * This class holds the state of a NPC dialogue
 */
public abstract class AbstractState
{

    private NPCInteraction context;

    /**
     * Initializes the state
     */
    public void Init(NPCInteraction interaction)
    {
        context = interaction;
    }

    /**
     * Exits the dialogue state
     */
    public void Exit()
    {
        context.Finish();
    }
}

