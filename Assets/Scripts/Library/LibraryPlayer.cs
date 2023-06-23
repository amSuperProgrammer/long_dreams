using UnityEngine;

public class LibraryPlayer : MonoBehaviour
{
    public  int speed;
    float horizontalInput;
    float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
    }
}
