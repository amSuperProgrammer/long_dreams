using UnityEngine;
using UnityEngine.Playables;

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
    PlayableDirector director;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        director = GameObject.Find("timeline").GetComponent<PlayableDirector>();
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

        if (Input.GetKeyDown(KeyCode.E) && director.playableAsset.name == "BookTitle" && director.time < 45)
            director.time = 45;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * playerSpeed);
    }
}
