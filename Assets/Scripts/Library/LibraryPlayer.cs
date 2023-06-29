using UnityEngine;

public class LibraryPlayer : MonoBehaviour
{
    public int speed;
    public int sprint;
    public int jump;
    int playerSpeed;
    float horizontalInput;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask isGroundedLayer;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Collider[] isGrounded = Physics.OverlapBox(transform.position, new Vector3(0.8f, 0.2f, 0.8f), Quaternion.Euler(0, 0, 0), isGroundedLayer);
        horizontalInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Move", Mathf.Abs(horizontalInput));
        animator.SetBool("Sprint", Input.GetKey(KeyCode.LeftShift));
        animator.SetBool("Jump", isGrounded.Length == 0);

        playerSpeed = Input.GetKey(KeyCode.LeftShift) ? sprint : speed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Length > 0)
            rb.velocity = Vector3.up * jump;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * playerSpeed);
    }
}
