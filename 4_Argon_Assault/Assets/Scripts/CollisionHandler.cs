using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay;
    [SerializeField] ParticleSystem crashVFX; // Getting a reference to the particle sys.
    AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        audioSource = GetComponent<AudioSource>();
        StartCrashSequence(); // Starting the crash sequence.
    }

    void StartCrashSequence()
    {
        audioSource.Play();
        GetComponent<BoxCollider>().enabled = false; // When we crash turn off box collider so no more explosion occur.
        crashVFX.Play(); // Playing / Activating the explosion particles.
        GetComponent<MeshRenderer>().enabled = false; // Disable the mesh renderer.
        GetComponent<PlayerControls>().enabled = false; // Getting the component of the PlayerControls script attached to the player.
        Invoke("ReloadLevel", loadDelay); // Reloading the level with a editable delay.
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Storing the index of the current scene/level to a int type variable.
        SceneManager.LoadScene(currentSceneIndex); // Loading the level.
    }
}
