using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEnd : MonoBehaviour
{
    [SerializeField] Canvas WinCanvas;
    [SerializeField] Canvas ammoCanvas;
    [SerializeField] Canvas background;
    [SerializeField] Canvas batteryCanvas, healthCanvas;

    [SerializeField] TextMeshProUGUI enemysKilledText;
    [SerializeField] TextMeshProUGUI pickupsFoundText;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource ambientSounds;


    EnemyHealth[] enemysTotal;
    int pickupsTotal;
    int pickupsLeft;
    int enemysKilled = 0;

    void Start()
    {
        enemysTotal = FindObjectsOfType<EnemyHealth>();
        pickupsTotal = FindObjectsOfType<AmmoPickup>().Length + FindObjectsOfType<BatteryPickup>().Length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            animator.SetTrigger("FadeStart");
            StartCoroutine(FadeOutSounds());
            StartCoroutine(InitWinSequence());
            FindObjectOfType<SoundOnPlayer>().playCarStartingSound();

            FindObjectOfType<PlayerHealth>().GetComponent<AudioSource>().enabled = false;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            Weapon[] weapons = FindObjectsOfType<Weapon>();
            foreach (Weapon weapon in weapons)
            { weapon.enabled = false; }
        }
    }

    IEnumerator InitWinSequence()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0f;
        animator.SetTrigger("FadeEnd");

        ammoCanvas.enabled = false;
        batteryCanvas.enabled = false;
        healthCanvas.enabled = false;

        background.enabled = true;
        WinCanvas.enabled = true;

        GenerateWinCanvasText();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator FadeOutSounds()
    {
        float fadeOutTime = 1.9f;
        float startVolume = ambientSounds.volume;

        while (ambientSounds.volume > 0)
        {

            ambientSounds.volume -= startVolume * Time.unscaledDeltaTime / fadeOutTime;
            yield return null;
        }
    }

    private void GenerateWinCanvasText()
    {
        foreach (EnemyHealth enemy in enemysTotal)
        {
            if (enemy.GetComponent<EnemyAI>().enabled == false)
            {
                enemysKilled++;
            }
        }
        pickupsLeft = FindObjectsOfType<AmmoPickup>().Length + FindObjectsOfType<BatteryPickup>().Length;
        int pickupsFound = pickupsTotal - pickupsLeft;

        enemysKilledText.text = "Zombies killed: " + enemysKilled + "  out of " + enemysTotal.Length;
        pickupsFoundText.text = "Pickups found: " + pickupsFound + "  out of  " + pickupsTotal;
    }
}
