﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 30f;
    [SerializeField] float chaseRangeIncreaseOnPlayerShot = 5f;
    [SerializeField] float turnSpeed = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool hasPlayedProvokedSounds = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
        {
            EngageTarget();
            if (!hasPlayedProvokedSounds)
            {
                GetComponent<EnemySound>().PlayAlertedSounds();
                hasPlayedProvokedSounds = true;
            }

        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget <= navMeshAgent.stoppingDistance + .1f)
        {
            AttackTarget();
        }
        else
        {
            ChaseTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("move");
        GetComponent<Animator>().SetBool("attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.localRotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    public void IncreaseRange()
    {
        StartCoroutine(IncreaseChaseRange());
    }

    IEnumerator IncreaseChaseRange()
    {
        chaseRange += chaseRangeIncreaseOnPlayerShot;
        yield return new WaitForSeconds(.20f);
        chaseRange -= chaseRangeIncreaseOnPlayerShot;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
