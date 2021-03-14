using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed;
    [SerializeField] float xRange = 10.5f;
    [SerializeField] float yRange = 8f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers; // Getting access to the game object (lasers (also could have used partical sys)), making it an array with [].

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionRollFactor = 5f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlYawFactor = -10f;


    float xThrow, yThrow;
    void Start()
    {
        Debug.Log("Controls: WASD to move and CTRL or LMB to shoot.");
        Debug.Log("Joystick Controls: Left Thumbstick to move and X or A to shoot. ");
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        ExitGame();
    }

    void ProcessRotation() 
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = xThrow * controlYawFactor;
        float roll = transform.localPosition.x * positionRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float offsetX = xThrow * Time.deltaTime * controlSpeed;
        float offsetY = yThrow * Time.deltaTime * controlSpeed;

        float rawXPos = transform.localPosition.x + offsetX; // Creating a new var for a new position on the X axis + the offset of the x axis.
        float rawYPos = transform.localPosition.y + offsetY;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //Transforming our local pos (current pos) to a new pos.
    }

    void ProcessFiring() // If pushing button, shoot, else do not.
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else 
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive) // Creating a bool so that when true the emisson for the lasers turns on.
    {
        foreach (GameObject laser in lasers)  // For each laser (original newly created var) in our array called lasers, activate the emisson.
        { 
            var emissonModule = laser.GetComponent<ParticleSystem>().emission;
            emissonModule.enabled = isActive;

        }
    }

    void ExitGame() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

}

