using UnityEngine;

public class Food : MonoBehaviour
{
    public float fallSpeed = 2f;   // atur kecepatan jatuh (lebih kecil = lebih lambat)

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Basket"))
        {
            Destroy(gameObject); // kalau ditangkap, hilang
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // kalau jatuh ke bawah dan tidak ditangkap → hilang
    }
}