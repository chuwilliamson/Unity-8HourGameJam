using DigimonShooter.Guns;
using UnityEngine;

namespace DigimonShooter
{
    public class ShootBehaviour : MonoBehaviour
    {
        public Transform barrelTransform;

        [SerializeField] private Gun weapon;

        private void Start()
        {
            weapon = Instantiate(weapon);
        }

        [ContextMenu("Shoot")]
        public void Shoot()
        {
            weapon.Shoot(barrelTransform, this);
        }
    }
}