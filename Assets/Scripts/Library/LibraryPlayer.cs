using UnityEngine;

public class LibraryPlayer : MonoBehaviour
{
    public  int speed;
    float horizontalInput;
    float verticalInput;
    [SerializeField] Animator animator;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Move", (Mathf.Abs(horizontalInput) + 1) * (Mathf.Abs(verticalInput) + 1));
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed);
    }
}
