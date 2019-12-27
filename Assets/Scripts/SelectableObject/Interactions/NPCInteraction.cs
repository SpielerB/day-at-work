using System.Diagnostics.CodeAnalysis;
using Assets.Scripts.SelectableObject.NPCs.State_Machines;

namespace Assets.Scripts.SelectableObject.Interactions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NPCInteraction : TaskInteraction
    {
        public NPCDialogue machine;
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

        public override void Begin()
        {
            machine.ConvStart();
        }

        public override bool CanActivate()
        {
            return requiredPosition != null && requiredPosition == Player.CurrentMovementPoint;
        }
    }
}
