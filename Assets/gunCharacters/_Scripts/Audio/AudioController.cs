using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("volume"))
        {
            m_audioSource.volume = 1;
        }
    }

    private void Update()
    {
        m_audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
