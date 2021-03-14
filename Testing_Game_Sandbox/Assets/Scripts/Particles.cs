using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        ProcessParticles();
    }
    void ProcessParticles()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            meshRenderer.enabled = true;
        }
        else 
        {
            meshRenderer.enabled = false;
        }
        
    }
}
