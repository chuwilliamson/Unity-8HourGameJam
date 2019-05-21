using UnityEngine;

namespace DigimonShooter
{
    public class GameEventListener : MonoBehaviour, ISubscriber
    {
        [SerializeField] private bool requiresSender;
        [SerializeField] private GameEventResponse response;
        [SerializeField] private GameEvent subscription;

        public void Subscribe()
        {
            subscription.Register(this);
        }

        public void Unsubscribe()
        {
            subscription.Unregister(this);
        }

        public void OnEventRaised(params object[] args)
        {
            var sender = args[0] as GameObject;
            if (requiresSender && sender != gameObject)
                return;
            response.Invoke(args);
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}