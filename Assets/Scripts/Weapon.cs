using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float shootingRange = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;





    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        PlayShootingAnimation();
        ProcessRaycast();


    }

    private void PlayShootingAnimation()
    {
        Animation  animation = GetComponent<Animation>();
        animation.Play();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, shootingRange))
        {
            CreateHitImpact(hit);
            print(hit.transform.name);
            // todo: add some hit FX
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.decreaseHealth(damage);

            }



        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy (impact, 2f);
    }
}
