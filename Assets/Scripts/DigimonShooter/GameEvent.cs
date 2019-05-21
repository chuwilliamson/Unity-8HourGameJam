using System.Collections.Generic;
using UnityEngine;

namespace DigimonShooter
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject, ISubscription
    {
        private List<ISubscriber> _listeners = new List<ISubscriber>();

        public void Unregister(ISubscriber sub)
        {
            if (_listeners.Contains(sub)) _listeners.Remove(sub);
        }

        public void Register(ISubscriber sub)
        {
            if (!_listeners.Contains(sub))
                _listeners.Add(sub);
        }

        public void Raise()
        {
            Raise(null);
        }

        public void Raise(params object[] args)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--) _listeners[i].OnEventRaised(args);
        }
    }
}