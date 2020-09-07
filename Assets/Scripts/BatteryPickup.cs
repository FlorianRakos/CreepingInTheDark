using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PickUpBattery();
        }
    }

    private void PickUpBattery()
    {
        FindObjectOfType<FlashLight>().IncreaseBatteryCharge();
        FindObjectOfType<SoundOnPlayer>().playBatteryPickupSound();
        Destroy(gameObject);
    }
}
