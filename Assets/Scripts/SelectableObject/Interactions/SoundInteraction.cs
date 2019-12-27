using UnityEngine;

namespace Assets.Scripts.SelectableObject.Interactions
{
    public class SoundInteraction : TaskInteraction
    {
        public AudioSource audioSource;
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

        public override void Begin()
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
