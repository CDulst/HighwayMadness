using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{


    //This could have been a lot cleaner but: timeconstraints

    //Audioclips
    public AudioClip gas;
    public AudioClip neutral;
    public AudioClip brake;
    public AudioClip crash;
    public AudioSource audioSource;
    //Checks if playing
    public bool gasCheck;
    public bool neutralCheck;
    public bool brakeCheck;
    public bool crashCheck;
    //Audio is playing
    public bool audioPlay = true;


    void Start()
    {
        //Get and play audiosource
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioPlay)
        {
            //If moving backwards play brake sound
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (!brakeCheck)
                {
                    audioSource.clip = brake;
                    audioSource.Play();
                    neutralCheck = false;
                    gasCheck = false;
                    brakeCheck = true;
                }
            }
            //If moving forward play gas sound
            else if (Input.GetAxis("Horizontal") > 0)
            {
                if (!gasCheck)
                {
                    audioSource.clip = gas;
                    audioSource.Play();
                    neutralCheck = false;
                    gasCheck = true;
                    brakeCheck = false;
                }
            }
            //If not moving play neutral sound
            else
            {
                if (!neutralCheck)
                {
                    audioSource.clip = neutral;
                    audioSource.Play();
                    neutralCheck = true;
                    gasCheck = false;
                    brakeCheck = false;
                }

            }

        }
        else
        {
            //If not crashing but audioPlay is false than empty out source
            if (!crashCheck)
            {
                audioSource.clip = null;
            }
        }
    }

    //Play sound
    public void PlaySound()
    {
        Debug.Log("play");
        audioSource.Play();

    }

    //Disable audio
    public void DisableAudio()
    {
        audioPlay = false;
    }

    //Set the audio
    public void SetAudio()
    {
        audioPlay = true;
        PlaySound();
    }

    //Play crash sound
    public void Crash()
    {
        Debug.Log("check");
        audioPlay = false;
        crashCheck = true;
        audioSource.loop = false;
        audioSource.clip = crash;
        PlaySound();
    }


    
}
