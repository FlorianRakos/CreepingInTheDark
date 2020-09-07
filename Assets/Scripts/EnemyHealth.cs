using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void decreaseHealth(float decrease)
    {
        hitPoints -= decrease;
        BroadcastMessage("OnDamageTaken");
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
    }
}
