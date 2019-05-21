using UnityEngine;

namespace DigimonShooter
{
    public interface IShootable
    {
        void Shoot(Transform trans, MonoBehaviour mono);
    }
}