using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Player") // USING TAGS: once the player or something is tagged you can access it in code.
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
        
    }
}

// This method lets us know in the console when we hit something 
// + it allows us to get the MeshRenderer Component available in our code to then change the material.color to red.