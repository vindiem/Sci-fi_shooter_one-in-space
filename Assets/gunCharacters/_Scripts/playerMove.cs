using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Collider collider;
    private GameObject owner;
    Rigidbody Orb;

    private void Start()
    {
        collider = GetComponent<Collider>();
        owner = GetComponentInParent<GameObject>();
        Orb = owner.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Orb == false)
        {
            Destroy(gameObject);
            Destroy(collider);
        }
    }

}
