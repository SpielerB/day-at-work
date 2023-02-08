using System;
using UnityEngine;

namespace Assets.Scripts.SelectableObject.Interactions
{
    /**
     * This class serves as base for all task related interactions
     */
    public abstract class TaskInteraction : MonoBehaviour, IInteraction
    {
        /**
         * Listeners are notified once the interactions has been finished
         */
        public event EventHandler OnInteractionFinished;

        /**
         * Listeners are notified once the interactions has been started
         */
        public event EventHandler OnInteractionStarted;
        private void FinishInteraction() => OnInteractionFinished?.Invoke(this, EventArgs.Empty);
        private void StartInteraction() => OnInteractionStarted?.Invoke(this, EventArgs.Empty);

        private bool isActive;

        public virtual bool IsActive() => isActive;

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

        protected abstract void Begin();

        public abstract bool CanActivate();

        public virtual OutlineMode OutlineMode => OutlineMode.Always;
    }
}
