using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f; // Radius of the explosion
    public LayerMask enemyLayer; // Specify the layer for enemies
    public string enemyName = "Enemy";
    static int enemiesDestroyed = 0;
    private TextMeshProUGUI scoreText;    
    private AudioSource enemyExplosion; 
    private AudioSource bombExplosion; 

    void Start () {
        bombExplosion = GameObject.Find("BombExplosion").GetComponent<AudioSource>();
        enemyExplosion = GameObject.Find("EnemyExplosion").GetComponent<AudioSource>();
        GameObject scoreObject = GameObject.Find("Score");
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.name.StartsWith(enemyName))
        {
            Explode();
        }
    }

    void Explode()
    {
        bombExplosion.Play();
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (Collider enemy in enemies)
        {
            enemyExplosion.Play();
            Destroy(enemy.gameObject);
            Debug.Log($"Emeny name: " + enemy.name);
            if (enemy.name.StartsWith("body")) {
                enemiesDestroyed++;
                scoreText.text = $"Enemies Destroyed: {enemiesDestroyed}";
            }
        }
        Destroy(gameObject);
    }
}
