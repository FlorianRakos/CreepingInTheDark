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
    [SerializeField] TextMeshProUGUI enemysKilledText;
    [SerializeField] TextMeshProUGUI pickupsFoundText;


    EnemyHealth[] enemysTotal;
    int pickupsTotal;
    int pickupsLeft;
    int enemysKilled = 0;

    


    void Start() {
        enemysTotal = FindObjectsOfType<EnemyHealth>();
        pickupsTotal = FindObjectsOfType<AmmoPickup>().Length + FindObjectsOfType<BatteryPickup>().Length; 
    }

    void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerHealth>() != null) {
            InitWinSequence();
        }
    }

    private void InitWinSequence()
    {
        ammoCanvas.enabled = false;
        background.enabled = true;
        WinCanvas.enabled = true;
        GenerateWinCanvasText();

        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        

    }

    private void GenerateWinCanvasText()
    {
        foreach (EnemyHealth enemy in enemysTotal) {
            if(enemy.GetComponent<EnemyAI>().enabled == false) {
                enemysKilled ++;
            }
        }

        pickupsLeft = FindObjectsOfType<AmmoPickup>().Length + FindObjectsOfType<BatteryPickup>().Length; 

        int pickupsFound = pickupsTotal - pickupsLeft;

        enemysKilledText.text = "Zombies killed: " + enemysKilled + "  out of " + enemysTotal.Length;
        pickupsFoundText.text = "Pickups found: " + pickupsFound + "  out of  " + pickupsTotal;
    }
}
