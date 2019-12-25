using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.NPCs.State_Machines
{
    class GenericNPCConversation : AStateMachine

    {



        class DialogueTree
        {
            public String title = null;
            public String text = null;
            public DialogueTree[] next = null;


            DialogueTree(String title, String text, DialogueTree[] next)
            {
                if (next != null)
                    this.next = next;
                else
                {
                    this.next = new DialogueTree[0];
                }
                this.text = text;
                this.title = title;
            }


            public static DialogueTree[] GetTree(Queue<String> elemns, int depth)
            {
                if (elemns.Count() == 0)
                {
                    return null;
                }
                String c = elemns.Dequeue();


                //string g = "";
                //foreach (char d in c)
                //    g += "[" + d + "]";

                Debug.Log(g);
                String[] p = c.Trim().Split(';');

                //messed up Unity text editor fix
                if (c[0]=='C'&&c.Length<4)
                {
                    if (depth == 0)
                    {
                        List<DialogueTree> str = new List<DialogueTree>();
                        DialogueTree[] child = GetTree(elemns, 1);
                        while (child != null)
                        {

                            str.Add(child[0]);
                            child = GetTree(elemns, 1);
                        }
                        return str.ToArray();
                    }
                    else
                    {
                        return null;
                    }
                }


                return new DialogueTree[] { new DialogueTree(p[0], p[1], GetTree(elemns, depth)) };

            }
            public String ToString(int depth = 0)
            {
                String off = new string('\t', depth);
                String retVal = off + title + ";" + text + "\n";
                foreach (DialogueTree t in next)
                {
                    retVal += t.ToString(depth + 1) + "\n";
                }
                return retVal;
            }

        }
        DialogueTree root =null;
        DialogueTree current = null;
        

        public NPCInteraction parent;
        public TextMeshProUGUI textBox;
        public GameObject dialogueBox;
        public TextMeshProUGUI[] buttons=new TextMeshProUGUI[4];
        [TextArea(3, 10)]
        public string Conversation = "This text will appear in a text area that automatically expands";

        
        public override void ConvStart()
        {


            if (root == null)
            {
                Queue<String> q = new Queue<String>(Conversation.Split('\n'));
                root = DialogueTree.GetTree(q, 0)[0];
            }
            current = root;
            




            createDialogue(current);
            
                
            dialogueBox.SetActive(true);


        }

        private void createDialogue(DialogueTree current)
        {
            textBox.SetText(current.text);

            foreach (TextMeshProUGUI b in buttons) {
                b.gameObject.SetActive(false);
            }
            for (int i=0;i<current.next.Length&&i<buttons.Length;i++) {
                buttons[i].gameObject.SetActive(true);
                buttons[i].SetText(current.next[i].title);
            }
        }

        public override bool IsTalking()
        {

            Debug.Log("IsTalking");
            return true;
        }


        public void _continue(TextMeshProUGUI sender)
        {

            for (int i=0;i<buttons.Length;i++) {
                if (buttons[i]==sender) {
                    current = current.next[i];
                    createDialogue(current);
                }
            }
            
        }

        public void quit()
        {
            parent.Exit();
            dialogueBox.SetActive(false);
        }
    }
}
