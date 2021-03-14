using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidB;
    [SerializeField] float timeToWait = 5f;

    private void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();

        renderer.enabled = false;
        rigidB.useGravity = false;
    }

    void Update()
    {
        if (Time.time > timeToWait) 
        {
            renderer.enabled = true;
            rigidB.useGravity = true;
        }
    }
}
 //Using the if statement in order to use Time.time