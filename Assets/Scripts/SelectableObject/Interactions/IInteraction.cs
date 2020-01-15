namespace Assets.Scripts.SelectableObject.Interactions
{
    /**
     * This interface defines the contract of all interactions
     */
    public interface IInteraction
    {
        /**
         * Returns a bool whether the conditions are met to activate this interaction
         */
        bool CanActivate();

        /**
         * Returns the outline mode for this interaction to control the highlighting
         */
        OutlineMode OutlineMode { get; }

        /**
         * Returns a bool whether the interaction is currently active
         */
        bool IsActive();

        /**
         * Activates the interaction, this method should only be called if CanActivate => true
         * and IsActive => false
         */
        void Activate();

    }
}