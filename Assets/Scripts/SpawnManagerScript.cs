using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Different prefabs for each level
    public float spawnInterval = 2.0f; // Time between spawns
    public float spawnAreaPadding = 0.5f; // Padding from the edges of the screen

    private float xMin, xMax, yMin, yMax;

    void Start()
    {
        // Calculate the screen boundaries based on the main camera's view
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        xMin = bottomLeft.x + spawnAreaPadding;
        xMax = topRight.x - spawnAreaPadding;
        yMin = bottomLeft.y + spawnAreaPadding;
        yMax = topRight.y - spawnAreaPadding;

        // Start spawning enemies at regular intervals
        if (enemyPrefabs.Length > 0)
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }
        else
        {
            Debug.LogError("Enemy prefabs are not assigned in SpawnManager.");
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length > 0)
        {
            // Randomly choose one of the four sides to spawn the enemy
            int side = Random.Range(0, 4);
            Vector3 spawnPosition = Vector3.zero;

            switch (side)
            {
                case 0: // Left
                    spawnPosition = new Vector3(xMin, Random.Range(yMin, yMax), 0);
                    break;
                case 1: // Right
                    spawnPosition = new Vector3(xMax, Random.Range(yMin, yMax), 0);
                    break;
                case 2: // Bottom
                    spawnPosition = new Vector3(Random.Range(xMin, xMax), yMin, 0);
                    break;
                case 3: // Top
                    spawnPosition = new Vector3(Random.Range(xMin, xMax), yMax, 0);
                    break;
            }

            // Randomly select an enemy prefab to instantiate
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No enemy prefabs assigned. Cannot spawn enemy.");
        }
    }
}