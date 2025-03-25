using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the cube prefab
    public float spawnInterval = 5f; // Interval between spawns
    public float enemyInitialDistance = 100f; // Enemy initial distance
    private float timer = 0f; // Timer to keep track of spawning

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Reset timer
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
