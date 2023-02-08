using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.NPCs.State_Machines
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class NPCDialogue : MonoBehaviour
    {
        private AbstractState state;

        /**
         * Start the conversation
         */
        public abstract void ConvStart();

        /**
         * Returns true only if the NPC ist talking
         */
        public abstract bool IsTalking();

        /**
         * Finishes and exits the conversation
         */
        void Exit() { state.Exit();}
    
    }
}
