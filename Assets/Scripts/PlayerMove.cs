using UnityEngine;

public class PlayerMove : MonoBehaviour
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
        Collider[] isGrounded = Physics.OverlapBox(transform.position, new Vector3(0.8f, 0.2f, 0.8f), Quaternion.Euler(0, 0, 0), isGroundedLayer);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float isMove = new Vector3(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput), 0, 0).normalized.x;

        animator.SetFloat("Move", isMove);
        animator.SetBool("Sprint", Input.GetKey(KeyCode.LeftShift));
        animator.SetBool("Jump", isGrounded.Length == 0);

        playerSpeed = Input.GetKey(KeyCode.LeftShift) ? sprint : speed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Length > 0)
            rb.velocity = Vector3.up * jump;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * playerSpeed);
    }
}
