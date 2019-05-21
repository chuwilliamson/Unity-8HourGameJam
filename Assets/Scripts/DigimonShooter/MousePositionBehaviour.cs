using UnityEngine;
using UnityEngine.EventSystems;

namespace DigimonShooter
{
    public class MousePositionBehaviour : MonoBehaviour
    {
        private Camera camera;
        
        public LayerMask layerMask;

        public GameEvent MouseWorldPositionChange;


        [SerializeField] private GameObject myGizmo;



        // Use this for initialization
        private void Start()
        {
            camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        private void Update()
        {
            RaycastHit hitInfo;

            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, 1000.0f, layerMask))
                {
                    if (hitInfo.transform.CompareTag("Ground"))
                    {
                        Global.Instance.WorldMousePosition = hitInfo.point;
                        MouseWorldPositionChange.Raise(new object[]{hitInfo.point});
                        var giz = Instantiate(myGizmo, hitInfo.point, Quaternion.identity);
                        Destroy(giz, .1f);
                    }
                }
            }

        }
    }
}