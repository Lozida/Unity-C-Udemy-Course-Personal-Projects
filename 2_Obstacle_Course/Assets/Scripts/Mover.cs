using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    void Start()
    {
        PrintInstructions();
    }

    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions() //void = no return value.
    {
        Debug.Log("Welcome to the game.");
        Debug.Log("Use WASD or arrow keys to move.");
        Debug.Log("Try not to hit the walls.");
    }

    void MovePlayer() 
    {
        //Input.GetAxis("Horizontal") -> Gets user input from input manager, gets the axis and you decide between Horizontal and Vertical.
        //We stored the Input.GetAxis method into a variable for cleaner code.
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(-xValue, 0, -zValue);
    }

}
