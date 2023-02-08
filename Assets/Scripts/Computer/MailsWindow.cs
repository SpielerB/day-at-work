using Assets.Scripts.Tasks;

namespace Assets.Scripts.Computer
{
    /**
     * The Window for mails on the simulated computer
     */
    public class MailsWindow : ComputerWindow
    {

        private ComputerInteractionMailTask mailTask;

        private ComputerInteractionMailTask MailTask
        {
            get
            {
                if (mailTask == null)
                {
                    mailTask = FindObjectOfType<ComputerInteractionMailTask>();
                }

                return mailTask;
            }
        }

        public override bool CanClose() => MailTask.CanFinish();
    }
}