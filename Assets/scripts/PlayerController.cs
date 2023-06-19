using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardkey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;




    // Start is called before the first frame update
    public override void Start()
    {
        //Runs the Start() function of the parent class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //This will process our Keyboard inputs
        ProcessInputs();

        //This will run the Update() function from the parent class
        base.Update();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
            {
                pawn.MoveForward();
            }
        if (Input.GetKey(moveBackwardkey))
            {
                pawn.MoveBackward();
            }
        if (Input.GetKey(rotateClockwiseKey))
            {
                pawn.RotateClockwise();
            }
        if (Input.GetKey(rotateCounterClockwiseKey))
            {
                pawn.RotateCounterClockwise();
            }
    }
}
