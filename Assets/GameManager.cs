using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted = false;

    void Start()
    {
        gameStarted = false;
    }

    public static void StartGame()
    {
        gameStarted = true;
    }
}
