using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 50f;
    [SerializeField] float moveSpeed = 50f;

    [SerializeField] Vector3 vectorUp;
    [SerializeField] Vector3 vectorW;
    [SerializeField] Vector3 vectorS;
    [SerializeField] Vector3 vectorA;
    [SerializeField] Vector3 vectorD;
    [SerializeField] Vector3 vectorQ;
    [SerializeField] Vector3 vectorE;
    [SerializeField] Vector3 position1;
    [SerializeField] Vector3 position2;
    [SerializeField] Vector3 position3;
    [SerializeField] Vector3 position4;

    Rigidbody rBody;
    AudioSource audioSource;
    Transform transformPlayer;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        transformPlayer = GetComponent<Transform>();
    } 

    void Update()
    {
        ProcessThrust();
        ProcessMovement();
        ProcessMovementXY();
    }

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rBody.AddRelativeForce(vectorUp * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

 
    }

    void ProcessMovement() 
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rBody.freezeRotation = true;
            transform.Rotate(vectorW * rotationThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rBody.freezeRotation = true;
            transform.Rotate(vectorA * rotationThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rBody.freezeRotation = true;
            transform.Rotate(vectorS * rotationThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rBody.freezeRotation = true;
            transform.Rotate(vectorD * rotationThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rBody.freezeRotation = true;
            transform.Rotate(vectorQ * rotationThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rBody.freezeRotation = true;
            transform.Rotate(vectorE * rotationThrust * Time.deltaTime);
        }
    }

    void ProcessMovementXY() 
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(position1 * moveSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(position2 * moveSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(position3 * moveSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(position4 * moveSpeed * Time.deltaTime, Space.World); 
        }
    } //No physics, does not work well.
}
