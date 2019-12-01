using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Tasks;
using UnityEngine;

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

    public override bool CanClose() => !MailTask.IsActive();
}