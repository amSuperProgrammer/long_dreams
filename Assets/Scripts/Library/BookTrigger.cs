using UnityEngine;
using UnityEngine.Playables;

public class BookTrigger : MonoBehaviour
{
    [SerializeField] int bookNum;
    [SerializeField] GameObject buttonSpritePrefab;
    [SerializeField] Vector3 spritePos;
    [SerializeField] PlayableDirector director;
    GameObject buttonSprite;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            buttonSprite = Instantiate(buttonSpritePrefab);
            buttonSprite.transform.position = transform.position + spritePos;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
        {
            Destroy(buttonSprite);
            director.Play();
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        Destroy(buttonSprite);
    }
}