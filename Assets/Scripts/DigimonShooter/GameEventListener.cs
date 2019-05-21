using UnityEngine;

namespace DigimonShooter
{
    public class GameEventListener : MonoBehaviour, ISubscriber
    {
        [SerializeField] private GameEvent subscription;
        [SerializeField] private GameEventResponse response;
        [SerializeField] private bool requiresSender;

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