using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.NPCs.State_Machines
{
    class GenericNPCConversation : NPCDialogue
    {
        private DialogueTree root;
        private DialogueTree current;

        public NPCInteraction parent;
        public TextMeshProUGUI textBox;
        public GameObject dialogueBox;
        public TextMeshProUGUI[] buttons = new TextMeshProUGUI[4];
        [TextArea(3, 10)]
        public string conversation = "This text will appear in a text area that automatically expands";


        public override void ConvStart()
        {
            if (root == null)
            {
                var q = new Queue<string>(conversation.Split('\n'));
                root = DialogueTree.GetTree(q, 0)[0];
            }
            current = root;

            CreateDialogue();
            dialogueBox.SetActive(true);
        }

        private void CreateDialogue()
        {
            textBox.SetText(current.text);

            foreach (var b in buttons)
            {
                b.gameObject.SetActive(false);
            }
            for (var i = 0; i < current.next.Length && i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].SetText(current.next[i].title);
            }
        }

        public override bool IsTalking()
        {
            return true;
        }


        // ReSharper disable once UnusedMember.Global
        /**
         * Continues the current conversation
         * !! This method is used in unity itself, don't remove it
         */
        public void Continue(TextMeshProUGUI sender)
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != sender) continue;
                current = current.next[i];
                CreateDialogue();
            }

        }

        /**
         * Continues the current conversation
         * !! This method is used in unity itself, don't remove it
         */
        public void Quit()
        {
            parent.Finish();
            dialogueBox.SetActive(false);
        }


        private class DialogueTree
        {
            public readonly string title;
            public readonly string text;
            public readonly DialogueTree[] next;

            private DialogueTree(string title, string text, DialogueTree[] next)
            {
                this.next = next ?? new DialogueTree[0];
                this.text = text;
                this.title = title;
            }

            public static DialogueTree[] GetTree(Queue<string> elements, int depth)
            {
                if (!elements.Any()) return null;

                var c = elements.Dequeue();

                var p = c.Trim().Split(';');

                //messed up Unity text editor fix
                if (c[0] != 'C' || c.Length >= 4) return new[] { new DialogueTree(p[0], p[1], GetTree(elements, depth)) };
                if (depth != 0) return null;

                var str = new List<DialogueTree>();
                var child = GetTree(elements, 1);

                while (child != null)
                {
                    str.Add(child[0]);
                    child = GetTree(elements, 1);
                }

                return str.ToArray();
            }
            public string ToString(int depth = 0)
            {
                var off = new string('\t', depth);
                var retVal = off + title + ";" + text + "\n";
                foreach (var t in next)
                {
                    retVal += t.ToString(depth + 1) + "\n";
                }
                return retVal;
            }
        }
    }
}
