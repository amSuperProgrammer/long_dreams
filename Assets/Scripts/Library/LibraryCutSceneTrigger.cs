using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LibraryCutSceneTrigger : MonoBehaviour
{
    [SerializeField] int bookNum;
    [SerializeField] GameObject buttonSpritePrefab;
    [SerializeField] Vector3 spritePos;
    [SerializeField] TimelineAsset timelineAsset;
    [SerializeField] PlayableDirector director;
    [SerializeField] float initialTime;
    [SerializeField] EventSys eventSys;
    GameObject buttonSprite;

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.name == "Player" && director.state == PlayState.Paused && buttonSprite == null)
        {
            buttonSprite = Instantiate(buttonSpritePrefab);
            buttonSprite.transform.position = transform.position + spritePos;
        }

        if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && director.state == PlayState.Paused)
        {
            if (bookNum != 0)
                eventSys.bookNum = bookNum;

            if (eventSys.bookNum != 0)
            {
                Destroy(buttonSprite);
                director.playableAsset = timelineAsset;
                director.initialTime = initialTime;
                director.Play();
            }
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        Destroy(buttonSprite);
    }
}