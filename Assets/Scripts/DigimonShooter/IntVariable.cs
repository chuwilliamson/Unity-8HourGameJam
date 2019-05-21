using UnityEngine;

namespace DigimonShooter
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
        public int Value;

        private void OnEnable()
        {
            Value = 0;
        }
    }
}