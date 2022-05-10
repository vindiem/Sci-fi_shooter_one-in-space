using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerRB : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }

        else if (other.CompareTag("mainEnemy"))
        {
            var mainrb = other.GetComponent<Rigidbody>();
            mainrb.isKinematic = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }

        else if (other.CompareTag("mainEnemy"))
        {
            var mainrb = other.GetComponent<Rigidbody>();
            mainrb.isKinematic = true;
        }
    }

}
