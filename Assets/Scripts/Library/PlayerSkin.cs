using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float rotationDirection;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        switch (horizontalInput)
        {
            case > 0:
                rotationDirection = 90; break;
            case < 0:
                rotationDirection = -90; break;
        }

        switch (verticalInput)
        {
            case > 0:
                rotationDirection = 360; break;
            case < 0:
                rotationDirection = 180; break;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotationDirection, 0), 360 * Time.deltaTime);
    }
}
