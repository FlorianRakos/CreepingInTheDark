using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnPlayer : MonoBehaviour
{
    [SerializeField] AudioClip ammoPickup;
    [SerializeField] AudioClip batteryPickup;
    [SerializeField] AudioClip carStarting;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playAmmoPickupSound() {
        audioSource.PlayOneShot(ammoPickup);
    }

    public void playBatteryPickupSound() {
        audioSource.PlayOneShot(batteryPickup);
    }

    public void playCarStartingSound() {
        audioSource.PlayOneShot(carStarting);
    }
}
