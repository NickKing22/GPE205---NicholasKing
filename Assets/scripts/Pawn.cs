using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Variable to hold our Mover
    public Mover mover;

    //This is the variable for movement speed
    public float moveSpeed;
    
    //This is the variable for turn speed
    public float turnSpeed;


    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }


    //These are the basic movement variables that the child classes will call upon
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
