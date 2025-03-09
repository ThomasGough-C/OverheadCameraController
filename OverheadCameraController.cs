using UnityEngine;

public class OverheadCameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 15f;

    [Header("Zoom Settings")]
    public float zoomSensitivity = 30f;
    public float minHeight = 10f;
    public float maxHeight = 80f;

    void Update()
    {
        // WASD for horizontal camera movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Mouse scroll wheel for zooming (changes camera height)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 zoom = Vector3.up * -scroll * zoomSensitivity * Time.deltaTime;
        transform.Translate(zoom, Space.World);

        // Clamp the camera height
        float clampedHeight = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedHeight, transform.position.z);
    }
}
