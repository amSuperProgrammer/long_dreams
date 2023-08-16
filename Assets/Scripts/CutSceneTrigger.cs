using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] TimelineAsset cutScene;
    PlayableDirector director;

    private void Start()
    {
        director = GameObject.Find("timeline").GetComponent<PlayableDirector>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("start cut scene");
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.name == "Player");
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("cutscene was played");
            director.playableAsset = cutScene;
            director.Play();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("start cut scene");
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.name == "Player");
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("cutscene was played");
            director.playableAsset = cutScene;
            director.Play();
        }
    }
}
