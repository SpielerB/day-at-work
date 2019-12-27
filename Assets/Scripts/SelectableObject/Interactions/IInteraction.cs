namespace Assets.Scripts.SelectableObject.Interactions
{
    public interface IInteraction
    {

        bool CanActivate();

        bool IsActive();

        void Activate();

    }
}