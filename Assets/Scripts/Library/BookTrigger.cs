using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    EventSystem EventSystem;
    [SerializeField] int bookNum;
    [SerializeField] GameObject buttonSpritePrefab;
    GameObject buttonSprite;
    bool inTrigger = false;

    private void Start()
    {
        EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (inTrigger && Input.GetKey(KeyCode.E) && EventSystem.playable)
        {
            EventSystem.Sleep(bookNum);
            Destroy(buttonSprite);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && EventSystem.playable)
        {
            buttonSprite = Instantiate(buttonSpritePrefab);
            buttonSprite.transform.position = transform.position + new Vector3(0, 1.25f, -5.25f);
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
        if(EventSystem.playable)
            Destroy(buttonSprite);
    }
}