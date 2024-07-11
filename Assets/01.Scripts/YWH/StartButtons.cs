using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour
{
    public void StartButtonClick()
    {
        StartCoroutine(Waitasec());

    }

    IEnumerator Waitasec()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("YWH");
        print("dd");
    }

    public void LeaveButtonClick()
    {
        print("ss");
        Application.Quit();
    }   
}
