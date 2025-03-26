using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;
    public LayerMask enemyLayer;
    public string enemyName = "Enemy";
    public string groundName = "Ground";
    public GameObject explosionPrefab;
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
        if (collision.gameObject.name == groundName || 
            collision.gameObject.name.StartsWith(enemyName))
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
            Instantiate(explosionPrefab, enemy.transform.position, Quaternion.identity);
            Destroy(enemy.gameObject);
            if (enemy.name.StartsWith("Enemy")) {
                enemiesDestroyed++;
                scoreText.text = $"Enemies Destroyed: {enemiesDestroyed}";
            }
        }
        Destroy(gameObject);
    }
}
