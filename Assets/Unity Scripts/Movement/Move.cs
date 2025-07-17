using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [Tooltip("Pixels Per Unit of your sprites (default is usually 100)")]
    public int pixelsPerUnit = 100;

    [Tooltip("Speed in pixels per second")]
    public float speedPixelsPerSecond = 100f;

    private Rigidbody2D rb;
    private Vector2 input;
    private float moveSpeedUnitsPerSecond;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.None; // Avoid interpolation for pixel perfect
    }

    private void Update()
    {
        // Get raw input so we only move in discrete steps (no smoothing)
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D and Left/Right arrows
        float vertical = Input.GetAxisRaw("Vertical");     // W/S and Up/Down arrows

        if (horizontal != 0)
            input = new Vector2(horizontal, 0);
        else
            input = new Vector2(0, vertical);

    }

    void FixedUpdate()
    {
        float moveSpeedUnitsPerSecond = speedPixelsPerSecond / pixelsPerUnit;

        Vector2 movement = input * moveSpeedUnitsPerSecond * Time.fixedDeltaTime;

        Vector2 currentPosPixels = (Vector2)transform.position * pixelsPerUnit;

        Vector2 newPosPixels = currentPosPixels + (movement * pixelsPerUnit);

        newPosPixels.x = Mathf.Round(newPosPixels.x);
        newPosPixels.y = Mathf.Round(newPosPixels.y);

        Vector2 newPosUnits = newPosPixels / pixelsPerUnit;

        rb.MovePosition(newPosUnits);
    }
}