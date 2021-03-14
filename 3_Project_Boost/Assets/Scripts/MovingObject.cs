using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 moveVector;
    [SerializeField] [Range(0,1)] float moveFactor; // Gets a slider in unity form 0 to 1.
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPos = transform.position; // Creating a var of the current position of an object.
        Debug.Log(startingPos);
    }
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // Protecting from the NaN error (Not a number), because numbers cannot be divided by 0.
        float cycles = Time.time / period; // Continually growing over time.
        
        const float tau = Mathf.PI * 2; // Creating a constant variable of value 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // Going from -1 to 1

        moveFactor = (rawSinWave + 1f) / 2f; // Recalculated going from (-1 to 1) to (0 to 1)
        
        Vector3 offset = moveVector * moveFactor; // Creating an offset vector.
        transform.position = startingPos + offset; // Actually moving the object: The position of the object will become the starting postion + the offset.
    }
}
