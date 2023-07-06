using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraSpeed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), cameraSpeed);
    }
}
