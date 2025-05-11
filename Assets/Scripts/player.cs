using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    public Rigidbody rb;
    public Transform cameraTransform;

    private Animator animator;

    float horizontalInput;
    float verticalInput;
    bool isGrounded = true;

    [Header("Áudio")]
    public AudioSource audioPasso;
    public AudioSource audioSalto;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontalInput, 0f, verticalInput);
        bool isMoving = input.magnitude > 0.1f;

        if (animator != null)
            animator.SetBool("isRunning", isMoving);

        // Som de passos
        if (isMoving && isGrounded)
        {
            if (audioPasso != null && !audioPasso.isPlaying)
                audioPasso.Play();
        }
        else
        {
            if (audioPasso != null && audioPasso.isPlaying)
                audioPasso.Stop();
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            if (animator != null)
                animator.SetBool("isJumping", true);

            if (audioSalto != null)
                audioSalto.Play();
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

        // Rotação suave
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;

            if (animator != null)
                animator.SetBool("isJumping", false);
        }
    }
}
