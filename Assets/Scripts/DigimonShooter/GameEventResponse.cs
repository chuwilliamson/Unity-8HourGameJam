using System;
using UnityEngine.Events;

namespace DigimonShooter
{
    [Serializable]
    public class GameEventResponse : UnityEvent<object[]>
    {
    }
}