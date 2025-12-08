using UnityEngine;

public class Food : MonoBehaviour
{
    public float fallSpeed = 2f;
    public int pointValue = 10; // default +10

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Basket"))
        {
            ScoreManager.instance.AddScore(pointValue);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}