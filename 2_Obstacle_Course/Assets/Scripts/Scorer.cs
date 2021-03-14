using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    int hits = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Hit")
        {
            hits++; //OnCollisionEnter is a method that can provide info uppon collision with an object. ++ means + 1 everytime you hit something.
            Debug.Log("You've bumped into a thing this many times: " + hits);
        }
    }
}
