using UnityEngine;

namespace Assets.Scripts.SelectableObject.Interactions
{
    public class SoundInteraction : MonoBehaviour, IInteraction
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

        public bool CanActivate()
        {
            return requiredPosition != null && requiredPosition == Player.CurrentMovementPoint;
        }

        public bool IsActive()
        {
            return audioSource.isPlaying;
        }
        public void Activate()
        {
            audioSource.Play();
        }

    }
}
