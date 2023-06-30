using UnityEngine;
using UnityEngine.SceneManagement;

public class BookTrigger : MonoBehaviour
{
    [SerializeField] int bookNum;
    [SerializeField] GameObject buttonSpritePrefab;
    GameObject buttonSprite;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            buttonSprite = Instantiate(buttonSpritePrefab);
            buttonSprite.transform.position = transform.position + new Vector3(0, 1.25f, -5.25f);
            if (Input.GetKey(KeyCode.E))
                SceneManager.LoadScene(bookNum);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
            SceneManager.LoadScene(bookNum);
    }

    private void OnTriggerExit(Collider collision)
    {
        Destroy(buttonSprite);
    }
}