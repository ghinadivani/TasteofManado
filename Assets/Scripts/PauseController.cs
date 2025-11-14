using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;   // Resume game
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;   // Pause game
            isPaused = true;
        }
    }
}
