using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{

    public GameObject playButton;

    //Stop audio, reset values in Play script
    public void OnClickStop()
    {
        if (playButton.GetComponent<Play>().isPlaying == true)
        {
            playButton.GetComponent<Play>().isPlaying = false;
            AkSoundEngine.PostEvent("Stop_Master", gameObject);
            playButton.GetComponent<Play>().timerActive = false;
            playButton.GetComponent<Play>().timer = 0;
        }
    }
}
