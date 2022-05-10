using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider m_slider;
    public float o_m_volume;

    private void Start()
    {
        o_m_volume = m_slider.value;
        if (PlayerPrefs.HasKey("volume"))
        {
            m_slider.value = 1;
        }
        else
        {
            m_slider.value = PlayerPrefs.GetFloat("volume");
        }
    }

    private void Update()
    {
        if (o_m_volume != m_slider.value)
        {
            PlayerPrefs.SetFloat("volume", m_slider.value);
            PlayerPrefs.Save();
            o_m_volume = m_slider.value;
        }
    }
}
