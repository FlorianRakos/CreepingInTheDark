using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float healthPoints = 100f;

    void Update()
    {
        FindObjectOfType<HealthBar>().adjustHealthbar(healthPoints);
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        FindObjectOfType<BloodSplatter>().paintBloodSplatter();

        if (healthPoints <= 0)
        {
            GetComponent<DeathHandler>().HandlePlayerDeath();
        }
    }

}
