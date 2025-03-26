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
            gameObject.SetActive(false);
            Explode();
        }
    }

    void Explode()
    {
        bombExplosion.Play();
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        if (enemies.Length > 0) {
            Destroy(gameObject);
            foreach (Collider enemy in enemies)
            {
                if (enemy.name.StartsWith("Enemy")) {
                    enemyExplosion.Play();
                    var explosionInstance = Instantiate(explosionPrefab, enemy.transform.position, Quaternion.identity);
                    Destroy(explosionInstance, 15);
                    Destroy(enemy.gameObject);
                    enemiesDestroyed++;
                    scoreText.text = $"Enemies Destroyed: {enemiesDestroyed}";
                }
            }
        }
    }
}
