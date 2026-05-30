using UnityEngine;
using UnityEngine.InputSystem;

public class ButterflyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        Vector2 input = Vector2.zero;

        // A key: move up and left (flapping left)
        if (Keyboard.current.aKey.isPressed)
        {
            input.x -= 1;
            input.y += 1;
        }

        // D key: move up and right (flapping right)
        if (Keyboard.current.dKey.isPressed)
        {
            input.x += 1;
            input.y += 1;
        }

        Vector3 movement = new Vector3(input.x, input.y, input.y).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}