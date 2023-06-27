using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{   //This tells the computer to create a GameObject and what prefab to use
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newObject = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        Debug.Log(newObject.name);
    }
}
