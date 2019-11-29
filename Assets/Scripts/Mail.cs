﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mail : MonoBehaviour
{
    public string title;
    public string from;
    [TextArea]
    public string content;

    private TextMeshProUGUI titleText;
    private TextMeshProUGUI previewText;

    private MailController mailController;

    private void Start()
    {
        titleText = transform.Find("Title").gameObject.GetComponent<TextMeshProUGUI>();
        previewText = transform.Find("Preview").gameObject.GetComponent<TextMeshProUGUI>();
        mailController = FindObjectOfType<MailController>();
        titleText.text = title.Preview();
        previewText.text = content.Preview();

        var trigger = gameObject.AddComponent<EventTrigger>();
        var pointerClick = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
        pointerClick.callback.AddListener(d => mailController.Select(this));
        trigger.triggers.Add(pointerClick);
    }

}
