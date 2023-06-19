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
            //rb.AddForce(transform.forward * .1f, ForceMode.Impulse);
            mover.Move(transform.forward, moveSpeed);           
        }

    public override void MoveBackward()
        {
            //rb.AddForce(-transform.forward * .1f, ForceMode.Impulse);
            mover.Move(transform.forward, -moveSpeed);
        }

    public override void RotateClockwise()
        {
            mover.Rotate(transform.up, turnSpeed);
        }

    public override void RotateCounterClockwise()
        {
            mover.Rotate(transform.up, -turnSpeed);
            
           // Vector3 torque = new Vector3(0f, 50f, 0f);
            //rb.AddTorque(torque, ForceMode.Impulse);
        }
    
}
