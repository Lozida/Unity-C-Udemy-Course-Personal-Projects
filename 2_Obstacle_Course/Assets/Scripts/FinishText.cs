using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishText : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You Won! Congratulations! (Or maybe you didn't lol) :D");
    }
}
