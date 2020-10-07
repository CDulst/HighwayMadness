using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    //List with horn sounds
    public List<AudioClip> sounds;

    
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //Get audio component from self
        audioSource = GetComponent<AudioSource>();
        //Random number between 0,7
        int number = Random.Range(0, 7);
        //Chance that a random hornsound get played when enemy spawns 
        if (number <= 2)
        {
            audioSource.clip = sounds[number];
            audioSource.Play();
        }
    }

   
}
