using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Resolution : MonoBehaviour
{

    public Dropdown dropdown;
    UnityEngine.Resolution[] res;

    private void Start()
    {
        UnityEngine.Resolution[] resolutions = Screen.resolutions;
        res = resolutions.Distinct().ToArray();
        string [] strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].ToString();
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(strRes.ToList());
        //Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, true);
    }

    public void SetRes()
    {
        Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, true);
    }

}
