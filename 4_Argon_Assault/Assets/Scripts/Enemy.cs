using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scoreVar;
    [SerializeField] int hitPoints = 5;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Looks through the entire project and the very first ScoreBoard it finds, that is the ScoreBoard we are reffering to.
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddingRigidbody();

    }

    private void AddingRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProccessHit();
        if (hitPoints < 1) 
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(scoreVar);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        DestroyGameObject();
    }

    private void ProccessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;

        hitPoints--; // Take the thing that we have and subtract 1 from it.
        scoreBoard.IncreaseScore(scoreVar); 
    }

    void DestroyGameObject() 
    {
        Destroy(gameObject);
    }
}
