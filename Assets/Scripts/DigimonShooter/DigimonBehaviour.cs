using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace DigimonShooter
{
    public class DigimonBehaviour : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField] private GameObject currentWeapon;

        [SerializeField] private UnityEvent DeSelectedResponse;

        public GameObject GunPrefab;
        public Transform GunTransform;

        [SerializeField] private UnityEvent SelectedResponse;

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
                SelectedResponse.Invoke();
            else
                DeSelectedResponse.Invoke();
        }

        public void OnMouseWorldPositionChanged(object[] args)
        {
            if (Global.Instance.CurrentSelection == transform)
                _agent.SetDestination(Global.Instance.WorldMousePosition);
        }
    }
}