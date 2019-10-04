using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public float effectsTrig;
    public float timer;
    public bool isPlaying;
    public bool timerActive;

    public void Start()
    {
        isPlaying = false;
        timerActive = false;
    }

    //Play on button press
    //If audio is not playing, play
    //If audio is already playing, stop current playback and restart
    public void OnClickPlay()
    {
        if (isPlaying == false)
        {
            AkSoundEngine.PostEvent("Play_Master", gameObject);
            isPlaying = true;
            timerActive = true;
        }

        else if (isPlaying == true)
        {
            AkSoundEngine.PostEvent("Stop_Master", gameObject);
            AkSoundEngine.PostEvent("Play_Master", gameObject);
            isPlaying = true;
            timerActive = true;
        }
    }

    //If playing, run timer and retrigger every 10 seconds
    //Set RTPC for audio effects to random amount
    private void Update()
    {
        if (timerActive == true)
        {
            timer = timer += Time.deltaTime;

            if (timer >= 10)
            {
                OnClickPlay();
                timer = 0;
                effectsTrig = (Random.Range(1, 6));
            }

        }
        
        //Set Effects RTPC to random amount
        AkSoundEngine.SetRTPCValue("Effects", effectsTrig);
    }
}
