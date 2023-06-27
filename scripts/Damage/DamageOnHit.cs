using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    // This is the float that will determine the amount of damage done
    public float damageDone;

    //This will tell the computer who to damage
    public Pawn owner;
    // Start is called before the first frame update

    // This is the function that will tell the computer that the object has collided with the rigidbody
    public void OnTriggerEnter(Collider other)
        {
            // This gets the Health Component from the Game Object that has the Collider that we are overlapping
            Health otherHealth = other.gameObject.GetComponent<Health>();

            // This tells the computer to only damage the object if it has health
            if (otherHealth != null)
                {
                    // Tells the computer to damage
                    otherHealth.TakeDamage(damageDone, owner);
                }

            //Destroy ourselves, whether we did damage or not
            Destroy(gameObject);
        }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
