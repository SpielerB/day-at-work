using Assets.Scripts.Computer;
using Assets.Scripts.Tasks;

namespace Assets.Scripts.SelectableObject.Interactions
{
    public class ComputerInteraction : TaskInteraction
    {

        public MovementNode requiredMovementNode;

        private PlayerController player;
        private InteractionTask mailTask;
        private InteractionTask documentTask;
        private MailsWindow mailsWindow;
        private MailController mailController;
        private ComputerScreen computerScreen;

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
        private InteractionTask MailTask
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
        private InteractionTask DocumentTask
        {
            get
            {
                if (documentTask == null)
                {
                    documentTask = FindObjectOfType<ComputerInteractionDocumentTask>();
                }

                return documentTask;
            }
        }
        private MailsWindow MailsWindow
        {
            get
            {
                if (mailsWindow == null)
                {
                    mailsWindow = transform.GetComponentInChildren<MailsWindow>(true);
                }

                return mailsWindow;
            }
        }
        private MailController MailController
        {
            get
            {
                if (mailController == null)
                {
                    mailController = transform.GetComponentInChildren<MailController>(true);
                }

                return mailController;
            }
        }
        private ComputerScreen ComputerScreen
        {
            get
            {
                if (computerScreen == null)
                {
                    computerScreen = transform.GetComponentInChildren<ComputerScreen>(true);
                }

                return computerScreen;
            }
        }


        public override bool CanActivate()
        {
            return (MailTask.IsActive() || DocumentTask.IsActive()) 
                   && (requiredMovementNode == null || Player.CurrentMovementPoint == requiredMovementNode);
        }

        public override void Begin()
        {
            ComputerScreen.Open();
            if (MailTask.IsActive())
            {
                MailsWindow.Open();
                MailController.OnMailSelected += (sender, mail) =>
                {
                    Finish();
                };
                MailsWindow.OnWindowClosed += (sender, args) =>
                {
                    ComputerScreen.Close();
                };
            } 
            else if (DocumentTask.IsActive())
            {
                // TODO: implement document task
            }
        }

    }
}
