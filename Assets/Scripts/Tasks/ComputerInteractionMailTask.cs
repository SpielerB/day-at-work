namespace Assets.Scripts.Tasks
{
    /**
     * Handles the status of the mail task
     */
    public class ComputerInteractionMailTask : InteractionTask
    {
        private bool canFinish = false;

        /**
         * Primes the task to be finished
         */
        public void Prime()
        {
            canFinish = true;
        }

        public bool CanFinish() => canFinish;
    }
}
