using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game is quitting...");
        }
    }
}
