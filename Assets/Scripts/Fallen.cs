using UnityEngine;

public class Fallen : MonoBehaviour
{
    public float fallSpeed = 2f;
    private Camera cam;
    private float minX, maxX;

    void Start()
    {
        cam = Camera.main;

        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight   = cam.ViewportToWorldPoint(new Vector2(1, 1));

        minX = bottomLeft.x;
        maxX = topRight.x;
    }

    void Update()
    {
        // gerak jatuh
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // kalau keluar layar bawah → destroy
        if (transform.position.y < cam.ViewportToWorldPoint(new Vector3(0, -0.1f, 0)).y)
            Destroy(gameObject);

        // clamp agar tidak keluar layar kiri/kanan
        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}