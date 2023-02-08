using System;

namespace Assets.Scripts.Tasks
{
    /**
     * Manages tasks related to the player moving to a certain point
     */
    public class MovementTask : Task
    {
        /**
         * The target movement point
         */
        public MovementNode movementNode;

        protected override void BeginTask()
        {
            movementNode.OnPlayerEnter += PlayerMovedToTarget;
            TaskIndicator.MoveTo(movementNode.transform);
        }

        /**
         * Listens for the player moving to the correct point
         */
        private void PlayerMovedToTarget(object sender, EventArgs e)
        {
            Finish();
            movementNode.OnPlayerEnter -= PlayerMovedToTarget;
        }
    }
}
