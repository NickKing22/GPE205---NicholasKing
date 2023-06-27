using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AiController : Controller
{
    public GameObject target;

    // This is the enum for the AIState
    public enum AIState {Guard, Chase, Flee, Patrol, Attack, Scan, BackToPost, Idle};

    // This is the variable for the current state of the AI
    public AIState currentState;

    // This is the float for the lastStateChangeTime
    private float lastStateChangeTime;

    // This is the float for flee distance
    public float fleeDistance;

    // This is the integer for the waypoint
    private int currentWaypoint = 0;

    // These are the variables for the waypoints
    public Transform[] waypoints;
    public float waypointStopDistance;


    // Start is called before the first frame update
    public override void Start()
    {
        // Run the parent (Base) Start
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Make decisions
        MakeDecisions();
        
        // Run the parent (Base) update
        base.Update();
    }

    // This is the function for the AI to be have the ability to change states
    public virtual void ChangeState (AIState newState)
        {
            // Change the current state
            currentState = newState;
            // Save the time when we changed states
            lastStateChangeTime = Time.time;
        }

    public void MakeDecisions()
        {
            switch  (currentState)
                {
                    case AIState.Idle:
                        // Do Work
                        DoIdleState();
                        // Check for transitions
                        if (IsDistanceLessThan(target, 10))
                            {
                                ChangeState(AIState.Chase);
                                pawn.Shoot();
                            }
                        break;
                    
                    case AIState.Chase:
                        // Do Work
                        DoChaseState();
                        
                        // Check for transitions
                        if (!IsDistanceLessThan( target, 10))
                            {
                                ChangeState(AIState.Idle);
                            }
                        break;
                }
        }

    protected virtual void DoAttackState()
        {
            // Chase
            Seek(target);
            // Shoot
            pawn.Shoot();
        }
    // This is the seek function that uses a GameObject
    public void Seek(GameObject targetObject)
        {
            // Rotate towards the Function
            pawn.RotateTowards(targetObject.transform.position);
            // Tells the pawn to move forward
            pawn.MoveForward();
        }

    // This is the Seek function that uses a Vector3
    public void Seek(Vector3 targetPosition)
        {
            // RotateTowards the function
            pawn.RotateTowards(targetPosition);
            // Tells the pawn to move forward
            pawn.MoveForward();
        }

    // This is the seek function that uses a targetTransform
    public void Seek(Transform targetTransform)
        {
            // Seek the position of our target transform
            Seek(targetTransform.position);
        }
    
    // This is the seek function for a pawn
    public void Seek(Pawn targetPawn)
        {
            // Seek the pawn's transform
            Seek(targetPawn.transform);
        }

    // This is the code for the tank to "Seek" the player
    public void DoSeekState()
        {
            // Seek for the target
            Seek(target);
        }

    // This is the function for the Chase state
    protected virtual void DoChaseState()
        {
            Seek(target);
        }

    // This is the function for the Idle State
    protected virtual void DoIdleState()
        {
            // Do Nothing
        }

    // This is the function for Flee
    protected void Flee()
    {
        // Find the Vector to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        // Find the Vector away from our target by multiplying by -1
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        // Find the vector we would travel down in order to flee
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        // Seek the point that is "fleeVector" away from our current position
        Seek(pawn.transform.position + fleeVector);
    }

    // This is the function for the patrol
    protected void patrol()
        {
            // If we have enough waypoints in our list to move to a current waypoint
            if (waypoints.Length > currentWaypoint)
                {
                    // Then seek that waypoint
                    Seek(waypoints[currentWaypoint]);
                    // If we are close enough, then increment to the next waypoint
                    if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
                        {
                            currentWaypoint++;
                        }
                }
            else 
                {
                    RestartPatrol();
                }
        }
    // This defines what RestartPatrol is
    protected void RestartPatrol()
        {
            // Set the index to 0
            currentWaypoint = 0;
        }
        

    // This is the function to check the distance between any two points
    protected bool IsDistanceLessThan(GameObject target, float distance)
        {
            if (Vector3.Distance (pawn.transform.position, target.transform.position) < distance )
                {
                    return true;
                }
            else
                {
                    return false;
                }
        }




    // This is the function that tells the AI to find the player position
    public void TargetPlayerOne()
        {
            // If the GameManager exists
            if (GameManager.instance != null)
                {
                    // and the array of players exists
                    if (GameManager.instance.players != null)
                        {
                            // Then target the gameObject of the pawn of the first player controller in the list
                            target = GameManager.instance.players[0].pawn.gameObject;
                        }
                }
        }
    // This is the boolean that checks if it has a target
    protected bool IsHasTarget()
        {
            // return true if we have a target, false if we don't
            return (target != null);
        }

    // This is the code to target the nearest tank
    protected void TargetNearestTank()
    {
        // Get a list of all the tanks (pawns)
        Pawn[] allTanks = FindObjectsOfType<Pawn>();

        // Assume that the first tank is closest
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTanks) {
            // If this one is closer than the closest
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance ) 
                {
                    // It is the closest
                    closestTank = tank;
                    closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
                } 
        }

        // Target the closest tank
        target = closestTank.gameObject;
    }

    // This is the function that allows the AI to "hear" the player
        public bool CanHear(GameObject target, float hearingDistance)
    {
        // Get the target's NoiseMaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // If they don't have one, they can't make noise, so return false
        if (noiseMaker == null) 
        {
            return false;
        }
        // If they are making 0 noise, they also can't be heard
        if (noiseMaker.volumeDistance <= 0) 
        {
            return false;
        }
        // If they are making noise, add the volumeDistance in the noisemaker to the hearingDistance of this AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // If the distance between our pawn and target is closer than this...
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance) 
        {
            // ... then we can hear the target
            return true;
        }
        else 
        {
            // Otherwise, we are too far away to hear them
            return false;
        }
    }

    // This is the function that creates a field of view for the AI
    public bool CanSee(GameObject target, float fieldOfView)
    {
        // Find the vector from the agent to the target
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        // if that angle is less than our field of view
        if (angleToTarget < fieldOfView) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }





}
