namespace Assets.Scripts.SelectableObject.Interactions
{
    public interface IInteraction
    {

        bool CanActivate();

        bool IsAlwaysHighlighted();

        bool IsActive();

        void Activate();

    }
}