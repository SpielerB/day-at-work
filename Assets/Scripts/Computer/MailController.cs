using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    /**
     * Handles the selection of mails
     */
    public class MailController : MonoBehaviour
    {
        /**
         * Notifies the listeners if a mail is selected
         */
        public event EventHandler<Mail> OnMailSelected;
        private void MailSelected(Mail mail) => OnMailSelected?.Invoke(this, mail);

        /**
         * The text area for the mail content
         */
        public TextMeshProUGUI mailContentText;

        /**
         * The container for the mail title
         */
        public GameObject mailTitleContainer;

        /**
         * The text area for the mail title
         */
        public TextMeshProUGUI mailTitleText;

        /**
         * The container for the mail sender
         */
        public GameObject mailFromContainer;

        /**
         * The text area for the mail sender
         */
        public TextMeshProUGUI mailFromText;

        /**
         * The text area displayed if no mail has been selected
         */
        public TextMeshProUGUI noMailSelectedText;

        /**
         * Tries to select a mail and displays it if it can be opened
         */
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
}
