using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    public float turnSpeed;
    //Variable to hold the Rigidbody Component
    public Rigidbody rb;
    
    // Start is called before the first frame update
    public override void Start()
        {
            //Get the Rigidbody component
             rb = GetComponent<Rigidbody>();
             
        }
    public override void Move(Vector3 direction, float speed)
        {
            Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + moveVector);
        }
    public override void Rotate(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        //rb.MovePosition(rb.position + moveVector);

        
        Vector3 torque = new Vector3(0f, -50f, 0f);
        rb.AddTorque(moveVector, ForceMode.Impulse);
    }
}
