using Assets.Scripts.Computer;
using Assets.Scripts.Tasks;

namespace Assets.Scripts.SelectableObject.Interactions
{
    /**
     * This class handles all the computer interactions an the corresponding tasks
     */
    public class ComputerInteraction : TaskInteraction
    {
        /**
         * The movement node where the player has to stand to activate the computer
         */
        public MovementNode requiredMovementNode;

        private PlayerController player;
        private ComputerInteractionMailTask mailTask;
        private InteractionTask documentTask;
        private MailsWindow mailsWindow;
        private MailController mailController;
        private EditorWindow editorWindow;
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
        private EditorWindow EditorWindow
        {
            get
            {
                if (editorWindow == null)
                {
                    editorWindow = transform.GetComponentInChildren<EditorWindow>(true);
                }

                return editorWindow;
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

        protected override void Begin()
        {
            ComputerScreen.Open();
            if (MailTask.IsActive())
            {
                MailsWindow.Open();
                MailController.OnMailSelected += (sender, mail) =>
                {
                    MailTask.Prime();
                };
                MailsWindow.OnWindowClosed += (sender, args) =>
                {
                    Finish();
                };
            } 
            else if (DocumentTask.IsActive())
            {
                EditorWindow.Open();
                EditorWindow.OnWindowClosed += (sender, args) =>
                {
                    Finish();
                    ComputerScreen.Close();
                };
            }
        }

        public override OutlineMode OutlineMode => OutlineMode.ActivatableOnly;
    }
}
