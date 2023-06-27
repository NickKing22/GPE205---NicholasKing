using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //This is the variable that holds our pawn
    public Pawn pawn;

    

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    //The child classes have to override the way they process inputs
    public virtual void ProcessInputs()
        {
            
        }
}
