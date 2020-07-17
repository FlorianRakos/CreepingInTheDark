using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnPlayer : MonoBehaviour
{
    [SerializeField] AudioClip ammoPickup;
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
}
