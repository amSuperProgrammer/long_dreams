using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    GameObject PlayerObj;
    LibraryPlayer Player;
    int bookIndex;
    public Vector3 armChairPos;
    public bool playable = true;
    private void Start()
    {
        PlayerObj = GameObject.Find("Player");
        Debug.Log(PlayerObj.name);
        armChairPos = new Vector3(-7.75f, -1.25f, -5.75f);
    }

    private void Update()
    {
        if (!playable)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, armChairPos, Player.speed * Time.deltaTime);
            if (Player.transform.position == armChairPos)
                SceneManager.LoadScene(bookIndex);
        }
    }

    public void Sleep(int index)
    {
        bookIndex = index;
        Player = PlayerObj.GetComponent<LibraryPlayer>();
        Player.enabled = false;
        playable = false;
    }
}
