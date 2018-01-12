using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{

    public void PlayButton(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}