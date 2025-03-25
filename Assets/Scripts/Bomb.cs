using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f; // Radius of the explosion
    public LayerMask enemyLayer; // Specify the layer for enemies

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.name.StartsWith("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (Collider enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        Debug.Log("Boom! Explosion triggered.");
    }
}
