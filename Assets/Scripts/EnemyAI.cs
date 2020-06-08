using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 30f;
    [SerializeField] float turnSpeed = 10f;

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
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
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

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.localRotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        //Gizmos.color= new Color (1, 0, 1, 0.5f);
        //Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
    }


}
