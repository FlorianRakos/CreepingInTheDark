using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas gameOverCanvas;

    private void Start () {
        gameOverCanvas.enabled = false;
    }

    public void HandlePlayerDeath () {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
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
