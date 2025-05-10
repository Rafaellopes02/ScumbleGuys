using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -6);
    public float mouseSensitivity = 3f;
    public float distance = 6f;

    float yaw = 0f;
    float pitch = 20f;

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, 5f, 80f); // limitar ângulo vertical

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 direction = rotation * Vector3.back * distance;

        transform.position = player.position + direction;
        transform.LookAt(player.position);
    }
}
