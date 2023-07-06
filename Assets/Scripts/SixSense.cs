using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SixSense : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] TimelineAsset start;
    [SerializeField] TimelineAsset stay;
    [SerializeField] TimelineAsset end;

    void Update()
    {
        bool isStart = true;

        if (Input.GetKeyDown(KeyCode.LeftControl) && isStart && director.state == PlayState.Paused)
        {
            isStart = false;
            director.playableAsset = start;
            director.Play();
        }
        else if(isStart == false && director.state == PlayState.Paused)
        {
            director.playableAsset = stay; 
            director.Play();
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl) && isStart == false && director.state == PlayState.Paused)
        {
            isStart = true;
            director.playableAsset = end;
            director.Play();
        }
    }
}
