using UnityEngine;

public class LibraryPlayer : MonoBehaviour
{
    public int speed;
    float horizontalInput;
    [SerializeField] Animator animator;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Move", Mathf.Abs(horizontalInput));
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed);
    }
}