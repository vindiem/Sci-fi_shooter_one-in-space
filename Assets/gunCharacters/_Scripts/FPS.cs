using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public float timer, refresh, avg;
    public string display;
    public Text _text;

    private void Update()
    {
        float timelaspe = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= Time.deltaTime;

        if (timer <= 0)
        {
            avg = (int)(1f / timelaspe);
        }
        _text.text = string.Format(display, avg.ToString());

    }

}
