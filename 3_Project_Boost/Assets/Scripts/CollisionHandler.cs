using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    Movement moveScript;
    Rigidbody rBody;

    [SerializeField] float timeDelay = 2f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool isTransitioning = false; // Created a bool var to make sure when we start loading next lvl that nothing except that happens. 

    void Start()
    {
        moveScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheatKeys();
    }

    void CheatKeys() // Created a method for cheating or debugging while in game.
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rBody.useGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            rBody.useGravity = true;
        }
    }

    void OnCollisionEnter(Collision other) // Collision = collision, other = what is the other thing we collided with?
    {
        if (isTransitioning == false) // Using the bool var.
        {
            switch(other.gameObject.tag)
            {
                 case "Friendly": // Friendly is the tag (other name sort of) of a friendly object.
                    Debug.Log("This thing is friendly");
                    break;
                 case "Finish": // Finish is the tag (other name sort of) of the finish pad etc.
                    StartSuccessSequence();
                    break;
                 default:
                    StartCrashSequence();
                    break;
            }
        }

    }

    void StartSuccessSequence() 
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        successParticles.Play(); // Activating the particles.
        moveScript.enabled = false;
        Invoke("LoadNextLevel", timeDelay);

    }

    void StartCrashSequence() //To Do: Add sound and particle effect.
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound); // I tu se ponavlja zvuk.
        crashParticles.Play();
        moveScript.enabled = false;
        Invoke("ReloadLevel", timeDelay);
    }

    void ReloadLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // Its reloading the level and returning the index (number) of the scene.
    }

    void LoadNextLevel() // A method designed to load the next level (code is identical to ReloadLevel exepet we added +1) and restart if we have gone through all the lvls.
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSeceneIndex = currentSceneIndex + 1;
        if (nextSeceneIndex == SceneManager.sceneCountInBuildSettings) //If the nextSceneIndex is the same as the number of the total scenes we have, then restart.
        {
            nextSeceneIndex = 0;
        }
        SceneManager.LoadScene(nextSeceneIndex);
    }
}
