using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour {

    public AudioSource audio;
    public AudioClip[] musicList;

    //Start random background music
    void Start()
    {
        PlayRandomMusic();
    }


    //Check to see if audio is playing, and if not play a random track from the array
    void Update()
    {
        if (!audio.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    //chooses a random song from the array of songs and plays it
    void PlayRandomMusic()
    {
        audio.clip = musicList[Random.Range(0, musicList.Length)] as AudioClip;
        audio.Play();
        Debug.Log(audio.clip);
    }

}
