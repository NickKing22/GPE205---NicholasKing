using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Prefabs
    public GameObject PlayerControllerPrefab;
    public GameObject TankPawnPrefab;

    public Transform playerSpawnTransform;
    
    // List that holds our players
    public List<PlayerController> players;

    // Awake is called when the object is first created - before Start can run
    private void Awake ()
        {
            // If the instance doesn't exist yet
            if (instance == null)
                {
                    // This is the instance
                    instance = this;

                    // Don't destroy it if we load a new scene
                    DontDestroyOnLoad(gameObject);
                }
            else
                {
                    // Otherwise, there is already an instance, so destroy this gameObject
                    Destroy(gameObject);
                }

    
            
        }

    public void SpawnPlayer()
        {
            // Spawn the player controller
            GameObject newPlayerObj = Instantiate(PlayerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

            // Spawn the Pawn and connect it to the Controller
            GameObject newPawnObj = Instantiate(TankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

            // Spawn the pawn 
            Controller newController = newPlayerObj.GetComponent<Controller>();
            Pawn newPawn = newPawnObj.GetComponent<Pawn>();

            // This tells the computer to hook the pawn and controller together
            newController.pawn = newPawn;
        }
    
    void Start()
        {
            // Temp code 
            SpawnPlayer();
        }
}
