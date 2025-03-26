using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the cube prefab
    public float spawnInterval = 5f; // Interval between spawns
    public float enemyInitialDistance = 250f; // Enemy initial distance
    public const float intervalReductionTime = 300f; // 5 minutes in seconds
    private float spawnTimer = 0f; // Timer to keep track of spawning
    private float intervalTimer = 0f; // Timer to decrease spawnInterval
    void Update()
    {
        spawnTimer += Time.deltaTime;
        intervalTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
        if (intervalTimer >= intervalReductionTime && spawnInterval > 1f)
        {
            spawnInterval -= 1f; // Reduce spawnInterval
            intervalTimer = 0f; // Reset interval timer
        }
    }

    void SpawnEnemy()
    {
        var spawnPosition = GenerateEnemyPosition();
        Vector3 directionToOrigin = (Vector3.zero - spawnPosition).normalized;
        Quaternion rotationToOrigin = Quaternion.LookRotation(directionToOrigin);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, rotationToOrigin);
        enemy.AddComponent<EnemyMover>();
    }

    private Vector3 GenerateEnemyPosition()
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Cos(angle) * enemyInitialDistance;
        float z = Mathf.Sin(angle) * enemyInitialDistance;
        return new Vector3(x, 0f, z);
    }
}
