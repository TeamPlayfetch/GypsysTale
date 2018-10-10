using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour {

    public float moveSpeed;
    public float speedMax;
    public float speedMin;

    private void Start()
    {
        moveSpeed = Random.Range(speedMin,speedMax);
    }

    private void Update()
    {
        Movement();

    }

    void Movement()
    {
        transform.Translate(Vector3.forward * moveSpeed);
  
    }

}
