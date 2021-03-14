using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticlesLeft;
    [SerializeField] ParticleSystem mainEngineParticlesRight;

    Rigidbody rBody; // Making a rigidbody member variable (Announcing that we are storing Rigidbody into a variable of our own choice (rBody).
    AudioSource audioSource;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();  // Getting the rigidbody component into the rBody var so that it is available to us when coding.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); //(0, 1, 0) = Vector3.up
        if (!audioSource.isPlaying) // Basically means that if the audio clip is not playing then play it (! means not).
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticlesLeft.isPlaying)
        {
            mainEngineParticlesLeft.Play();
        }
        if (!mainEngineParticlesRight.isPlaying)
        {
            mainEngineParticlesRight.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticlesLeft.Stop();
        mainEngineParticlesRight.Stop();
    }

    void ProcessRotation()
    {
        StartRotating();
    }

    void StartRotating()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust); // We made a method called ApplyRotation for easier reading of the code.
        }
        else if (Input.GetKey(KeyCode.D)) // This else if is here instead of just an if statement because we dont want to be able to rotate l & r at the same time.
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame) // The float in () means we are creating a var of type float and expecting to recieve some info back when we call the method.
    {
        rBody.freezeRotation = true; // Freezing rotation so we can manually rotate (fixing bugs).
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rBody.freezeRotation = false; // Unfreezing rotation so the physics system can take over. 
    }
}
