using System;
using System.Diagnostics.CodeAnalysis;
using Assets.Scripts.SelectableObject.NPCs.State_Machines;
using Assets.Scripts.Tasks;

namespace Assets.Scripts.SelectableObject.Interactions
{
    /**
     * Handles interacting with NPCs
     */
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NPCInteraction : TaskInteraction
    {
        /**
         * The corresponding dialogue
         */
        public NPCDialogue machine;

        /**
         * The required movement node
         */
        public MovementNode requiredPosition;


        private TaskController taskController;
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

        private TaskController TaskController
        {
            get
            {
                if (taskController == null)
                {
                    taskController = FindObjectOfType<TaskController>();
                }

                return taskController;
            }
        }

        protected override void Begin()
        {
            TaskController.HideTaskList();
            OnInteractionFinished += OnFinish;
            machine.ConvStart();
        }

        public override bool CanActivate()
        {
            return requiredPosition != null && requiredPosition == Player.CurrentMovementPoint;
        }

        /**
         * Listener method for finishing the conversation
         */
        private void OnFinish(object sender, EventArgs args)
        {
            OnInteractionFinished -= OnFinish;
            TaskController.ShowTaskList();
        }

        public override OutlineMode OutlineMode => OutlineMode.HoverOnly;
    }
}
