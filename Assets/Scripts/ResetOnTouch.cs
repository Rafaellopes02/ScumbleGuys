using UnityEngine;

public class ResetOnTouch : MonoBehaviour
{
    public Transform player;

    private Vector3 resetPosition = Vector3.zero; // (0, 0, 0)

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == player)
        {
            player.position = resetPosition;

            // Parar movimento, se tiver Rigidbody
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
