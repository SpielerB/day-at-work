using UnityEngine;

namespace Assets.Scripts.SelectableObject.Interactions
{
    /**
     * Handles interaction with sound creating objects
     */
    public class SoundInteraction : TaskInteraction
    {
        /**
         * The audio to be played
         */
        public AudioSource audioSource;
        
        /**
         * The required movement node
         */
        public MovementNode requiredPosition;

        private PlayerController player;

        private PlayerController Player
        {
            get
            {
                if (player == null)
                {
                    player = FindObjectOfType<PlayerController>();
                }
                return player;
            }
        }

        protected override void Begin()
        {
            audioSource.Play();
        }

        public override bool CanActivate()
        {
            return requiredPosition != null && requiredPosition == Player.CurrentMovementPoint;
        }

        public void Update()
        {
            if (base.IsActive() && !audioSource.isPlaying)
            {
                Finish();
            }
        }

        public override bool IsActive()
        {
            return audioSource.isPlaying && base.IsActive();
        }

    }
}
