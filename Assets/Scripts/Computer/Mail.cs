using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Computer
{
    public class Mail : MonoBehaviour
    {

        public string title;
        public string from;
        [TextArea]
        public string content;

        public bool canBeOpened = false;

        private TextMeshProUGUI titleText;
        private TextMeshProUGUI previewText;

        private MailController mailController;

        private MailController MailController
        {
            get
            {
                if (mailController == null)
                {
                    mailController = FindObjectOfType<MailController>();
                }

                return mailController;
            }
        }

        private void Start()
        {
            titleText = transform.Find("Title").gameObject.GetComponent<TextMeshProUGUI>();
            previewText = transform.Find("Preview").gameObject.GetComponent<TextMeshProUGUI>();
            titleText.text = title.Preview();
            previewText.text = content.Preview();

            var trigger = gameObject.AddComponent<EventTrigger>();
            var pointerClick = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
            pointerClick.callback.AddListener(d => MailController.Select(this));
            trigger.triggers.Add(pointerClick);
        }

    }
}
