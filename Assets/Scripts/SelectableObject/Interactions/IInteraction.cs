namespace Assets.Scripts.SelectableObject.Interactions
{
    public interface IInteraction
    {

        bool CanActivate();

        OutlineMode OutlineMode { get; }

        bool IsActive();

        void Activate();

    }
}