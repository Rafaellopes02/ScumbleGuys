using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    public Transform cameraTransform;

    float horizontalInput;
    float verticalInput;
    bool isGrounded = true;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
            Debug.LogWarning("cameraTransform n�o estava atribu�do, foi automaticamente preenchido.");
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            Debug.LogWarning("rb n�o estava atribu�do, foi automaticamente preenchido.");
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Dire��o baseada na c�mara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0; // n�o queremos que o movimento seja na vertical
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * verticalInput + right * horizontalInput).normalized;
        Vector3 movement = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
