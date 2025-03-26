using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement

    void Update()
    {
        // Move towards base (0, 0, 0)
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);

        // Too close to base
        if (Vector3.Distance(transform.position, Vector3.zero) < 10f)
        {
            Destroy(gameObject);
        }
    }
}