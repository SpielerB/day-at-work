using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailController : MonoBehaviour
{
    public TextMeshProUGUI mailContentText;
    public GameObject mailTitleContainer;
    public TextMeshProUGUI mailTitleText;
    public GameObject mailFromContainer;
    public TextMeshProUGUI mailFromText;
    public TextMeshProUGUI noMailSelectedText;

    public void Select(Mail mail)
    {
        noMailSelectedText.gameObject.SetActive(false);
        mailContentText.gameObject.SetActive(true);
        mailTitleContainer.gameObject.SetActive(true);
        mailFromContainer.gameObject.SetActive(true);

        mailContentText.text = mail.content;
        mailTitleText.text = mail.title;
        mailFromText.text = mail.from;
    }


}
