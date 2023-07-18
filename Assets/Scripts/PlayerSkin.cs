using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float direction;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            direction = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, direction, 0), 360 * Time.deltaTime);
    }
}
