using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public int health = 250;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
