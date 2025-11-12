using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDragPCMobile : MonoBehaviour
{
    public float moveSpeed = 20f;  // increase this value for faster movement
    public float padding = 0.5f;

    private Rigidbody2D rb;
    private Camera mainCam;
    private float minX, maxX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        mainCam = Camera.main;

        Vector2 bottomLeft = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = mainCam.ViewportToWorldPoint(new Vector2(1, 1));

        minX = bottomLeft.x + padding;
        maxX = topRight.x - padding;
    }

    void Update()
    {
        Vector3 newPos = transform.position;

        // --- Mobile Input ---
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Increase sensitivity multiplier
                float deltaX = touch.deltaPosition.x * 0.1f; // 0.1 instead of 0.01
                newPos.x += deltaX * moveSpeed * Time.deltaTime;
            }
        }

        // --- PC Input (Mouse Drag) ---
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.GetAxis("Mouse X") * 10f; // multiply by 10 for more speed
            newPos.x += deltaX * moveSpeed * Time.deltaTime;
        }

        // Clamp horizontal position
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

        transform.position = newPos;
    }
}
