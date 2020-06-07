using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    


    // public method
    public void decreaseHealth (float decrease) {
        hitPoints -= decrease;

        if (hitPoints <= 0) {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
