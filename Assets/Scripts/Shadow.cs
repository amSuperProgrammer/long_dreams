using System.Collections;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public bool move = false;

    private void Start()
    {
        StartCoroutine(ShadowMove());
    }

    private void Update()
    {
        if (move)
        {
            transform.Translate(direction.normalized * Time.deltaTime * 5);
        }
    }

    IEnumerator ShadowMove()
    {
        move = false;
        yield return new WaitForSeconds(Random.Range(2, 3));
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        move = true;
        yield return new WaitForSeconds(Random.Range(3, 5));
        move = false;
        StartCoroutine(ShadowMove());
    }
}
