using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalInput;
    [SerializeField]float speed;
    [SerializeField] LayerMask ground;
    Collider2D isGrounded;
    Rigidbody2D rb2D;
    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapBox(new Vector2(boxCollider.offset.x, boxCollider.offset.y - (boxCollider.size.y / 2)), new Vector2(0.8f, 0.2f), 0f, ground);

        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed);

        GameObject cube = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
        cube.transform.position = new Vector2(boxCollider.offset.x, boxCollider.offset.y - (boxCollider.size.y / 2));

        if (isGrounded != null && Input.GetKey(KeyCode.Space))
            rb2D.velocity = Vector3.up * speed;

    }
}
