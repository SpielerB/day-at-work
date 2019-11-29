using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptionist : AStateMachine
{ // State Machine
    private readonly static AbstractState d1 = new Dialogue1();
    private readonly static AbstractState d2 = new Dialogue2();
    private readonly static AbstractState d3;
    private readonly static AbstractState d4;

    private static AbstractState state;

    private static bool isTalking;


    public override void ConvStart()
    {
        state = d1;
    }

    public override bool IsTalking()
    {
        return isTalking;
    }

    private class Dialogue1 : AbstractState
    {

        public override void DialogueStart()
        {
            if (!isTalking)
            {
                NPCTalks();

                if (!isTalking)
                {
                    state = d2;
                }
            }


        }

        public override void NPCTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }

        public override void PlayerTalks()
        {
            throw new System.NotSupportedException();
        }
    }

    private class Dialogue2 : AbstractState
    {

        public override void DialogueStart()
        {
            if (!isTalking)
            {
                PlayerTalks();

                if (!isTalking)
                {
                    NPCTalks();

                    if (!isTalking)
                    {
                        state = new Dialogue3();
                    }
                }
            }


        }

        public override void NPCTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }

        public override void PlayerTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }
    }

    private class Dialogue3 : AbstractState
    {

        public override void DialogueStart()
        {
            if (!isTalking)
            {
                PlayerTalks();

                if (!isTalking)
                {
                    NPCTalks();

                    if (!isTalking)
                    {
                        state = new Dialogue4();
                    }
                }
            }

        }

        public override void NPCTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }

        public override void PlayerTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }
    }

    private class Dialogue4 : AbstractState
    {
        public override void DialogueStart()
        {
            if (!isTalking)
            {
                NPCTalks();
                if (!isTalking)
                {
                    state.Exit();
                }
            }

        }

        public override void NPCTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }

        public override void PlayerTalks()
        {
            isTalking = true;
            //
            isTalking = false;
        }
    }


}
