using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]List<GameObject> track;
    [SerializeField]GameObject player;

    private void Update()
    {
        float cameraMoveX = player.transform.position.x;
        if (track[0].transform.position.x > player.transform.position.x)
            cameraMoveX = track[0].transform.position.x;
        else if (track[^1].transform.position.x < player.transform.position.x)
            cameraMoveX = track[^1].transform.position.x;

        transform.position = new Vector3(cameraMoveX, transform.position.y, transform.position.z);
    }
}
