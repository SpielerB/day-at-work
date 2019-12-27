using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.NPCs.State_Machines
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class NPCDialogue : MonoBehaviour
    {
        private AbstractState state;

        public abstract void ConvStart();
        public abstract bool IsTalking();
        void Exit() { state.Exit();}
    
    }
}
