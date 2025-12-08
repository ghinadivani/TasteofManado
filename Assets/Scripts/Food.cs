using UnityEngine;

public class Food : MonoBehaviour
{
    public float fallSpeed = 2f;
    public int pointValue = 10;       // default +10
    public bool isHealthy = true;     // TRUE = makanan sehat, FALSE = makanan tidak sehat

    // flag untuk tahu apakah object sudah tertangkap / sudah diproses
    private bool handled = false;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (handled) return;                    // kalau sudah diproses, jangan apa-apa lagi

        if (col.CompareTag("Basket"))
        {
            handled = true;                     // tandai sudah tertangkap

            // skor
            ScoreManager.instance.AddScore(pointValue);

            // === LOGIKA SUARA ===
            if (AudioManager.Instance != null)
            {
                if (isHealthy)
                {
                    // tangkap makanan sehat
                    AudioManager.Instance.PlayHealthy();
                }
                else
                {
                    // tangkap makanan tidak sehat
                    AudioManager.Instance.PlayError();
                }
            }
            // ====================

            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // kalau sudah ditangani (misal tertangkap), jangan bunyikan apa-apa lagi
        if (handled) return;

        // makanan sehat yang benar-benar miss → ERROR
        if (isHealthy && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayError();
        }

        handled = true;   // tandai sudah diproses sebagai miss
        Destroy(gameObject);
    }
}
