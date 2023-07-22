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

        Debug.Log(new Vector3(horizontalInput + verticalInput, 0, 0).x);
        if (new Vector3(horizontalInput + verticalInput, 0, 0).x != 0)
            direction = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, direction, 0), 360 * Time.deltaTime);
    }
}
