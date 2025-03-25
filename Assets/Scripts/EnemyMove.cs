using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement

    void Update()
    {
        // Move cube towards (0, 0, 0)
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);

        // Optional: Destroy cube when it reaches (0, 0, 0)
        if (Vector3.Distance(transform.position, Vector3.zero) < 5f)
        {
            Destroy(gameObject);
        }
    }
}