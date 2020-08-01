using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] Image lightAmmoIcon, heavyAmmoIcon, shellIcon;

    [SerializeField] AudioClip weaponShootingAudio;
    [SerializeField] bool isFullyAutomatic = false;

    [SerializeField] ParticleSystem bloodVFX;

    AudioSource audioSource;


    private void OnEnable()
    {
        canShoot = true;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isFullyAutomatic)
        {
            if (Input.GetMouseButton(0) && canShoot)
            { StartCoroutine(Shoot()); }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            { StartCoroutine(Shoot()); }
        }


        DisplayAmmo();

    }

    private void DisplayAmmo()
    {
        int ammoAmount = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = ammoAmount.ToString();

        switch (ammoType) {
            case AmmoType.Lightammo:
                lightAmmoIcon.enabled = true;
                heavyAmmoIcon.enabled = false;
                shellIcon.enabled = false;
            break;
            case AmmoType.Heavyammo:
                lightAmmoIcon.enabled = false;
                heavyAmmoIcon.enabled = true;
                shellIcon.enabled = false;
            break;
            case AmmoType.Shells:
                lightAmmoIcon.enabled = false;
                heavyAmmoIcon.enabled = false;
                shellIcon.enabled = true;
            break;
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            PlayShootingAnimation();
            PlayShootingAudio();
            ProcessRaycast();
        }
        // else play click sound  

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void PlayShootingAudio()
    {
        audioSource.PlayOneShot(weaponShootingAudio);
    }

    private void PlayShootingAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("shoot");
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
                if(hit.collider.GetType() == typeof(SphereCollider)) {
                    target.decreaseHealth(damage * 5f);
                } else {
                  target.decreaseHealth(damage);  
                }
                

            }



        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        Transform hitTransform = hit.collider.gameObject.transform;

        if (hit.collider.gameObject.GetComponent<EnemyHealth>())
        {
            var impact = Instantiate(bloodVFX, hit.point, Quaternion.LookRotation(hit.normal));

            impact.transform.parent = hitTransform;
            var main = impact.main;

            main.simulationSpace = ParticleSystemSimulationSpace.Custom;
            main.customSimulationSpace = hitTransform;

            hitTransform.gameObject.GetComponent<EnemySound>().PlayHitImpactSound();

            Destroy(impact, 2f);
        }
        else
        {
            var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }

    }


}
