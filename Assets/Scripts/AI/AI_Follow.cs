using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Follow : MonoBehaviour {
    // A public target for the AI to follow
    public Transform target;

    // The private positon of this object
    private Transform myTransform;

    // A public value to tweak how fast the AI will follow the player
    public int speed;

    // A private value to calculate the distance between target and AI
    public float distance;

    // A private bool that checks whether the AI should follow the target or not
    public bool isActivate = false;

    private void Awake()
    {
       // Makes the value myTransform equal to the value of this object
        myTransform = transform;
    }

    private void Update()
    {
        // When the bool isActive equals true then run the function Follow Player
        if (isActivate == true)
        {
            FollowPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the other GameObject entering the collder is tagged "Player" then switch the bool isActive to true
        if (other.gameObject.CompareTag("Player"))
        {
            isActivate = true;
        }
    }

    void FollowPlayer()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.red);

        // Makes the value "distance" equal to the distance between the target and the gameobject itself
        distance = Vector3.Distance(target.position, myTransform.position);

        // If the distance between the two objects is greater than or equal to 3 make
        // the game object look at the target and move the object towards the target
        if (distance >= 3)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Otherwise still make the gameobject look at the target but stop all movement
        else
        {
            transform.LookAt(target);
            transform.Translate(Vector3.zero);
        }
    }

}
