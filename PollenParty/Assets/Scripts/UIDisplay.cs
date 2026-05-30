using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI flowersCollectedText;
    [SerializeField] private TextMeshProUGUI spawnTimerText;
    
    private FlowerSpawner flowerSpawner;

    private void Start()
    {
        // Find the FlowerSpawner in the scene
        flowerSpawner = FindObjectOfType<FlowerSpawner>();

        if (flowerSpawner == null)
        {
            Debug.LogError("FlowerSpawner not found in scene!");
        }

        if (flowersCollectedText == null)
        {
            Debug.LogError("Flowers Collected Text is not assigned!");
        }

        if (spawnTimerText == null)
        {
            Debug.LogError("Spawn Timer Text is not assigned!");
        }
    }

    private void Update()
    {
        // Update flowers collected count
        if (flowersCollectedText != null)
        {
            flowersCollectedText.text = "Flowers Collected: " + GameState.instance.flowersCollected;
        }

        // Update spawn timer
        if (spawnTimerText != null && flowerSpawner != null)
        {
            float timeUntilSpawn = flowerSpawner.GetTimeUntilNextSpawn();
            spawnTimerText.text = "Next Flower in: " + timeUntilSpawn.ToString("F1") + "s";
        }
    }
}
