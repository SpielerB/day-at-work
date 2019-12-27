using System;

namespace Assets.Scripts.Tasks
{
    public class MovementTask : Task
    {

        public MovementNode movementNode;

        protected override void BeginTask()
        {
            movementNode.OnPlayerEnter += PlayerMovedToTarget;
            TaskIndicator.MoveTo(movementNode.transform);
        }

        private void PlayerMovedToTarget(object sender, EventArgs e)
        {
            Finish();
            movementNode.OnPlayerEnter -= PlayerMovedToTarget;
        }
    }
}
