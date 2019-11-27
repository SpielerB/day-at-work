using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;

public class Mail : MonoBehaviour
{
    public string title;
    public string from;
    [TextArea]
    public string content;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI previewText;

    private MailController mailController;

    private void Start()
    {
        mailController = FindObjectOfType<MailController>();
        titleText.text = title.Preview();
        previewText.text = content.Preview();
    }

    public void Select()
    {
        mailController.Select(this);
    }

}
