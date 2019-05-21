using System.Collections;
using UnityEngine;

namespace DigimonShooter.Guns
{
    public class Gun : ScriptableObject, IShootable
    {
        public float cooldownTime;
        public bool onCooldown;
        public float power = 100;

        [SerializeField] protected GameObject prefab;

        public float timer = 1;

        public virtual void Shoot(Transform trans, MonoBehaviour mono)
        {
            onCooldown = timer > 0 && timer <= cooldownTime;
            mono.StartCoroutine(Cooldown());
        }

        private void OnEnable()
        {
            timer = cooldownTime;
            onCooldown = false;
        }

        private IEnumerator Cooldown()
        {
            while (timer > 0)
            {
                onCooldown = true;
                timer -= Time.deltaTime;

                yield return null;
            }

            timer = cooldownTime;
            onCooldown = false;
        }
    }
}