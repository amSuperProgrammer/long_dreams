using UnityEngine;

public class LibraryPlayer : MonoBehaviour
{
    public int speed;
    public int sprint;
    public int jump;
    int playerSpeed;
    float horizontalInput;
    float verticalInput;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask isGroundedLayer;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Move", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animator.SetBool("Sprint", Input.GetKey(KeyCode.LeftShift));
        playerSpeed = Input.GetKey(KeyCode.LeftShift) ? sprint : speed;

        Collider[] isGrounded = Physics.OverlapBox(transform.position, new Vector3(0.8f, 0.2f, 0.8f), Quaternion.Euler(0, 0, 0), isGroundedLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Length > 0)
            rb.velocity = Vector3.up * jump;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * playerSpeed);
    }
}
