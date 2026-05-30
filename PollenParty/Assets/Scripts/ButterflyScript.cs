using UnityEngine;
using UnityEngine.InputSystem;

public class ButterflyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            input.y += 1;

        if (Keyboard.current.sKey.isPressed)
            input.y -= 1;

        if (Keyboard.current.dKey.isPressed)
            input.x += 1;

        if (Keyboard.current.aKey.isPressed)
            input.x -= 1;

        Vector3 movement = new Vector3(input.x, 0f, input.y).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}