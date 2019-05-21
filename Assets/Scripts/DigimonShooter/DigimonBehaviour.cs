using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Physics = UnityEngine.Physics;

namespace DigimonShooter
{
    public class DigimonBehaviour : MonoBehaviour
    {
        public Transform GunTransform;
        public GameObject GunPrefab;
        [SerializeField] private GameObject currentWeapon;
        private NavMeshAgent _agent;
        [SerializeField]
        private UnityEngine.Events.UnityEvent SelectedResponse;
        [SerializeField]
        private UnityEngine.Events.UnityEvent DeSelectedResponse;
 
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            currentWeapon = Instantiate(GunPrefab, GunTransform);
            GunPrefab.transform.position = Vector3.zero;
        }

        public void Update()
        {
            currentWeapon.GetComponent<ShootBehaviour>().Shoot();
        }
        public void OnSelectionChanged(object[] args)
        {
            var sender = args[0] as GameObject;
            if (sender == gameObject)
            {
                SelectedResponse.Invoke();

            }
            else
            {
                DeSelectedResponse.Invoke();
            }
        }

        public void OnMouseWorldPositionChanged(object[] args)
        {
            if (Global.Instance.CurrentSelection == transform)
            {
                _agent.SetDestination(Global.Instance.WorldMousePosition);
            }
        }
 
    }
}
