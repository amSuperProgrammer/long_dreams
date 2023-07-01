using System.Collections;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    [SerializeField] int bookNum;
    [SerializeField] GameObject buttonSpritePrefab;
    [SerializeField] Vector3 spritePos;
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
            StartCoroutine(takeBook(collision.gameObject));
        }
    }

    IEnumerator takeBook(GameObject player)
    {
        LibraryPlayer libraryPlayer = player.GetComponent<LibraryPlayer>();
        PlayerSkin playerSkin = player.GetComponentInChildren<PlayerSkin>();
        libraryPlayer.enabled = false;
        playerSkin.enabled = false;
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
        do
        {
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.Euler(Vector3.zero), 60);
        } while (player.transform.rotation == Quaternion.Euler(Vector3.zero));

        yield return new WaitForSeconds(1f);

        do
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 5);
        } while (player.transform.position == new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z));
    }


    private void OnTriggerExit(Collider collision)
    {
        Destroy(buttonSprite);
    }
}