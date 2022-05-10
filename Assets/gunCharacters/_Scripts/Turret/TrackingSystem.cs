using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;
 
    [HideInInspector] public GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    private void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () 
    {
        if(m_target)
        {
            if(m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
                //m_lookAtRotation = Quaternion.LookRotation(transform.position - m_lastKnownPosition);
            }
 
            if(transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }

    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }

}
