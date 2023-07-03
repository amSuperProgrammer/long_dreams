using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    float horizontalInput;
    public float direction;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            direction = Mathf.Atan2(horizontalInput, 0) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, direction, 0), 360 * Time.deltaTime);
    }
}
