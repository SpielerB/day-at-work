using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailController : MonoBehaviour
{

    public event EventHandler<Mail> OnMailSelected;
    private void MailSelected(Mail mail) => OnMailSelected?.Invoke(this, mail);

    public TextMeshProUGUI mailContentText;
    public GameObject mailTitleContainer;
    public TextMeshProUGUI mailTitleText;
    public GameObject mailFromContainer;
    public TextMeshProUGUI mailFromText;
    public TextMeshProUGUI noMailSelectedText;

    public void Select(Mail mail)
    {
        if (!mail.canBeOpened) return;

        noMailSelectedText.gameObject.SetActive(false);
        mailContentText.gameObject.SetActive(true);
        mailTitleContainer.gameObject.SetActive(true);
        mailFromContainer.gameObject.SetActive(true);

        mailContentText.text = mail.content;
        mailTitleText.text = mail.title;
        mailFromText.text = mail.from;

        MailSelected(mail);
    }


}
