using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    public Dropdown dropdown;

    public void checkdropdown()
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
    }
}
