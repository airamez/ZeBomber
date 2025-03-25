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
        // Calculate the direction from the spawn position to the origin (0, 0)
        Vector3 directionToOrigin = (Vector3.zero - spawnPosition).normalized;
        // Create a rotation that looks in the direction of the origin
        Quaternion rotationToOrigin = Quaternion.LookRotation(directionToOrigin);
        // Instantiate the enemy at the spawn position and facing the origin
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, rotationToOrigin);
        // Disable any Audio Listener if present
        AudioListener audioListener = enemy.GetComponent<AudioListener>();
        if (audioListener != null)
        {
            audioListener.enabled = false; // Disable the Audio Listener if found
            Debug.Log("Audio Listener detected and disabled on bombPrefab.");
        }
        // Add enemy movement logic
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
