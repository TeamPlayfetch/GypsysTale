//--------------------------------------------------------------------------------------
// Purpose: Play random song.
//
// Description: This script plays a random song from a public array of songs. It is to be
// attached to any object that has an audio source.
//
// Author: Zane Talbot.
//
// Edited: Thomas Wiltshire.
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// RandomAudio object. Inheriting from MonoBehaviour. Class for playing random audio.
//--------------------------------------------------------------------------------------
public class RandomAudio : MonoBehaviour
{
    // AUDIO //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Audio:")]

    // public array of audio clips
    [LabelOverride("Music List")] [Tooltip("An array of music to play durring the game, will be selected from this list at random.")]
    public AudioClip[] m_aacMusicList;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private audio source.
    private AudioSource m_asAudioSource;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get the audiosource component of the object
        m_asAudioSource = GetComponent<AudioSource>();

        // Run random music selection function.
        PlayRandomMusic();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // if audio is not playing
        if (!m_asAudioSource.isPlaying && !PauseManager.ms_bPaused)
        {
            // run random music selection function.
            PlayRandomMusic();
        }
    }

    //--------------------------------------------------------------------------------------
    // PlayRandomMusic: Chooses a random song from the array of songs and plays it.
    //--------------------------------------------------------------------------------------
    void PlayRandomMusic()
    {
        // get an audio clip from the msuic list array.
        m_asAudioSource.clip = m_aacMusicList[Random.Range(0, m_aacMusicList.Length)] as AudioClip;

        // Play the audio
        m_asAudioSource.Play();

        // Display which audio is playing in the console.
        Debug.Log(m_asAudioSource.clip);
    }
}