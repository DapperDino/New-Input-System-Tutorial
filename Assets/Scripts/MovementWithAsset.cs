using UnityEngine;

namespace DapperDino
{
    public class MovementWithAsset : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float jumpHeight = 2f;

        private Controls controls = null;

        private void Awake() => controls = new Controls();
        private void OnEnable() => controls.Player.Enable();
        private void OnDisable() => controls.Player.Disable();
        private void Update() => Move();

        public void Jump()
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + jumpHeight,
                transform.position.z);
        }

        private void Move()
        {
            var movementInput = controls.Player.Movement.ReadValue<Vector2>();

            var movement = new Vector3
            {
                x = movementInput.x,
                z = movementInput.y
            }.normalized;

            transform.Translate(movement * movementSpeed * Time.deltaTime);
        }
    }
}
