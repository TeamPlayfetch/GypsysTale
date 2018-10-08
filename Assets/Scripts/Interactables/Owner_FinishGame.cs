using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


public class Owner_FinishGame : MonoBehaviour {

    public bool activitiesCompleted = false;

    public GameObject owner;

    [Header("Checks")]
    Parent uiParent;
    ButterflyManager butterfly;
    Hotdog hotdog;
    Frisbee frisbee;
    PhotoBomb photo;


    private void Awake()
    {
        uiParent = FindObjectOfType<Parent>();
        butterfly = FindObjectOfType<ButterflyManager>();
        hotdog = FindObjectOfType<Hotdog>();
        frisbee = FindObjectOfType<Frisbee>();
        photo = FindObjectOfType<PhotoBomb>();
    }

    private void Update()
    {
        if (activitiesCompleted == true)
        {
            OwnerAppear();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (XCI.GetButton(XboxButton.B))
            {
                Ending();
            }
        }
    }

    void AllChecksComplete()
    {
        if (uiParent.fetchCompleted == true && butterfly.buttersComplete == true)
        {
            activitiesCompleted = true;
        }
    }


    void OwnerAppear()
    {
        owner.SetActive(true);
    }

    void Ending()
    {
        // change camera to set cam
        // trigger player/owner animation
        // trigger audio
        // fade to black animation
        // pull up finish screen
    }

}
