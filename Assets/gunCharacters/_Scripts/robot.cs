using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robot : MonoBehaviour
{
    public GameObject player;
    public float distation;
    NavMeshAgent navAgent;
    public float radius = 20;

    private Collider mainCollider;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        mainCollider = GetComponent<Collider>();

        //mainCollider.enabled = false;
    }

    private void Update()
    {
        distation = Vector3.Distance(player.transform.position, transform.position);

        if (distation > radius)
        {
            navAgent.enabled = false;
        }

        else if (distation <= radius && distation > 2f)
        {
            navAgent.enabled = true;
            navAgent.SetDestination(player.transform.position);
        }


    }

}
