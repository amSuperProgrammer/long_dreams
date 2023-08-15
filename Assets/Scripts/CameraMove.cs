using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraSpeed;
    float cameraMoveX;

    private void Update()
    {
        cameraMoveX = player.transform.position.x;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraMoveX, transform.position.y, transform.position.z), cameraSpeed);
    }
}