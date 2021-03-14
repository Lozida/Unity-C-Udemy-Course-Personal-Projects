using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Getting the fire button.
        {
            Shoot(); // Shoot method.
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();

    }

    private void ProcessRaycast()
    {
        RaycastHit hit; // Creating a RaycastHit var.
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) // If is for protection againts null reference error.
        {
            CreateHitImpact(hit);
            Debug.Log("You hit: " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    private void PlayMuzzleFlash() 
    {
        muzzleFlash.Play();
    }
}
