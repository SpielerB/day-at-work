using Assets.Scripts.SelectableObject.Interactions;
using Assets.Scripts.Tasks;
using UnityEngine;

public class ComputerInteraction : TaskInteraction
{

    public Canvas screenCanvas;
    public MovementNode requiredMovementNode;
    public MailsWindow mailsWindow;
    public MailController mailController;

    private PlayerController player;
    private InteractionTask mailTask;
    private InteractionTask documentTask;

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
    public InteractionTask MailTask
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
    public InteractionTask DocumentTask
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

    public override bool CanActivate()
    {
        return (MailTask.IsActive() || DocumentTask.IsActive()) 
               && (requiredMovementNode == null || Player.CurrentMovementPoint == requiredMovementNode);
    }

    public override void Begin()
    {
        screenCanvas.gameObject.SetActive(true);
        if (MailTask.IsActive())
        {
            mailsWindow.Open();
            mailController.OnMailSelected += (sender, mail) =>
            {
                Finish();
            };
            mailsWindow.OnWindowClosed += (sender, args) =>
            {
                screenCanvas.gameObject.SetActive(false);
            };
        } 
        else if (DocumentTask.IsActive())
        {
            // TODO: implement document task
        }
    }

}
