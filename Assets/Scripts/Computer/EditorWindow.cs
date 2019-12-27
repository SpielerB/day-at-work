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
    public class EditorWindow : ComputerWindow
    {
        [TextArea(3, 10)] 
        public string contentToWrite;
        [Min(1)]
        public int charsPerSecond = 12;
        public float closingDelay = 4;
        public TextMeshProUGUI target;

        private int currentIndex;
        private float timer;
        private bool canClose;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
            if (currentIndex >= contentToWrite.Length)
            {
                if ((timer += Time.deltaTime) >= closingDelay)
                {
                    canClose = true;
                }
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
