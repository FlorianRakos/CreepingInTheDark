using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas gameOverCanvas;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverCanvas.enabled = false;
    }

    public void HandlePlayerDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        audioSource.enabled = false;
        FindObjectOfType<WeaponSwitcher>().enabled = false;

        Weapon[] weapons = FindObjectsOfType<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            weapon.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}