using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class ButterflyScript : MonoBehaviour
{
    public InputActionAsset InputActions;

    [SerializeField] private float flapForce = 5f;
    [SerializeField] private float horizontalVelocityDecay = 0.95f;
    [SerializeField] private float maxVerticalVelocity = 4f;

    private InputAction m_flapLeft;
    private InputAction m_flapRight;

    private Rigidbody2D rb;
    private void OnEnable()
    {
        InputActions.FindActionMap("Flap").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Flap").Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        InputActionMap flapMap = InputActions.FindActionMap("Flap");
        m_flapLeft = flapMap.FindAction("FlapLeft");
        m_flapRight = flapMap.FindAction("FlapRight");
    }

    private void Update()
    {
        if (m_flapLeft.WasPressedThisFrame())
        {
            Debug.Log("Flap Left");
            Flap(-1);
        }
        else if (m_flapRight.WasPressedThisFrame())
        {
            Debug.Log("Flap Right");
            Flap(1);
        }

        // Apply horizontal velocity decay
        Vector2 velocity = rb.linearVelocity;
        velocity.x *= horizontalVelocityDecay;
        rb.linearVelocity = velocity;

        // Clamp vertical velocity
        velocity = rb.linearVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -maxVerticalVelocity, maxVerticalVelocity);
        rb.linearVelocity = velocity;
    }

    private void Flap(int direction)
    {
        Vector2 force = new Vector2(direction * flapForce, flapForce/2);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}