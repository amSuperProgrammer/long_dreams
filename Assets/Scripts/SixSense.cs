using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SixSense : MonoBehaviour
{
    int senseState;
    bool senseActivation;
    [SerializeField] PlayableDirector director;
    [SerializeField] TimelineAsset senseStart;
    [SerializeField] TimelineAsset senseStay;
    [SerializeField] TimelineAsset senseStop;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (senseState == 2)
                senseState = 0;
            else
                senseState++;
            senseActivation = true;
        }
        switch (senseState)
        {
            case 1:
                if (director.state == PlayState.Paused && senseActivation)
                {
                    director.playableAsset = senseStart; 
                    senseActivation = false; 
                    director.Play();
                    Debug.Log("start sense");
                }
                if (director.state == PlayState.Paused)
                {
                    director.playableAsset = senseStay; 
                    director.Play();
                    Debug.Log("stay sense");
                }
                break;

            case 2:
                if (director.state == PlayState.Paused && senseActivation)
                {
                    director.playableAsset = senseStop; 
                    senseActivation = false; 
                    director.Play();
                    Debug.Log("stop sense");
                    senseState = 0;
                }
                break;
        }
    }
}