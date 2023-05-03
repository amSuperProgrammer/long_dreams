using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    float verticalInput;
    float horizontalInput;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        verticalInput = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector3(horizontalInput, 0, verticalInput);

    }
}
