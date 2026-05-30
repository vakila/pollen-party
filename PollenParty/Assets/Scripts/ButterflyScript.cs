using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class ButterflyScript : MonoBehaviour
{
    public InputActionAsset InputActions;

    [SerializeField] private float flapForce = 5f;

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
            Flap(-1);
        }
        else if (m_flapRight.WasPressedThisFrame())
        {
            Flap(1);
        }
    }

    private void Flap(int direction)
    {
        Vector2 force = new Vector2(direction * flapForce, flapForce);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}