using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float speed;
    [SerializeField] LayerMask ground;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed);
    }
}
