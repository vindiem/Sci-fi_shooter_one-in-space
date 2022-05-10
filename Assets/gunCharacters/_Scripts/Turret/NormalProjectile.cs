using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : BaseProjectile
{
    Vector3 m_direction;
    bool m_fired;


    private void Update()
    {
        if (m_fired)
        {
            transform.position -= m_direction * (speed * Time.deltaTime);
        }

    }

    public override void FireProjectile(GameObject target, GameObject launcher, int damage)
    {
        if (launcher && target)
        {
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
        }
    }
}
