using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robot : MonoBehaviour
{
    private GameObject player;
    public float distation;
    NavMeshAgent navAgent;
    public float radius = 20;

    private Collider mainCollider;
    private Animator animator;

    private int random;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        mainCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        distation = Vector3.Distance(player.transform.position, transform.position);

        if (distation > radius)
        {
            navAgent.enabled = false;
            animator.SetBool("isRunning", false);
        }

        else if (distation < 2.5f && distation > 2f)
        {
            animator.SetBool("isRunning", false);

        }

        else if (distation <= radius && distation > 2f)
        {
            navAgent.enabled = true;
            navAgent.SetDestination(player.transform.position);
            animator.SetBool("isRunning", true);
        }


    }

}
