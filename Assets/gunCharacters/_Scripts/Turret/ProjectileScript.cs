using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float lifetime = 2f;

    private GameObject target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        Quaternion.Euler(target.transform.position);
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall_floor") || other.CompareTag("Enemy") || other.CompareTag("mainEnemy"))
        {
            gameObject.SetActive(false);
        }

    }

}
