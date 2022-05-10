using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mainEnemy : MonoBehaviour
{
    public float health = 100;

    private GameObject player;
    public float distation;
    NavMeshAgent navAg;
    public float radius = 15;

    public Animator anim;
    public Collider collider;
    public Collider trigger;

    private Rigidbody zombieRb;

    private void Start()
    {
        zombieRb = GetComponent<Rigidbody>();
        navAg = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        distation = Vector3.Distance(player.transform.position, transform.position);
        if (distation > radius)
        {
            navAg.enabled = false;
            anim.SetBool("isRunning", false);
        }

        else if (distation <= radius && distation > 2.5f)
        {
            navAg.enabled = true;
            navAg.SetDestination(player.transform.position);
            anim.SetBool("isRunning", true);
        }

        if (distation < 2f)
        {
            anim.SetTrigger("attack");
        }

        if (health <= 0)
        {
            trigger.enabled = false;
            collider.enabled = false;
            navAg.enabled = false;
            anim.SetTrigger("dead");
            Destroy(gameObject, 2f);
        }

    }
}