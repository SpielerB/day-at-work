using System;
using Assets.Scripts.SelectableObject.Interactions;

namespace Assets.Scripts.Tasks
{
    /**
     * Handles tasks that require the player to interact with something
     */
    public class InteractionTask : Task
    {
        /**
         * The corresponding interaction
         */
        public TaskInteraction interaction;

        protected override void BeginTask()
        {
            interaction.OnInteractionFinished += InteractionFinished;
            TaskIndicator.MoveTo(interaction.transform);
        }

        /**
         * Listener for the task finishing
         */
        private void InteractionFinished(object sender, EventArgs e)
        {
            Finish();
            interaction.OnInteractionStarted -= InteractionFinished;
        }
    }
}
