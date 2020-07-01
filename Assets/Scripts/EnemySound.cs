using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] AudioClip[] AttackSounds;
    [SerializeField] AudioClip[] IdleSounds;
    [SerializeField] float minTime = 5f;
    [SerializeField] float maxTime = 15f;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayIdleSounds());
    }

    
    public void PlayAttackSound() {
        AudioClip myClip = GetRandomClip(AttackSounds);
        audioSource.PlayOneShot(myClip);
    }



    private AudioClip GetRandomClip(AudioClip[] clips) {
        int clipAmount = clips.Length;
        int random = Random.Range(0, clipAmount);

        AudioClip clip = clips[random];
        return clip;
    }

    IEnumerator PlayIdleSounds () {
        float idleRange = (Random.Range(minTime, maxTime));

        yield return new WaitForSeconds(idleRange);
        AudioClip myClip = GetRandomClip(IdleSounds);
        audioSource.PlayOneShot(myClip);

        if(GetComponent<EnemyAI>().enabled) {
            StartCoroutine(PlayIdleSounds());
        }
    }
    

}
