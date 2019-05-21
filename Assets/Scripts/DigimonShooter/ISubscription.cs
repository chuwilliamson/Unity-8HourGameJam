namespace DigimonShooter
{
    public interface ISubscription
    {
        void Unregister(ISubscriber sub);
        void Register(ISubscriber sub);
    }
}