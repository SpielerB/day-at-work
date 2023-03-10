using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Assets.Scripts.SelectableObject.Interactions;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.NPCs.State_Machines
{
    /**
     * This class manages the NPC dialogues
     */
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GenericNPCConversation : NPCDialogue
    {
        private DialogueTree root;
        private DialogueTree current;

        /**
         * The corresponding NPC interaction
         */
        public NPCInteraction parent;

        /**
         * The NPC text area
         */
        public TextMeshProUGUI textBox;

        /**
         * The whole dialogue box
         */
        public GameObject dialogueBox;

        /**
         * The "buttons" for the user responses
         */
        public TextMeshProUGUI[] buttons = new TextMeshProUGUI[2];

        /**
         * The actual conversation
         */
        [TextArea(3, 10)]
        public string conversation = "This text will appear in a text area that automatically expands;";

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

        /**
         * Construct the dialogue tree
         */
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

        public override bool IsTalking() => true;


        /**
         * Continues the current conversation
         * !! This method is used in unity itself, don't remove it
         */
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
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

        /**
         * This class is used to construct the dialogue tree.
         */
        private class DialogueTree
        {
            /**
             * The title of this node
             */
            public readonly string title;

            /**
             * The text contained in this node
             */
            public readonly string text;

            /**
             * The next conversation options after hitting this node
             */
            public readonly DialogueTree[] next;

            private DialogueTree(string title, string text, DialogueTree[] next)
            {
                this.next = next ?? new DialogueTree[0];
                this.text = text;
                this.title = title;
            }

            /**
             * Constructs the tree based on the current element
             */
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

            [SuppressMessage("ReSharper", "UnusedMember.Local")]
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
