using UnityEngine;

namespace BarthaSzabolcs.IsometricAiming
{
    public class IsometricAiming : MonoBehaviour
    {
        
        [SerializeField] private LayerMask groundMask;
        private Camera mainCamera;
        public Vector3 Pos;
        public Vector3 Dir;
        
        private void Start()
        {
            mainCamera = Camera.main;
        }
        private void Update()
        {
            Aim();
        }
        private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                Vector3 direction = position - transform.position;
                // Ignore the height difference.
                direction.y = 0;
                // Make the transform look in the direction.
                transform.forward = direction;
                Pos = position;
                Dir = direction;
                
            }
        }
        private (bool success, Vector3 position) GetMousePosition()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }
    }
}
