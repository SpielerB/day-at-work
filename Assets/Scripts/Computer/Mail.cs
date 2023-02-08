using System.Diagnostics.CodeAnalysis;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Computer
{
    /**
     * This class holds information about one Mail on the simulated computer
     */
    public class Mail : MonoBehaviour
    {
        /**
         * The title of this mail
         */
        public string title;

        /**
         * The sender of this mail
         */
        public string from;

        /**
         * The content of this mail
         */
        [TextArea]
        public string content;

        /**
         * Whether the mail can be opened in the mail window
         */
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

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
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
