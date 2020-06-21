using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float shootingRange = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = .3f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] bool canShoot = true;
    [SerializeField] TextMeshProUGUI ammoText;


    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }

        DisplayAmmo();

    }

    private void DisplayAmmo()
    {
       int ammoAmount = ammoSlot.GetCurrentAmmo(ammoType);
       ammoText.text = ammoAmount.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            PlayShootingAnimation();
            ProcessRaycast();
        }
        // else play click sound  

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void PlayShootingAnimation()
    {
        //Animation  animation = GetComponent<Animation>();
        //animation.Play();
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
            //print(hit.transform.name);
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
        Destroy(impact, 2f);
    }

    
}
