using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject levelChange;
    public GameObject qualityChange;

    private void Start()
    {
        levelChange.SetActive(false);
        qualityChange.SetActive(false);
    }


    public void QualitySet()
    {
        qualityChange.SetActive(true);
    }

    //load 1st lvl
    public void Lvl1()
    {
        SceneManager.LoadScene(3);
    }

    //load 2nd lvl
    public void Lvl2()
    {
        SceneManager.LoadScene(4);
    }

    //load 3rd lvl
    public void Lvl3()
    {
        SceneManager.LoadScene(5);
    }

    //load 4th lvl
    public void Lvl4()
    {
        //SceneManager.LoadScene(6);
    }

    public void changeLevel()
    {
        levelChange.SetActive(true);
    }

    public void setFalse()
    {
        levelChange.SetActive(false);
    }

    public void setFalse1()
    {
        qualityChange.SetActive(false);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    //quit
    public void Quit()
    {
        Application.Quit();
    }

    //options
    public void Option()
    {
        qualityChange.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
