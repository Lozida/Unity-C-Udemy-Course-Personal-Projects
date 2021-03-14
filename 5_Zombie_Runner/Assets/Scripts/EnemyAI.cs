using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseDistance = 5f;
    [SerializeField] float chaseRange = 10f;
    
    NavMeshAgent navMeshAgent; // Getting the NavMeshAgent component from UnityEngine.AI.
    float distanceToTarget = Mathf.Infinity; // Infinite number.
    bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); // .Distance = returns the value of A to B.
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseDistance)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + "has seeked and is destroying" + target.name);
    }

    void OnDrawGizmosSelected() // Creating a sphere that shows the distance between enemy and player.
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

