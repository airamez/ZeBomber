using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f; // Radius of the explosion
    public LayerMask enemyLayer; // Specify the layer for enemies
    public string enemyName = "Enemy";
    private AudioSource bombExplosion; 
    private AudioSource enemyExplosion; 

    void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        bombExplosion = GetComponent<AudioSource>();
        bombExplosion = audioSources[0];
        enemyExplosion = audioSources[1]; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.name.StartsWith(enemyName))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            Explode();
        }
    }

    void Explode()
    {
        //bombExplosion.Play();
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (Collider enemy in enemies)
        {
            enemyExplosion.Play();
            Destroy(enemy.gameObject, enemyExplosion.clip.length);
        }
        Destroy(gameObject, enemyExplosion.clip.length);
    }
}
