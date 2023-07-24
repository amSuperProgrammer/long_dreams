using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] List<GameObject> track;
    [SerializeField] GameObject player;
    [SerializeField] float cameraSpeed;
    float cameraMoveX;

    private void Update()
    {
        cameraMoveX = player.transform.position.x;

        if (track[0].transform.position.x > player.transform.position.x)
            cameraMoveX = track[0].transform.position.x;
        else if (track[^1].transform.position.x < player.transform.position.x)
            cameraMoveX = track[^1].transform.position.x;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraMoveX, transform.position.y, transform.position.z), cameraSpeed);
    }
}