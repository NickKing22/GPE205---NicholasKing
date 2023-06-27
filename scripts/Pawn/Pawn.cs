using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Variable to hold our Mover
    public Mover mover;

    // Variable to hold our shooter
    public Shooter shooter;

    // Variable for our bullet prefab
    public GameObject bullet;

    // Variable for our firing force
    public float fireForce;

    // Variable for our damage done
    public float damageDone;

    // Variable for the lifespan of our bullet if they don't collide
    public float lifespan;

    // This is the variable for movement speed
    public float moveSpeed;
    
    //This is the variable for turn speed
    public float turnSpeed;

    // This is the variable for fireRate
    public float fireRate;

    public abstract void Shoot();

    public abstract void RotateTowards(Vector3 targetPosition);

    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
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
