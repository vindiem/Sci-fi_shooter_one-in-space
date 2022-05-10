using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_light : MonoBehaviour
{
    private GameObject m_light; 
    public AudioSource on_light_SFX;

    private void Start()
    {
        m_light = GameObject.FindGameObjectWithTag("light");
        m_light.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_light != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                m_light.gameObject.SetActive(true);
                on_light_SFX.Play();
            }
            else if (Input.GetKeyUp(KeyCode.X))
            {
                m_light.gameObject.SetActive(false);
                on_light_SFX.Play();
            }
        }
    }
}
