//--------------------------------------------------------------------------------------
// Purpose: Destroy particle.
//
// Description: This script destroys a particle after it has finished playing, to be 
// attached to an  object with a particle component.
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
// Destroy_Particles object. Inheriting from MonoBehaviour. Destroys a particle after a 
// set time.
//--------------------------------------------------------------------------------------
public class Destroy_Particles : MonoBehaviour
{
    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    IEnumerator Start()
    {
        // wait for 1 second after the duration of the particle
        yield return new WaitForSeconds (GetComponent<ParticleSystem>().duration + 1.0f);

        // destroy gameobject
        Destroy (gameObject);
	}
}