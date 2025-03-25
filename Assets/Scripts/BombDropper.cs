using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
    }

    void DropBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
        
        // Check and disable any Audio Listener in the instantiated object
        AudioListener audioListener = bomb.GetComponent<AudioListener>();
        if (audioListener != null)
        {
            audioListener.enabled = false; // Disable the Audio Listener if found
            Debug.Log("Audio Listener detected and disabled on bombPrefab.");
        }
    }
}
