using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerController : Controller
{
    // This is the KeyCode to move forward
    public KeyCode moveForwardKey;

    // This is the KeyCode to move backward
    public KeyCode moveBackwardkey;

    // This is the KeyCode to turn Right
    public KeyCode rotateClockwiseKey;

    // This is the KeyCode to turn left
    public KeyCode rotateCounterClockwiseKey;

    // This is the keycode to shoot
    public KeyCode shootKey;

    // This is the fireRate variable
    public float fireRate = 1.0f;

    // This is the variable for nextFire
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    public override void Start()
    {
        //Runs the Start() function of the parent class
        base.Start();
         // If we have a GameManager
        if (GameManager.instance != null) {
            // And it tracks the player(s)
            if (GameManager.instance.players != null) {
                // Register with the GameManager
                GameManager.instance.players.Add(this);
            }
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        //This will process our Keyboard inputs
        ProcessInputs();

        //This will run the Update() function from the parent class
        base.Update();

        if (Input.GetKeyDown(shootKey) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                pawn.Shoot();
            }
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

    // Function that removes the player from the list when destroyed
    public void OnDestroy()
    {
        // If we have a GameManager
        if (GameManager.instance != null) 
            {
                // And it tracks the player(s)
                if (GameManager.instance.players != null) 
                {
                    // Deregister with the GameManager
                    GameManager.instance.players.Remove(this);
                }
            }
    }
}
