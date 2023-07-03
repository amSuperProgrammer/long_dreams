using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public bool startBook;
    public int bookNum;
    void Update()
    {
        if (startBook)
            SceneManager.LoadScene(bookNum);
    }
}
