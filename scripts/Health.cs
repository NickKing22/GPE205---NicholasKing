using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // This is the float fo the max health
    public float maxHealth;

    // This is the float for the current health
    public float currentHealth;

    public void Die (Pawn source)
        {
            Destroy(gameObject);
        }
    //This is the function to take damage
    public void TakeDamage (float amount, Pawn source)
        {
            currentHealth = currentHealth - amount;
            Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);

            currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);

            if (currentHealth <=0)
                {
                    Die (source);
                }
        }

    

    // Start is called before the first frame update
    void Start()
    {
        //This sets the health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame draw
    void update()
        {
            
        }
}
