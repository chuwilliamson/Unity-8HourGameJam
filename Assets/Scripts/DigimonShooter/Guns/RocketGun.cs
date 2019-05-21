using UnityEngine;

namespace DigimonShooter.Guns
{
    [CreateAssetMenu(menuName = "Guns/Rocketgun")]
    public class RocketGun : Gun
    {
        public override void Shoot(Transform transform, MonoBehaviour mono)
        {
            if (onCooldown)
                return;
            base.Shoot(transform, mono);
            var go = Instantiate(prefab, transform.position, Quaternion.identity);
            var rb = go.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * power, ForceMode.Impulse);
            Destroy(go, 2);
        }
    }
}