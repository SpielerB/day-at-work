namespace Assets.Scripts.Tasks
{
    public class ComputerInteractionMailTask : InteractionTask
    {
        private bool canFinish = false;

        public void Prime()
        {
            canFinish = true;
        }

        public bool CanFinish() => canFinish;
    }
}
