using System;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.Interactions
{
    public abstract class TaskInteraction : MonoBehaviour, IInteraction
    {
        public event EventHandler OnInteractionFinished;
        public event EventHandler OnInteractionStarted;
        private void FinishInteraction() => OnInteractionFinished?.Invoke(this, EventArgs.Empty);
        private void StartInteraction() => OnInteractionStarted?.Invoke(this, EventArgs.Empty);

        private bool isActive;

        public bool IsActive() => isActive;

        public void Activate()
        {
            isActive = true;
            Begin();
            StartInteraction();
        }

        public void Finish()
        {
            isActive = false;
            FinishInteraction();
        }

        public abstract void Begin();
        public abstract bool CanActivate();
    }
}
