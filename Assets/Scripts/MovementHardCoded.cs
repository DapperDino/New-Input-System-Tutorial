using UnityEngine;
using UnityEngine.InputSystem;

namespace DapperDino
{
    public class MovementHardCoded : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;

        private void Update() => Move();

        private void Move()
        {
            var movement = new Vector3();

            if (Keyboard.current.wKey.isPressed) { movement.z += 1; }
            if (Keyboard.current.sKey.isPressed) { movement.z -= 1; }
            if (Keyboard.current.aKey.isPressed) { movement.x -= 1; }
            if (Keyboard.current.dKey.isPressed) { movement.x += 1; }

            movement.Normalize();

            transform.Translate(movement * movementSpeed * Time.deltaTime);
        }
    }
}
