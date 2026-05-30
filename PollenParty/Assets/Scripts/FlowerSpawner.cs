using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private float spawnY = -0.25f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnFlower();
            spawnTimer = 0f;
        }
    }

    private void SpawnFlower()
    {
        // Generate random x position between minX and maxX
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Instantiate the flower at the spawn position
        Instantiate(flowerPrefab, spawnPosition, Quaternion.identity);
    }
}
