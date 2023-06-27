using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once every frame draw
    public abstract void Update();

    //This tells the computer to create a bullet, how fast the bullet travels, and how long the bullet should be in the scene before it deletes from the world
    public abstract void Shoot(GameObject bullet, float fireForce, float damageDone, float lifespan);

}
