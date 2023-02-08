using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    /**
     * Manages the editor window on the simulated computer
     */
    public class EditorWindow : ComputerWindow
    {
        /**
         * Defines the content to be written to the window
         */
        [TextArea(3, 10)] 
        public string contentToWrite;

        /**
         * Defines how many characters are to be written per second
         */
        [Min(1)]
        public int charsPerSecond = 12;

        /**
         * The text area where the text will be written to
         */
        public TextMeshProUGUI target;

        private int currentIndex;
        private float timer;
        private bool canClose;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
            if (currentIndex >= contentToWrite.Length)
            {
                canClose = true;
            }
            else
            {
                if (!((timer += Time.deltaTime) > 1f / charsPerSecond)) return;
                target.text += contentToWrite[currentIndex++];
                timer = 0;
            }
        }

        public override bool CanClose() => canClose;
    }
}
