using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public TankMover tankMover;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        tankMover = GetComponent<TankMover>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }

    public override void MoveForward()
        {
            mover.Move(transform.forward, moveSpeed);           
        }

    public override void MoveBackward()
        {
            mover.Move(transform.forward, -moveSpeed);
        }

    public override void RotateClockwise()
        {
            mover.Rotate(transform.up, turnSpeed);
        }

    public override void RotateCounterClockwise()
        {
            mover.Rotate(transform.up, -turnSpeed);
            
        }
    
    public override void Shoot()
        {
            shooter.Shoot(bullet, fireForce, damageDone, lifespan);
        }
    

// The following is the code for the AI Tanks
    


    // This is the code to tell the computer what it means to RotateTowards
    public override void RotateTowards(Vector3 targetPosition)
    {
        // Find the vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;
        // Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        // Rotate closer to that vector, but don't rotate more than our turn speed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
