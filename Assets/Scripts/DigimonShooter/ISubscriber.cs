namespace DigimonShooter
{
    public interface ISubscriber
    {
        void Subscribe();
        void Unsubscribe();

        void OnEventRaised(params object[] args);
    }
}