using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BookTrigger : MonoBehaviour
{
    [SerializeField] int bookNum;
    [SerializeField] GameObject buttonSpritePrefab;
    [SerializeField] Vector3 spritePos;
    [SerializeField] TimelineAsset timelineAsset;
    [SerializeField] PlayableDirector director;
    [SerializeField] float initialTime;
    GameObject buttonSprite;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {

        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.name == "Player" && director.state == PlayState.Paused && buttonSprite == null)
        {
            buttonSprite = Instantiate(buttonSpritePrefab);
            buttonSprite.transform.position = transform.position + spritePos;
        }

        if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && director.state == PlayState.Paused)
        {
            Destroy(buttonSprite);
            director.playableAsset = timelineAsset;
            director.initialTime = initialTime;
            director.Play();
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        Destroy(buttonSprite);
    }
}