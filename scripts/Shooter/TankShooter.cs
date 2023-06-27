using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;

    // Start is called before the first frame update
    public override void Start()
        {
        
        }

    // Update is called once per frame
    public override void Update()
        {
        
        }

    public override void Shoot(GameObject bullet, float fireForce, float damageDone, float lifespan)
    {
        // This Instantiates our bullet/projectile
        GameObject newBullet = Instantiate(bullet, firepointTransform.position, firepointTransform.rotation) as GameObject;

        // Get the DamageOnHit component
        DamageOnHit doh = newBullet.GetComponent<DamageOnHit>();

        // Tells the computer to check if it has one
        if (doh != null)
            {
                // Tells the computer to set the damageDone in the DamageOnHit component to the value passed in
                doh.damageDone = damageDone;

                // Tells the computer to set the owner to the pawn that shot this shell, if there is one (otherwise, owner is null)
                doh.owner = GetComponent<Pawn>();
            }

        // Tells the computer to get the rigidbody component
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        //Tells the computer to check if it has one
        if (rb != null)
            {
                // Add force to make it move
                rb.AddForce(firepointTransform.forward * fireForce);
            }

        // Destroys the bullet after a set time
        Destroy(newBullet, lifespan);


    }






}
