using System;
using System.Collections;
using UnityEngine;

namespace DigimonShooter
{
    public class Gun : ScriptableObject, IShootable
    {
        [SerializeField]
        protected GameObject prefab;
        public float power = 100;
        public float timer = 1;
        public float cooldownTime;
        public bool onCooldown = false;

        private void OnEnable()
        {
            timer = cooldownTime;
            onCooldown = false;
        }

        public virtual void Shoot(Transform trans, MonoBehaviour mono)
        {
            onCooldown = timer > 0 && timer <= cooldownTime;
            mono.StartCoroutine(Cooldown());
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