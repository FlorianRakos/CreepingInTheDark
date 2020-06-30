using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] AudioClip[] AttackSounds;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void PlayAttackSound() {
        AudioClip myClip = GetRandomClip(AttackSounds);
        audioSource.PlayOneShot(myClip);
    }



    private AudioClip GetRandomClip(AudioClip[] clips) {
        int clipAmount = clips.Length;
        int random = Random.Range(0, clipAmount);


        print(random);
        AudioClip clip = clips[random];
        return clip;
    }

    

}
