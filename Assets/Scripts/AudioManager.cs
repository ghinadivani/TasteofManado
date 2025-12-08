using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource;
    public AudioClip healthyClip;   // Healthy.mp3
    public AudioClip errorClip;     // Error.mp3

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayHealthy()
    {
        if (healthyClip != null && audioSource != null)
            audioSource.PlayOneShot(healthyClip);
    }

    public void PlayError()
    {
        if (errorClip != null && audioSource != null)
            audioSource.PlayOneShot(errorClip);
    }
}

