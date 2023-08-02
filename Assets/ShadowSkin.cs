using UnityEngine;

public class ShadowSkin : MonoBehaviour
{
    Shadow shadowScript;
    Animator animator;
    private void Start()
    {
        shadowScript = GetComponentInParent<Shadow>();
        animator= GetComponent<Animator>();
    }

    private void Update()
    {
        float rotateDirection = Mathf.Atan2(shadowScript.direction.x, shadowScript.direction.z) * Mathf.Rad2Deg;

        animator.SetBool("Move", shadowScript.move);

        if (shadowScript.move)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotateDirection, 0), 240 * Time.deltaTime);
        }
        
    }
}
