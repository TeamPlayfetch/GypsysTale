//--------------------------------------------------------------------------------------
// Purpose: The base script for all collectable objects.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// BaseCollectable object. Inheriting from MonoBehaviour. Base object for the collectable\
// objects.
//--------------------------------------------------------------------------------------
public class BaseCollectable : MonoBehaviour
{
    // ROTATING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Rotating:")]

    // public bool for if the collectable is going to rotate or not
    [LabelOverride("Has Rotation?")] [Tooltip("Will this collectable item have rotation?")]
    public bool m_bRotate;

    // public float value for the rotation speed
    [LabelOverride("Rotation Speed")] [Tooltip("The speed of which the collectable will rotate in float value.")]
    public float m_fRotateSpeed = -80.0f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // BOBBING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Bobbing:")]

    // public bool for if the collectable is going to bobb or not
    [LabelOverride("Has Bobbing?")] [Tooltip("Will this collectable item have bobbing?")]
    public bool m_bBobbing;

    // public float value for the bobbing force.
    [LabelOverride("Bobbing Force")] [Tooltip("The amount / speed the collectable will bob on the spot in float value.")]
    public float m_fBobbingForce = 0.1f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // AUDIO //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Audio:")]

    // public bool to give the option for audio or not.
    [LabelOverride("Has Pickup Audio?")] [Tooltip("Is there pickup audio for this collectable object?")]
    public bool m_bPickupAudio = false;

    // public audioclip for interaction audio.
    [LabelOverride("Pickup Audio")] [Tooltip("The audio clip for what will play when the collectable is picked up.")]
    public AudioClip m_acPickupAudio;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PARTICLES //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Particles:")]

    // public particle system for the collect particle
    [LabelOverride("Collect Particle")] [Tooltip("The particle effect to play once a collectable has been collected.")]
    public ParticleSystem m_psCollectParticle;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public hidden audio source
    [HideInInspector]
    public AudioSource m_asAudioSource;
    //--------------------------------------------------------------------------------------

    // PROTECTED VALUES //
    //--------------------------------------------------------------------------------------
    // protected bool for if this item has been collected by the player or not.
    protected bool m_bCollected = false;

    // protected float for the oringal starting postion of the collectable object.
    protected float m_fOriginalYPos;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    protected void Awake()
    {
        // Make sure collected starts as false.
        m_bCollected = false;

        // keep hold of the original postion of the collectable before bobbing.
        m_fOriginalYPos = transform.position.y;

        // set a random offset for rotation so groups of collectable dont all rotate at the same time.
        transform.rotation = Random.rotation;

        //if there is an audio clip on the object.
        if (m_bPickupAudio)
        {
            // get the audiosource component of the interactable object
            m_asAudioSource = GetComponent<AudioSource>();
        }
        
        // Instantiate the particle system for the collected visual
        m_psCollectParticle = Instantiate(m_psCollectParticle, transform.position, Quaternion.identity);

        // disable the particle system
        m_psCollectParticle.Stop();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    protected void Update()
    {
        // if rotate. // Rotate the collectable on the y axis
        if (m_bRotate)
            transform.Rotate(Vector3.up * m_fRotateSpeed * Time.deltaTime);

        // if bobbing. bobbing the collectable object up and down
        if (m_bBobbing)
            transform.position = new Vector3(transform.position.x, m_fOriginalYPos + ((float)Mathf.Sin(Time.time) * m_fBobbingForce), transform.position.z);

        // has the item been collected.
        if (m_bCollected)
        {
            // new float for particle duration.
            float fParticleDuration = m_psCollectParticle.duration + m_psCollectParticle.startLifetime;

            // Destroy the particle after played
            Destroy(m_psCollectParticle.gameObject, fParticleDuration);

            // turn off the box collider
            gameObject.GetComponent<BoxCollider>().enabled = false;

            // set active false for the mesh renderer.
            GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);
            
            // set collected bool back to false
            m_bCollected = false;
        }

        // if the audio isnt playing and the collectparticle is null or if there is no audio and the collect particle is null
        if (!m_asAudioSource.isPlaying && m_psCollectParticle == null || !m_bPickupAudio && m_psCollectParticle == null)
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    public void OnTriggerEnter(Collider cObject)
    {
        // If this object collides with the player
        if (cObject.tag == "Player")
        {
            // The item has been collected.
            m_bCollected = true;

            // if pickup audio is being used.
            if (m_bPickupAudio)
            {
                // Stop any previously playing audio
                if (m_asAudioSource.isPlaying)
                    m_asAudioSource.Stop();

                // Play Interaction Audio.
                m_asAudioSource.PlayOneShot(m_acPickupAudio);
            }

            // Enable the particle system for collected visual
            m_psCollectParticle.Play();
        }
    }
}