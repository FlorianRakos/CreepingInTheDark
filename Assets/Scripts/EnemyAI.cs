using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 30f;


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    



    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked) {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }        
    }

    private void EngageTarget()
    {
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        } else {
            ChaseTarget();
        }
        
    }

    private void AttackTarget()
    {
        print("atacking Player");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);;
    }


    void OnDrawGizmosSelected() {
        Gizmos.color= new Color (1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        //Gizmos.color= new Color (1, 0, 1, 0.5f);
        //Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
    }
}
