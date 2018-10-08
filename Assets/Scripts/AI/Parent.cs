using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour {

    //Calls upon the AI_Follow script functions
    AI_Follow ai;

    AudioSource aSource;
    public AudioClip clip;

    public bool fetchCompleted = false;

    private void Awake()
    {
        // Finds an object in the scene that has the script AI_Follow
        // and grabs the functions from that script
        ai = FindObjectOfType<AI_Follow>();
        aSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // If an object tagged "Child" collides with this object then
        // the bool isActive from the AI_Follow script is set to false
        if (other.gameObject.CompareTag("Child"))
        {
            ai.isActivate = false;
            ai.enabled =false;
            fetchCompleted = true;
            if (!aSource.isPlaying)
            {
                aSource.PlayOneShot(clip);
            }

        }
    }

}
