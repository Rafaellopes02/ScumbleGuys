using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float dashForce = 8f;

    public Rigidbody rb;
    public Transform cameraTransform;

    private Animator animator;

    float horizontalInput;
    float verticalInput;
    bool isGrounded = true;
    private bool hasDashed = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontalInput, 0f, verticalInput);
        bool isMoving = input.magnitude > 0.1f;

        if (animator != null)
        {
            animator.SetBool("isRunning", isMoving);
        }

        // Salto e mergulho (dash)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                hasDashed = false;

                animator?.SetBool("isJumping", true);
            }
            else if (!hasDashed)
            {
                Vector3 dashDirection = transform.forward;
                rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
                hasDashed = true;

                animator?.SetBool("isDiving", true);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * verticalInput + right * horizontalInput).normalized;
        Vector3 movement = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);

        // Rotação suave na direção do movimento
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
            transform.rotation = smoothedRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            hasDashed = false;

            animator?.SetBool("isJumping", false);
            animator?.SetBool("isDiving", false);
        }
    }
}
