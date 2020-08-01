using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnPlayer : MonoBehaviour
{
    [SerializeField] AudioClip ammoPickup;
    [SerializeField] AudioClip batteryPickup;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAmmoPickupSound() {
        audioSource.PlayOneShot(ammoPickup);
        print("should play");
    }

    public void playBatteryPickupSound() {
        audioSource.PlayOneShot(batteryPickup);
    }
}
