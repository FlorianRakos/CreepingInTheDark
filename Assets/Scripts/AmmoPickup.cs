using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpAmmo();
        }
    }

    private void PickUpAmmo()
    {
        FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
        FindObjectOfType<SoundOnPlayer>().playAmmoPickupSound();
        Destroy(gameObject);
    }
}
