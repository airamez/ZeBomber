using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject bombPrefab; // Bomb prefab
    public Transform bombSpawnPoint; // Spawn point for the bomb
    public float bombDelay = 2f; // Delay between bomb drops, in seconds

    private Vector3 previousPosition; // To track the bomber's previous position
    private Vector3 bomberVelocity; // To calculate bomber velocity
    private float timeSinceLastDrop = 0f; // Timer to track time since last bomb drop

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate the bomber's velocity based on position changes
        bomberVelocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

        // Update the timer
        timeSinceLastDrop += Time.deltaTime;

        // Check if the player presses Space and enough time has passed since the last drop
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastDrop >= bombDelay)
        {
            DropBomb();
            timeSinceLastDrop = 0f; // Reset the timer after dropping a bomb
        }
    }

    void DropBomb()
    {
        // Instantiate the bomb with a downward-facing rotation
        Quaternion downwardRotation = Quaternion.Euler(0, 0, 180);
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, downwardRotation);

        // Assign the bomber's velocity to the bomb
        Rigidbody bombRigidbody = bomb.GetComponent<Rigidbody>();
        if (bombRigidbody != null)
        {
            bombRigidbody.linearVelocity = bomberVelocity;
        }
    }
}
