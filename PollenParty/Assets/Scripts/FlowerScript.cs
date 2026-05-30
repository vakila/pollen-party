using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    [SerializeField] private float collectionTime = 1f;

    private GameState gameState;
    private float collisionTimer = 0f;

    private void Start()
    {
        gameState = new GameState();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the butterfly is in collision with this flower
        if (collision.GetComponent<ButterflyScript>() != null)
        {
            // Increment the timer
            collisionTimer += Time.deltaTime;

            // Check if the butterfly has been in collision long enough
            if (collisionTimer >= collectionTime)
            {
                // Increment the flowers collected counter
                gameState.flowersCollected++;
                Debug.Log("Flower collected!");

                // Destroy the entire flower (parent container with Bloom and Stem)
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the butterfly left the collision zone
        if (collision.GetComponent<ButterflyScript>() != null)
        {
            // Reset the timer
            collisionTimer = 0f;
        }
    }

    public float GetCollectionProgress()
    {
        return Mathf.Clamp01(collisionTimer / collectionTime);
    }
}
