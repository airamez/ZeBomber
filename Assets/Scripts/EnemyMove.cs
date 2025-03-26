using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMover : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public static int pointsLeft = 20;
    private TextMeshProUGUI pointsLeftText;

    void Start () {
        GameObject pointsLeftObject = GameObject.Find("PointsLeft");
        pointsLeftText = pointsLeftObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Move towards base (0, 0, 0)
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);

        // Got at base
        if (Vector3.Distance(transform.position, Vector3.zero) < 10f)
        {
            Destroy(gameObject);
            pointsLeft--;
            pointsLeftText.text = $"Points Left: {pointsLeft}";
            if (pointsLeft <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}