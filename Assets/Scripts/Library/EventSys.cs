using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSys : MonoBehaviour
{
    public bool startBook;
    public int bookNum;
    void Update()
    {
        if (startBook && bookNum != 0)
            SceneManager.LoadScene(bookNum);
    }
}
